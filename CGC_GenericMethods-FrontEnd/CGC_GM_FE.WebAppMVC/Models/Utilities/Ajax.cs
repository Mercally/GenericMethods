using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CGC_GM_FE.WebAppMVC.Models.Utilities
{
    public class Ajax
    {

        public Ajax()
        {
            Async = true;
            Cache = false;
            Method = "GET";
            DataType = "html";
        }

        /// <summary>
        /// Url de la petición
        /// </summary>
        public string Url { get; set; }
        /// <summary>
        /// Parametro para habilitar funcion asincrona
        /// </summary>
        public bool Async { get; set; }
        /// <summary>
        /// Parametro para habilitar el cache
        /// </summary>
        public bool Cache { get; set; }
        /// <summary>
        /// (Opcional) Tipo de datos que retorna la solicitud (Default: Html)
        /// html, json, xml, script
        /// </summary>
        public string DataType { get; set; }
        /// <summary>
        /// (Opcional) Representación JsonP de la data a enviar
        /// </summary>
        public string Data { get; set; }
        /// <summary>
        /// (Opcional) Método de la petición Post o Get, Default: Get
        /// </summary>
        public string Method { get; set; }
        /// <summary>
        /// Identificador del elemento donde se rendizará el resultado de la carga ajax
        /// </summary>
        public string UpdateElementId { get; set; }
    }
}
