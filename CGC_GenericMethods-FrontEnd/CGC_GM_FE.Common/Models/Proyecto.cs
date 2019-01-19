﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace CGC_GM_FE.Common.Models
{
    public class Proyecto
    {
        public Proyecto()
        {

        }

        public Proyecto(TipoFormularioEnum tipoFormulario)
        {
            Id = 0;
            Nombre = string.Empty;
            FechaRegistro = DateTime.Now;
            EsActivo = true;
            TipoFormulario = tipoFormulario;
        }

        [HiddenInput]
        public int Id { get; set; }
        [Required]
        [MaxLength(99)]
        [DisplayName("Nombre proyecto")]
        public string Nombre { get; set; }
        [HiddenInput]
        [DisplayName("Fecha registro")]
        public DateTime FechaRegistro { get; set; }
        [HiddenInput]
        [DisplayName("Estado")]
        public bool EsActivo { get; set; }

        [DisplayName("Proyecto")]
        public string BotonGuardarCambios { get; set; }
        [DisplayName("Proyecto")]
        public TipoFormularioEnum TipoFormulario { get; set; }
    }
}
