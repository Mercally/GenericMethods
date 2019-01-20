using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CGC_GM_FE.Common.Models
{
    public class RptBoletas
    {
        public int Id { get; set; }
        public string NumeroBoleta { get; set; }
        public DateTime FechaEntrada { get; set; }
        public DateTime FechaSalida { get; set; }
        public decimal TiempoEfectivo { get; set; }
        public int TiempoInvertidoEn { get; set; }
        public int ProyectoId { get; set; }
        public string ProyectoNombre { get; set; }
        public int ClienteId { get; set; }
        public string ClienteNombre { get; set; }
        public DateTime FechaRegistro { get; set; }
        public int UsuarioId { get; set; }
        public string UsuarioNombreCompleto { get; set; }
        public int DepartamentoId { get; set; }
        public string DepartamentoNombre { get; set; }
        public bool EsActivo { get; set; }
        public string Descripcion { get; set; }

        public List<RptActividades> ListaRptActividades { get; set; }
    }
}
