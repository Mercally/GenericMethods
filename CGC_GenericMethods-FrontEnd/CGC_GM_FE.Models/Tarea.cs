using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CGC_GM_FE.Models
{
    public class Tarea
    {
        public int Id { get; set; }
        public int AgendaId { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }

        public Agenda Agenda { get; set; }
    }
}
