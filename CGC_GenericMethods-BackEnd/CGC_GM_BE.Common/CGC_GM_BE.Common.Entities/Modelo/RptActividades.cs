using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CGC_GM_BE.Common.Entities.Modelo
{
    public class RptActividades
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }
        public int BoletaId { get; set; }
        public int EstadoId { get; set; }
        public string EstadoNombre { get; set; }
        public bool EsActivo { get; set; }
        public DateTime FechaRegistro { get; set; }
        public DateTime FechaActividad { get; set; }
        public decimal TiempoActividad { get; set; }
    }
}
