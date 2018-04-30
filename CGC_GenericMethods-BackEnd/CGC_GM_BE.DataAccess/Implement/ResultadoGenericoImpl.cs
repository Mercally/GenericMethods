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
    /// <summary>
    /// 
    /// </summary>
    public class ResultadoGenericoImpl : IResultadoConsulta
    {
        /// <summary>
        /// 
        /// </summary>
        public int ResultadoTipoInsert { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public bool ResultadoTipoUpdate { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public bool ResultadoTipoDelete { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public DataTable ResultadoTipoQuery { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int CantidadCambios { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public System.Exception Excepcion { get; set; }

        /// <summary>
        /// 
        /// </summary>
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
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
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
                            object Valor = Row.IsNull(Propiedades[i]) ? "" : Row[Propiedades[i]];

                            PropInfo[i].SetValue(
                                obj, Convert.ChangeType(Valor, PropInfo[i].PropertyType), null
                                );
                        }
                    }

                    ListaResultado.Add(obj);
                }

                return ListaResultado as List<T>;
            }
            catch (Exception)
            {
                // Excepcion
                return new List<T>();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T">Tipo de dato a retornar</typeparam>
        /// <returns></returns>
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
                            object Valor = Row.IsNull(Propiedades[i]) ? "" : Row[Propiedades[i]];

                            PropInfo[i].SetValue(
                                obj, Convert.ChangeType(Valor, PropInfo[i].PropertyType), null
                                );
                        }
                    }

                    return obj;
                }

                throw new ArgumentNullException("No existe ningún elemento en la lista.");
            }
            catch (Exception)
            {
                return default(T);
            }
        }
    }
}
