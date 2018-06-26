﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CGC_GM_FE.Common.Models;
using CGC_GM_FE.Common.Utilities;
using CGC_GM_FE.WebApiRestClient.Services;

namespace CGC_GM_FE.WebAppMVC.Controllers
{
    public class ProyectosController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            var ListProyecto = WebApiProvider.ProyectosApi.ConsultarProyectos();
            return View(ListProyecto);
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            Proyecto Proyecto = WebApiProvider.ProyectosApi.ConsultarProyectoPorId(id);
            if (Proyecto != null)
            {
                return View(Proyecto);
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
            return View();
        }

        [HttpPost]
        public ActionResult Create(Proyecto Proyecto)
        {
            Proyecto.EsActivo = true;
            Proyecto.FechaRegistro = DateTime.Now;

            Proyecto.Id = WebApiProvider.ProyectosApi.InsertarProyecto(Proyecto);
            if (Proyecto.Id > 0)
            {
                return RedirectToAction("Details", new { id = Proyecto.Id });
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Ocurrió un error al ingresar el proyecto");
                return View();
            }
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            Proyecto Proyecto = WebApiProvider.ProyectosApi.ConsultarProyectoPorId(id);
            if (Proyecto != null)
            {
                return View(Proyecto);
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
            bool Success = WebApiProvider.ProyectosApi.ModificarProyecto(Proyecto);
            if (Success)
            {
                return RedirectToAction("Details", new { id = Proyecto.Id });
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Ocurrió un error al modificar el proyecto");
                return View();
            }
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            bool IsDelete = WebApiProvider.ProyectosApi.EliminarProyecto(id);

            JsonResponse JsonResponse = new JsonResponse()
            {
                IsSuccess = IsDelete
            };
            return Json(JsonResponse);
        }
    }
}