using CGC_GM_BE.Business;
using CGC_GM_BE.Common.Entities.Modelo;
using CGC_GM_BE.Services.Metadata.ServiceTimeManagerApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CGC_GM_BE.Services.ServiceTimeManagerApi.Controllers
{
    [RoutePrefix("api/Reportes")]
    public class ReportesController : ApiController, IReportesControllerApi
    {
        [HttpGet]
        [Route("ReporteBoletasFechas/{fechaEntrada}/{fechaSalida}")]
        public _Resultado<List<RptBoletas>> ReporteBoletasFechas(string fechaEntrada, string fechaSalida)
        {
            return ReportesBL.ReporteBoletas(fechaEntrada, fechaSalida);
        }
    }
}
