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
            Proyecto Proyecto = WebApiProvider.ProyectosApi.ConsultarProyectoPorId(id).Resultado;
            if (Proyecto != null)
            {
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

            Proyecto.Id = WebApiProvider.ProyectosApi.InsertarProyecto(Proyecto).Resultado;
            bool Exito = Proyecto.Id > 0;

            return Json(JsonResponse.JResponse(Exito, redirects:
                 new Redirects(Url.Action("Details", new { id = Proyecto.Id }), "Detalle")));
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            Proyecto Proyecto = WebApiProvider.ProyectosApi.ConsultarProyectoPorId(id).Resultado;
            if (Proyecto != null)
            {
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
            bool Exito = WebApiProvider.ProyectosApi.ModificarProyecto(Proyecto).Resultado;

            return Json(JsonResponse.JResponse(Exito, redirects:
                new Redirects(Url.Action("Details", new { id = Proyecto.Id }), "Detalle")));
        }

        [HttpGet]
        public ActionResult PartialDelete(int id)
        {
            Proyecto Proyecto = WebApiProvider.ProyectosApi.ConsultarProyectoPorId(id).Resultado;
            if (Proyecto != null)
            {
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
            bool Exito = WebApiProvider.ProyectosApi.EliminarProyecto(id).Resultado;

            return Json(JsonResponse.JResponse(Exito, redirects:
                new Redirects(Url.Action("Details"), "Detalle")));
        }
    }
}