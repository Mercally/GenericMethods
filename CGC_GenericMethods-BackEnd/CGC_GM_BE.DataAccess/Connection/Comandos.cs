using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CGC_GM_BE.DataAccess.Interface;
using CGC_GM_BE.DataAccess.Implement;
using CGC_GM_BE.DataAccess.Model;

namespace CGC_GM_BE.DataAccess.Connection
{
    public class Comandos
    {
        /// <summary>
        /// Constructor público por defecto
        /// </summary>
        /// <param name="Transaccion"></param>
        public Comandos(SqlTransaction Transaccion)
        {
            this.Transaccion = Transaccion;
        }

        private Comandos() { }

        private SqlTransaction Transaccion { get; }

        /// <summary>
        /// Retorna una tabla de acuerdo a la consulta proporcionada
        /// </summary>
        /// <param name="Consulta">Consulta a ejecutar</param>
        /// <returns></returns>
        public SqlDataReader ExecuteQuery(_ConsultaT_Sql Consulta)
        {
            if (Transaccion.Connection.State != ConnectionState.Open)
            {
                Transaccion.Connection.Open();
            }

            SqlCommand cmd = new SqlCommand(Consulta.ConsultaCruda, Transaccion.Connection, Transaccion);
            cmd.CommandTimeout = Consulta.TimeOut;
            cmd.Parameters.AddRange(Consulta.Parametros.ToArray());

            return cmd.ExecuteReader(); ;
        }

        /// <summary>
        /// Ejecuta comandos delete y update
        /// </summary>
        /// <param name="Consulta">Consulta a ejecutar</param>
        /// <returns></returns>
        public bool ExecuteNonQuery(_ConsultaT_Sql Consulta)
        {
            if (Transaccion.Connection.State != ConnectionState.Open)
            {
                Transaccion.Connection.Open();
            }

            SqlCommand cmd = new SqlCommand(Consulta.ConsultaCruda, Transaccion.Connection, Transaccion);
            cmd.CommandTimeout = Consulta.TimeOut;
            cmd.Parameters.AddRange(Consulta.Parametros.ToArray());

            int Changes = cmd.ExecuteNonQuery();

            return Changes > 0 || true; // Si no hay cambios
        }

        /// <summary>
        /// Ejecuta un comando que devuelve un solo valor
        /// </summary>
        /// <param name="Consulta">Consulta a ejecutar</param>
        /// <returns></returns>
        public int ExecuteScalarInsert(_ConsultaT_Sql Consulta)
        {
            int? Result = 0;

            if (Transaccion.Connection.State != ConnectionState.Open)
            {
                Transaccion.Connection.Open();
            }

            SqlCommand cmd = new SqlCommand(Consulta.ConsultaCruda, Transaccion.Connection, Transaccion);
            cmd.CommandTimeout = Consulta.TimeOut;
            cmd.Parameters.AddRange(Consulta.Parametros.ToArray());
            
            Result = (int?)cmd.ExecuteScalar() as int?;

            return Result ?? 0;
        }

        /// <summary>
        /// Ejecuta un comando que devuelve un solo valor
        /// </summary>
        /// <param name="Consulta">Consulta a ejecutar</param>
        /// <returns></returns>
        public object ExecuteScalar(_ConsultaT_Sql Consulta)
        {
            object Result = null;

            if (Transaccion.Connection.State != ConnectionState.Open)
            {
                Transaccion.Connection.Open();
            }

            SqlCommand cmd = new SqlCommand(Consulta.ConsultaCruda, Transaccion.Connection, Transaccion);
            cmd.CommandTimeout = Consulta.TimeOut;
            cmd.Parameters.AddRange(Consulta.Parametros.ToArray());

            Result = cmd.ExecuteScalar();

            return Result;
        }

        /// <summary>
        /// Ejecuta la consulta de acuerdo a la especificacion del tipo de consulta
        /// </summary>
        /// <param name="Consulta">Consulta a ejecutar</param>
        /// <returns>objeto segun tipo de transaccion</returns>
        public IResultadoConsulta Ejecutar(_ConsultaT_Sql Consulta)
        {
            IResultadoConsulta Resultado = new ResultadoGenericoImpl();

            switch (Consulta.TipoConsulta)
            {
                case _TipoConsultaEnum.Insert:
                    Resultado.ResultadoTipoInsert = ExecuteScalarInsert(Consulta);
                    break;
                case _TipoConsultaEnum.Update:
                    Resultado.ResultadoTipoUpdate = ExecuteNonQuery(Consulta);
                    break;
                case _TipoConsultaEnum.Delete:
                    Resultado.ResultadoTipoDelete = ExecuteNonQuery(Consulta);
                    break;
                case _TipoConsultaEnum.Query:
                    Resultado.ResultadoTipoQuery = ExecuteQuery(Consulta);
                    break;
                default:
                    throw new ArgumentOutOfRangeException("No existe la opción especificada");
            }

            return Resultado;
        }
    }
}
