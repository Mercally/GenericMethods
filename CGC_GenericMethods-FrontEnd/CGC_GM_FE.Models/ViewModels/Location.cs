using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CGC_GM_FE.Models.ViewModels
{
    public class Location
    {
        /// <summary>
        /// Constructor por defecto
        /// </summary>
        /// <param name="Name">Nombre a mostrar</param>
        /// <param name="Url">Url para redirigir</param>
        /// <param name="IsActive">Determina si se mostrará activo el elemento</param>
        public Location(string Name, string Url, bool IsActive = false)
        {
            this.Name = Name;
            this.Url = Url;
            this.IsActive = IsActive;
        }

        /// <summary>
        /// Nombre a mostrar
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Url para redirigir
        /// </summary>
        public string Url { get; set; }
        /// <summary>
        /// Determina si se mostrará activo el elemento<
        /// </summary>
        public bool IsActive { get; set; }
    }
}
