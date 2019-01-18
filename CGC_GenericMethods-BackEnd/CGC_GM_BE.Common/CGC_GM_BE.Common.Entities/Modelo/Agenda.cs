using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CGC_GM_BE.Common.Entities.Modelo
{
    public class Agenda
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }

        public DateTime? FechaCreado { get; set; }
        public bool? EsActivo { get; set; }
        public TimeSpan? TiempoTotal { get; set; }
        public decimal? Dinero { get; set; }
        public float? Float { get; set; }

        public List<Tarea> Tarea { get; set; }
        public List<Usuario> Usuario { get; set; }
    }
}
