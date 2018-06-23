using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CGC_GM_FE.Models.ViewModels
{
    public class Modal
    {
        /// <summary>
        /// Constructor por defecto
        /// </summary>
        public Modal()
        {
            Ajax = null;
        }

        /// <summary>
        /// (Opcional) Identificador del elemento modal a cerrar
        /// </summary>
        public string CloseModalId { get; set; }
        /// <summary>
        /// (Opcional) Identificador del elemento modal a abrir
        /// </summary>
        public string OpenModalId { get; set; }
        /// <summary>
        /// Identificador del elemento donde se rendizará el resultado de la carga ajax
        /// </summary>
        public string UpdateElementId { get; set; }
        /// <summary>
        /// (Opcional) Objeto para construir una petición ajax de renderizado de resultados
        /// </summary>
        public Ajax Ajax { get; set; }
    }
}
