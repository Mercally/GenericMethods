using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CGC_GM_FE.Models.ViewModels
{
    public class Header
    {
        /// <summary>
        /// Titulo de la vista
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// SubTitulo de la vista
        /// </summary>
        public string SubTitle { get; set; }
        /// <summary>
        /// Path completo
        /// </summary>
        public List<Location> ListLocation { get; set; }
    }
}
