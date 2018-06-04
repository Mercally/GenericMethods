using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CGC_GM_BE.Common.Entities
{
    public class Tarea
    {
        public int Id { get; set; }
        public int AgendaId { get; set; }
        public string Nombre { get; set; }
        public int EstadoId { get; set; }
        public DateTime? FechaVencimiento { get; set; }
        public DateTime? FechaRecordatorio { get; set; }
        public string Descripcion { get; set; }

        public Agenda Agenda { get; set; }
        public Catalogo Estado { get; set; }

        public string EstadoDescripcion { get; set; }
    }
}
