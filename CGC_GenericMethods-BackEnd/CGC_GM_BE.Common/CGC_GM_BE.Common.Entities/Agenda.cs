using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CGC_GM_BE.Common.Entities
{
    public class Agenda
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }

        public List<Tarea> Tarea { get; set; }
        public List<Usuario> Usuario { get; set; }
    }
}
