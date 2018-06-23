using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CGC_GM_BE.Common.Entities
{
    public class Catalogo
    {
        public string Tabla { get; set; }
        public string Campo { get; set; }
        public string Codigo { get; set; }
        public string Valor { get; set; }

        public int Id { get; set; }
        public string Nombre { get; set; }
        public DateTime FechaRegistro { get; set; }
        public bool EsActivo { get; set; }
    }
}
