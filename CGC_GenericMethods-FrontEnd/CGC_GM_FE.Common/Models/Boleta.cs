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
    public class Boleta
    {
        public Boleta()
        {

        }

        public Boleta(TipoFormularioEnum tipoFormulario)
        {
            Id = 0;
            NumeroBoleta = "DEV";
            EsActivo = true;
            TipoFormulario = tipoFormulario;
            FechaRegistro = FechaEntrada = FechaSalida = DateTime.Now;
        }

        [HiddenInput]
        public int Id { get; set; }
        [Required]
        [DisplayName("Numero Boleta")]
        public string NumeroBoleta { get; set; }
        [Required]
        [DisplayName("Fecha y hora de entrada")]
        public DateTime FechaEntrada { get; set; }
        [Required]
        [DisplayName("Fecha y hora de salida")]
        public DateTime FechaSalida { get; set; }
        [Required]
        [DisplayName("Tiempo efectivo")]
        public decimal TiempoEfectivo { get; set; }
        [Required]
        [DisplayName("Invertido en")]
        public int TiempoInvertidoEn { get; set; }
        [Required]
        [DisplayName("Proyecto")]
        public int ProyectoId { get; set; }
        [Required]
        [DisplayName("Cliente")]
        public int ClienteId { get; set; }
        [HiddenInput]
        public DateTime FechaRegistro { get; set; }
        [HiddenInput]
        public int UsuarioId { get; set; }
        [Required]
        [DisplayName("Departamento")]
        public int DepartamentoId { get; set; }
        [HiddenInput]
        public bool EsActivo { get; set; }

        [HiddenInput]
        public Catalogo TiempoInvertido { get; set; }
        [HiddenInput]
        public Proyecto Proyecto { get; set; }
        [HiddenInput]
        public Cliente Cliente { get; set; }
        [HiddenInput]
        public Usuario Usuario { get; set; }
        [HiddenInput]
        public Catalogo Departamento { get; set; }
        [HiddenInput]
        public List<Actividad> Actividades { get; set; }

        [Required]
        [DisplayName("Descripción")]
        [MaxLength(349)]
        public string Descripcion { get; set; }

        [DisplayName("Boleta")]
        public string BotonGuardarCambios { get; set; }
        [DisplayName("Boleta")]
        public TipoFormularioEnum TipoFormulario { get; set; }
    }
}
