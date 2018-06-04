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
    public class Tarea
    {
        [HiddenInput]
        public int Id { get; set; }

        [HiddenInput]
        public int AgendaId { get; set; }

        [Required(ErrorMessage = "Campo requerido.")]
        [DisplayName("Nombre")]
        [RegularExpression(@"^\S[a-zA-Z0-9ñÑáéíóúÁÉÍÓÚüÜ' ]+$", ErrorMessage = "No se permiten caracteres no comunes.")]
        [MaxLength(100)]
        public string Nombre { get; set; }

        [DisplayName("Estado")]
        public string EstadoId { get; set; }


        public DateTime? FechaVencimiento { get; set; }
        public DateTime? FechaRecordatorio { get; set; }

        [DisplayName("Descripción")]
        [RegularExpression(@"^\S[a-zA-Z0-9ñÑáéíóúÁÉÍÓÚüÜ' ]+$", ErrorMessage = "No se permiten caracteres no comunes.")]
        [MaxLength(100)]
        public string Descripcion { get; set; }

        public Agenda Agenda { get; set; }
        public Catalogo Estado { get; set; }

        [DisplayName("Estado")]
        public string EstadoDescripcion { get; set; }
    }
}
