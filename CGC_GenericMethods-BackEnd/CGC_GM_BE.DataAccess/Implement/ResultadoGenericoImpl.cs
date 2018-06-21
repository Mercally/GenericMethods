using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using CGC_GM_BE.DataAccess.Interface;

namespace CGC_GM_BE.DataAccess.Implement
{

    public class ResultadoGenericoImpl : IResultadoConsulta
    {
        public int ResultadoTipoInsert { get; set; }
        public bool ResultadoTipoUpdate { get; set; }
        public bool ResultadoTipoDelete { get; set; }
        public DataTable ResultadoTipoQuery { get; set; }
        public int CantidadCambios { get; set; }
        public System.Exception Excepcion { get; set; }
        public bool EsCorrecto
        {
            get
            {
                return
                       CantidadCambios > 0
                    || ResultadoTipoDelete
                    || ResultadoTipoUpdate
                    || ResultadoTipoInsert > 0
                    || ResultadoTipoQuery != null
                    || Excepcion == null;
            }
        }

        /// <summary>
        /// Obtiene el resultado convertido al tipo especificado
        /// </summary>
        /// <typeparam name="T">Tipo de dato a retornar</typeparam>
        /// <returns>Lista de objetos de tipo especificado</returns>
        public List<T> ObtenerResultadoLista<T>()
        {
            List<T> ListaResultado = new List<T>();

            if (!this.EsCorrecto)
            {
                // Manejo de errores

                return new List<T>();
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

                    ListaResultado.Add(obj);
                }

                return ListaResultado as List<T>;
            }
            catch (Exception Ex)
            {
                // Excepcion
                return new List<T>();
            }
        }

        /// <summary>
        /// Obtiene el resultado convertido al tipo especificado
        /// </summary>
        /// <typeparam name="T">Tipo de dato a retornar</typeparam>
        /// <returns>Objetos de tipo especificado</returns>
        public T ObtenerResultadoUnico<T>()
        {
            List<T> ListaResultado = new List<T>();
            
            if (!this.EsCorrecto)
            {
                // Manejo de errores

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
                            if (!Row.IsNull(Propiedades[i]) || !(System.DBNull.Value == Row[Propiedades[i]]))
                            {
                                PropInfo[i].SetValue(
                                obj, Convert.ChangeType(Row[Propiedades[i]], PropInfo[i].PropertyType), null
                                );
                            }
                        }
                    }

                    return obj;
                }

                throw new ArgumentNullException("No existe ningún elemento en la lista.");
            }
            catch (Exception Ex)
            {
                return default(T);
            }
        }
    }
}
