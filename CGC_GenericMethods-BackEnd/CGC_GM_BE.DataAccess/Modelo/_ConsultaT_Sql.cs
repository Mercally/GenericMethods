using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using CGC_GM_BE.Common.Entities;
using CGC_GM_BE.Common.Entities.Constantes;
using CGC_GM_BE.DataAccess.Conexion;

namespace CGC_GM_BE.DataAccess.Modelo
{
    public class _ConsultaT_Sql
    {
        public _ConsultaT_Sql(int TimeOut = 1)
        {
            this.ConsultaCruda = string.Empty;
            this.Parametros = new List<SqlParameter>();
            this.TieneError = false;
            this.TimeOut = TimeOut;
        }

        public _ConsultaT_Sql(string ConsultaCruda, List<SqlParameter> Params = null, int TimeOut = 1)
        {
            this.ConsultaCruda = ConsultaCruda;
            this.Parametros = Params ?? new List<SqlParameter>();
            this.TieneError = false;
            this.TimeOut = TimeOut;
        }

        public static _ConsultaT_Sql CreateQuery(Object pObjecto, int tipoConsulta, bool esEliminadoLogico = true, int TimeOut = 1)
        {
            _ConsultaT_Sql Query = new _ConsultaT_Sql();
           
            switch (tipoConsulta)
            {
                case Common.Entities.Constantes.TipoConsulta.Insert:
                    Query = CreateINSERT(pObjecto);
                    break;
                case Common.Entities.Constantes.TipoConsulta.Update:
                    Query = CreateUPDATE(pObjecto);
                    break;
                case Common.Entities.Constantes.TipoConsulta.Delete:
                    Query = CreateDELETE(pObjecto, esEliminadoLogico);
                    break;
                case Common.Entities.Constantes.TipoConsulta.Query:
                    Query = CreateSELECT(pObjecto);
                    break;
                default:
                    break;
            }

            Query.TipoConsulta = tipoConsulta;

            return Query;
        }

        /// <summary>
        /// Consulta en forma de cadena T-SQL
        /// </summary>
        public string ConsultaCruda { get; set; }

        /// <summary>
        /// Lista de parámetros según nombre en ConsultaCruda
        /// </summary>
        public List<SqlParameter> Parametros { get; set; }

        /// <summary>
        /// Tipo de consulta a realizar: Insert, Update, Delete, Query
        /// </summary>
        public int TipoConsulta { get; set; }

        /// <summary>
        /// Tiempo de espera en segundos para cada comando de forma individual
        /// </summary>
        public int TimeOut { get; set; }

        /// <summary>
        /// Determina si la consulta tiene errores
        /// </summary>
        public bool TieneError { get; internal set; }

        /// <summary>
        /// Crea una consulta tipo SELECT basica a partir de una clase
        /// </summary>
        /// <param name="Obj"></param>
        /// <returns></returns>
        private static _ConsultaT_Sql CreateSELECT(Object Obj)
        {
            Type Tipo = Obj.GetType();
            var TableName = Tipo.GetCustomAttributesData()[0].ConstructorArguments[0].Value;
            string[] Propiedades = Tipo.GetProperties().Select(x => x.Name).ToArray();

            string SqlQuery = $"SELECT ";

            foreach (var Column in Propiedades)
            {
                SqlQuery += Column + ", ";
            }

            SqlQuery = SqlQuery.Substring(0, (SqlQuery.Length - 2));
            SqlQuery += $" FROM {TableName};";

            return new _ConsultaT_Sql(SqlQuery);
        }

        /// <summary>
        /// Crea una consulta tipo delete a partir de una clases
        /// </summary>
        /// <param name="Obj"></param>
        /// <returns></returns>
        private static _ConsultaT_Sql CreateINSERT(Object Obj)
        {
            Type Tipo = Obj.GetType();
            var TableName = Tipo.GetCustomAttributesData()[0].ConstructorArguments[0].Value;

            string SqlQuery = string.Empty;
            string Insert = $"INSERT INTO {TableName}(";
            string Values = ")VALUES(";

            List<SqlParameter> ListParameters = new List<SqlParameter>();

            PropertyInfo[] PropInfo = Tipo.GetProperties();

            foreach (var Prop in PropInfo)
            {
                var Attrs = Prop.GetCustomAttributes().Select(x => x.GetType().Name).ToArray();

                if (Attrs.Contains("KeyAttribute"))
                {
                    continue;
                }
                else if (Attrs.Contains("ColumnAttribute"))
                {
                    string Column = Prop.Name;
                    object Value = Prop.GetValue(Obj);

                    if (Value != null)
                    {
                        Insert += Column + ", ";

                        string Param = "@" + Column;
                        Values += Param + ", ";

                        ListParameters.Add(new SqlParameter(Param, Value));
                    }
                }
            }

            Insert = Insert.Substring(0, (Insert.Length - 2));
            Values = Values.Substring(0, (Values.Length - 2));
            SqlQuery = Insert + Values + "); SELECT SCOPE_IDENTITY();";

            return new _ConsultaT_Sql(SqlQuery, ListParameters);
        }

        /// <summary>
        /// Crea una consulta tipo Update a partir de una clase
        /// </summary>
        /// <param name="Obj">Objeto</param>
        /// <returns></returns>
        private static _ConsultaT_Sql CreateUPDATE(Object Obj)
        {
            Type Tipo = Obj.GetType();

            var TableName = Tipo.GetCustomAttributesData()[0].ConstructorArguments[0].Value;

            string SqlQuery = $"UPDATE {TableName} SET ";
            string Where = string.Empty;

            List<SqlParameter> ListParameters = new List<SqlParameter>();


            PropertyInfo[] PropInfo = Tipo.GetProperties();

            foreach (var Prop in PropInfo)
            {
                var Attrs = Prop.GetCustomAttributes().Select(x => x.GetType().Name).ToArray();

                string Column = Prop.Name;
                string Param = $"@{Column}";

                object Value = Prop.GetValue(Obj);

                if (Attrs.Contains("KeyAttribute"))
                {
                    Where = $"WHERE {Column}={Param};";
                    ListParameters.Add(new SqlParameter(Param, Value));
                    continue;
                }
                else if (Attrs.Contains("ColumnAttribute"))
                {
                    SqlQuery += $"{Column}={Param}, ";
                    ListParameters.Add(new SqlParameter(Param, Value));
                }
            }

            SqlQuery = SqlQuery.Substring(0, (SqlQuery.Length - 2));
            SqlQuery += Where;

            return new _ConsultaT_Sql(SqlQuery, ListParameters);
        }

        /// <summary>
        /// Crea una consulta tipo Delete a partir de una clase
        /// </summary>
        /// <param name="Obj"></param>
        /// <param name="IsLogical"></param>
        /// <returns></returns>
        private static _ConsultaT_Sql CreateDELETE(Object Obj, bool IsLogical)
        {
            Type Tipo = Obj.GetType();
            var TableName = Tipo.GetCustomAttributesData()[0].ConstructorArguments[0].Value;
            string SqlQuery = string.Empty;

            List<SqlParameter> ListParameters = new List<SqlParameter>();
            if (IsLogical)
            {
                SqlQuery = $"UPDATE {TableName} SET EsActivo = 0;";
            }
            else
            {
                SqlQuery = $"DELETE {TableName} WHERE Id = @Id;";
                ListParameters.Add(new SqlParameter("@Id", 1));
            }

            return new _ConsultaT_Sql(SqlQuery, ListParameters);
        }
    }
}
