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
    public class Agenda
    {
        [HiddenInput]
        public int Id { get; set; }

        [Required(ErrorMessage = "Campo requerido.")]
        [DisplayName("Nombre")]
        [RegularExpression(@"^\S[a-zA-Z0-9ñÑáéíóúÁÉÍÓÚüÜ' ]+$", ErrorMessage = "No se permiten caracteres no comunes.")]
        [MaxLength(100)]
        public string Nombre { get; set; }

        [DisplayName("Descripción")]
        [RegularExpression(@"^\S[a-zA-Z0-9ñÑáéíóúÁÉÍÓÚüÜ' ]+$", ErrorMessage = "No se permiten caracteres no comunes.")]
        [MaxLength(500)]
        public string Descripcion { get; set; }

        public List<Tarea> Tarea { get; set; }
        public List<Usuario> Usuario { get; set; }
    }
}
