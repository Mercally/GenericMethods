using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CGC_GM_BE.DataAccess.Consulta
{
    /// <summary>
    /// 
    /// </summary>
    public enum TipoConsultaEnum
    {
        /// <summary>
        /// 
        /// </summary>
        Insert = 0,

        /// <summary>
        /// 
        /// </summary>
        Update = 1,

        /// <summary>
        /// 
        /// </summary>
        Delete = 2,

        /// <summary>
        /// 
        /// </summary>
        Query = 3,

        /// <summary>
        /// 
        /// </summary>
        StoredProcedure = 4,

        /// <summary>
        /// 
        /// </summary>
        Function = 5
    }
}
