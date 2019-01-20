using System;
using System.Collections.Generic;
using System.Configuration;
using CGC_GM_FE.Common.Models;
using CGC_GM_FE.WebApiRestClient.Metadata.ServiceTimeManagerApi;

namespace CGC_GM_FE.WebApiRestClient.Services.ServiceTimeManagerApi
{
    public class ReportesControllerApi : IReportesControllerApi
    {
        private string ApiUri
        {
            get
            {
                return ConfigurationSettings.AppSettings["ServiceTimeManagerApi"] + "/Reportes";
            }
        }

        public _Resultado<List<RptBoletas>> ReporteBoletasFechas(DateTime fechaEntrada, DateTime fechaSalida)
        {
            string fechaEntradaString = fechaEntrada.ToString("yyyyMMdd");
            string fechaSalidaString = fechaSalida.ToString("yyyyMMdd");

            var Respuesta = GenericHelper
                .Request<List<RptBoletas>>(
                Url: $"{ApiUri}/ReporteBoletasFechas/{fechaEntradaString}/{fechaSalidaString}",
                Method: HttpMethodEnum.HttpGet
                );

            return Respuesta;
        }
    }
}
