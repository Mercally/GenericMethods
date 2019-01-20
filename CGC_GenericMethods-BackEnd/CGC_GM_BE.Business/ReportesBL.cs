using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CGC_GM_BE.Common.Entities.Modelo;
using CGC_GM_BE.DataAccess;
namespace CGC_GM_BE.Business
{
    public class ReportesBL
    {
        public static _Resultado<List<RptBoletas>> ReporteBoletas(string fechaEntrada, string fechaSalida)
        {
            var Reporte = new _Resultado<List<RptBoletas>>();

            using (var Contexto = new CGC_GM_Contexto())
            {
                Reporte = Contexto
                    .Rpt_Boletas
                    .ReporteBoleta(fechaEntrada, fechaSalida);

                if (Reporte.EsCorrecto)
                {
                    foreach (var item in Reporte.Resultado)
                    {
                        var ReporteActividad = Contexto.Rpt_Actividades.ReporteActividadesSegunBoleta(item.Id);
                        if (ReporteActividad.EsCorrecto)
                        {
                            item.ListaRptActividades = ReporteActividad.Resultado;
                        }
                    }
                }
            }

            return Reporte;
        }
    }
}
