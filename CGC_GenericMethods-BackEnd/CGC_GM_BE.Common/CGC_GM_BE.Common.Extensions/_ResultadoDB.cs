using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using CGC_GM_BE.Common.Extensions;
using CGC_GM_BE.DataAccess.Modelo;

namespace CGC_GM_BE.DataAccess.Modelo
{
    public class _ResultadoDB
    {
        public int ResultadoTipoInsert { get; set; }
        public bool ResultadoTipoUpdate { get; set; }
        public bool ResultadoTipoDelete { get; set; }
        public DataTable ResultadoTipoQuery { get; set; }
        public int CantidadCambios { get; set; }
        public int _TipoConsulta { get; set; }

        public List<System.Exception> ListaExcepciones = new List<Exception>();

        public bool EsCorrecto
        {
            get
            {
                bool Value = false;
                switch (_TipoConsulta)
                {
                    case TipoConsulta.Delete:
                        Value = ResultadoTipoDelete && ListaExcepciones?.Count() == 0;
                        break;
                    case TipoConsulta.Insert:
                        Value = ResultadoTipoInsert > 0 && ListaExcepciones?.Count() == 0;
                        break;
                    case TipoConsulta.Query:
                        Value = ResultadoTipoQuery != null && ListaExcepciones?.Count() == 0;
                        break;
                    case TipoConsulta.Update:
                        Value = ResultadoTipoUpdate && ListaExcepciones?.Count() == 0;
                        break;
                    default:
                        Value = false;
                        break;
                }
                return Value;
            }
        }

        /// <summary>
        /// Obtiene el resultado convertido al tipo especificado
        /// </summary>
        /// <typeparam name="T">Tipo de dato a retornar</typeparam>
        /// <returns>Lista de objetos de tipo especificado</returns>
        private T ConvertirResultadoLista<T>()
        {
            T ListaResultado = (T)Activator.CreateInstance(typeof(T));

            if (!this.EsCorrecto)
            {
                return ListaResultado;
            }

            try
            {
                Type Tipo = typeof(T);
                MethodInfo AddMethod = Tipo.GetMethod("Add");

                Type TipoSecundario = Tipo.GenericTypeArguments[0];
                string[] Propiedades = TipoSecundario.GetProperties().Select(x => x.Name).ToArray();
                PropertyInfo[] PropInfo = TipoSecundario.GetProperties();

                foreach (DataRow Row in ResultadoTipoQuery.Rows)
                {
                    var obj = Activator.CreateInstance(TipoSecundario);

                    for (int i = 0; i < Propiedades.Length; i++)
                    {
                        if (ResultadoTipoQuery.Columns.Contains(Propiedades[i]))
                        {
                            object DataCell = Row[Propiedades[i]];
                            Type TypeCell = PropInfo[i].PropertyType;

                            if (!Row.IsNull(Propiedades[i]) || !(System.DBNull.Value == DataCell))
                            {
                                if (TypeCell.IsGenericType && TypeCell.GetGenericTypeDefinition().Equals(typeof(Nullable<>)))
                                {
                                    TypeCell = Nullable.GetUnderlyingType(TypeCell);
                                }

                                PropInfo[i].SetValue(obj, Convert.ChangeType(DataCell, TypeCell));
                            }
                        }
                    }

                    AddMethod.Invoke(ListaResultado, new object[] { obj });
                }

                return ListaResultado;
            }
            catch (Exception Ex)
            {
                ListaExcepciones.Add(Ex);
                return (T)Activator.CreateInstance(typeof(T));
            }
        }

        /// <summary>
        /// Obtiene el resultado convertido al tipo especificado
        /// </summary>
        /// <typeparam name="T">Tipo de dato a retornar</typeparam>
        /// <returns>Objetos de tipo especificado</returns>
        private T ConvertirResultadoUnico<T>()
        {
            List<T> ListaResultado = new List<T>();

            if (!this.EsCorrecto)
            {
                return default(T);
            }

            try
            {
                Type Tipo = typeof(T);
                string[] Propiedades = Tipo.GetProperties().Select(x => x.Name).ToArray();

                PropertyInfo[] PropInfo = Tipo.GetProperties();

                foreach (DataRow Row in ResultadoTipoQuery.Rows)
                {
                    T obj = (T)Activator.CreateInstance(typeof(T));

                    for (int i = 0; i < Propiedades.Length; i++)
                    {
                        if (ResultadoTipoQuery.Columns.Contains(Propiedades[i]))
                        {
                            object DataCell = Row[Propiedades[i]];
                            Type TypeCell = PropInfo[i].PropertyType;

                            if (!Row.IsNull(Propiedades[i]) || !(System.DBNull.Value == DataCell))
                            {
                                if (TypeCell.IsGenericType && TypeCell.GetGenericTypeDefinition().Equals(typeof(Nullable<>)))
                                {
                                    TypeCell = Nullable.GetUnderlyingType(TypeCell);
                                }

                                PropInfo[i].SetValue(obj, Convert.ChangeType(DataCell, TypeCell));
                            }
                        }
                    }

                    return obj;
                }

                return default(T);
            }
            catch (Exception Ex)
            {
                ListaExcepciones.Add(Ex);
                return default(T);
            }
        }

        public T ConvertirResultado<T>()
        {
            var Tipo = typeof(T);
            if (Tipo.IsGenericType && Tipo.GetGenericArguments().Length > 0)
            {
                return ConvertirResultadoLista<T>();
            }
            else
            {
                return ConvertirResultadoUnico<T>();
            }
        }
    }
}
