using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CGC_GM_BE.Common.Entities.Constantes
{
    public class TipoConsulta
    {
        /// <summary>
        /// Insert seguido de un select del ID recien ingresado, retorna dicho ID
        /// </summary>
        public const int Insert = 0;

        /// <summary>
        /// Update del registro
        /// </summary>
        public const int Update = 1;

        /// <summary>
        /// Delete del registro
        /// </summary>
        public const int Delete = 2;

        /// <summary>
        /// Consulta
        /// </summary>
        public const int Query = 3;
    }
}
