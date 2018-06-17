using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CGC_GM_BE.DataAccess.Model
{
    /// <summary>
    /// Tipo de consulta a ejecutar
    /// </summary>
    public enum _TipoConsultaEnum
    {
        /// <summary>
        /// Insert seguido de un select del ID recien ingresado, retorna dicho ID
        /// </summary>
        Insert = 0,

        /// <summary>
        /// Update del registro
        /// </summary>
        Update = 1,

        /// <summary>
        /// Delete del registro
        /// </summary>
        Delete = 2,

        /// <summary>
        /// Consulta
        /// </summary>
        Query = 3
    }
}
