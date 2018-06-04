using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CGC_GM_FE.Models
{
    public class Usuario
    {
        public long Id { get; set; }
        public string NombreUsuario { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public string CorreoCorporativo { get; set; }
        public string ContraseniaCorporativa { get; set; }

        public List<Agenda> Agenda { get; set; }
    }
}
