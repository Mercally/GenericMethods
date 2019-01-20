using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CGC_GM_FE.Common.Models;
using CGC_GM_FE.WebApiRestClient.Services;

namespace CGC_GM_FE.WebAppMVC.Controllers
{
    public class ReportesController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Boletas(DateTime? fechaEntrada = null, DateTime? fechaSalida = null)
        {
            fechaEntrada = fechaEntrada ?? DateTime.Now;
            fechaSalida = fechaSalida ?? DateTime.Now;

            var ResultadoApi = WebApiProvider.ReportesApi.ReporteBoletasFechas(fechaEntrada.Value, fechaSalida.Value);

            return View(ResultadoApi);
        }

        [HttpGet]
        public ActionResult Actividades(DateTime? fechaEntrada = null, DateTime? fechaSalida = null)
        {
            fechaEntrada = fechaEntrada ?? DateTime.Now;
            fechaSalida = fechaSalida ?? DateTime.Now;

            var ResultadoApi = WebApiProvider.ReportesApi.ReporteBoletasFechas(fechaEntrada.Value, fechaSalida.Value);

            return View(ResultadoApi);
        }
    }
}