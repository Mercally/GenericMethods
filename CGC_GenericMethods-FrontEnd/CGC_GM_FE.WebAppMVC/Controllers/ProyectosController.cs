using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CGC_GM_FE.Common.Models;
using CGC_GM_FE.WebApiRestClient.Services;
using CGC_GM_FE.WebAppMVC.Models.Utilities;

namespace CGC_GM_FE.WebAppMVC.Controllers
{
    public class ProyectosController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            var ListProyecto = WebApiProvider.ProyectosApi.ConsultarProyectos(false).Resultado;
            return View(ListProyecto);
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            var ResultadoApi = WebApiProvider.ProyectosApi.ConsultarProyectoPorId(id);
            if (ResultadoApi.EsCorrecto)
            {
                var Proyecto = ResultadoApi.Resultado;

                Proyecto.TipoFormulario = TipoFormularioEnum.Detalle;
                return View("Proyecto", Proyecto);
            }
            else
            {
                // Alerta de error
                return RedirectToAction("Index");
            }
        }

        [HttpGet]
        public ActionResult Create()
        {
            Proyecto Proyecto = new Proyecto(TipoFormularioEnum.Crear);
            return View("Proyecto", Proyecto);
        }

        [HttpPost]
        public ActionResult Create(Proyecto Proyecto)
        {
            Proyecto.EsActivo = true;
            Proyecto.FechaRegistro = DateTime.Now;

            var ResultadoApi = WebApiProvider.ProyectosApi.InsertarProyecto(Proyecto);

            if (ResultadoApi.EsCorrecto)
            {
                Proyecto.Id = ResultadoApi.Resultado;
            }

            return Json(JsonResponse.JResponse(ResultadoApi, redirects:
                 new Redirects(Url.Action("Details", new { id = Proyecto.Id }), "Detalle")));
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var ResultadoApi = WebApiProvider.ProyectosApi.ConsultarProyectoPorId(id);
            if (ResultadoApi.EsCorrecto)
            {
                var Proyecto = ResultadoApi.Resultado;

                Proyecto.TipoFormulario = TipoFormularioEnum.Editar;
                return View("Proyecto", Proyecto);
            }
            else
            {
                // Alerta de error
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        public ActionResult Edit(Proyecto Proyecto)
        {
            var ResultadoApi = WebApiProvider.ProyectosApi.ModificarProyecto(Proyecto);

            return Json(JsonResponse.JResponse(ResultadoApi, redirects:
                new Redirects(Url.Action("Details", new { id = Proyecto.Id }), "Detalle")));
        }

        [HttpGet]
        public ActionResult PartialDelete(int id)
        {
            var ResultadoApi = WebApiProvider.ProyectosApi.ConsultarProyectoPorId(id);
            if (ResultadoApi.EsCorrecto)
            {
                var Proyecto = ResultadoApi.Resultado;

                Proyecto.TipoFormulario = TipoFormularioEnum.Eliminar;
                return View("Proyecto", Proyecto);
            }
            else
            {
                // Alerta de error
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            var ResultadoApi = WebApiProvider.ProyectosApi.EliminarProyecto(id);

            return Json(JsonResponse.JResponse(ResultadoApi, redirects:
                new Redirects(Url.Action("Details"), "Detalle")));
        }
    }
}