﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CGC_GM_FE.Common.Models;
using CGC_GM_FE.WebApiRestClient.Services;
using CGC_GM_FE.WebAppMVC.Models.Utilities;

namespace CGC_GM_FE.WebAppMVC.Controllers
{
    public class BoletasController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            var ListBoleta = WebApiProvider.BoletasApi.ConsultarBoletas().Resultado;
            return View(ListBoleta);
        }

        [HttpGet]
        public ActionResult IndexV2()
        {
            var ListBoleta = WebApiProvider.BoletasApi.ConsultarBoletasV2();
            return View(ListBoleta);
        }

        [HttpGet]
        public ActionResult Create()
        {
            var ListCliente = WebApiProvider.ClientesApi.ConsultarClientes();
            ViewBag.ListCliente = ListCliente.Resultado.Select(c => new DropDownList(c.Nombre, c.Id)).SelectList();

            var ListProyecto = WebApiProvider.ProyectosApi.ConsultarProyectos();
            ViewBag.ListProyecto = ListProyecto.Resultado.Select(p => new DropDownList(p.Nombre, p.Id)).SelectList();

            var ListTiempoInvertido = WebApiProvider.CatalogosApi.ConsultarCatalogoPorTabla("TiempoInvertido");
            ViewBag.ListTiempoInvertido = ListTiempoInvertido.Resultado.Select(c => new DropDownList(c.Nombre, c.Id)).SelectList();

            var ListDepartamento = WebApiProvider.CatalogosApi.ConsultarCatalogoPorTabla("Departamento");
            ViewBag.Departamento = ListDepartamento.Resultado.Select(c => new DropDownList(c.Nombre, c.Id)).SelectList();

            return View();
        }

        [HttpPost]
        public ActionResult Create(Boleta Boleta)
        {
            Boleta.FechaRegistro = DateTime.Now;
            Boleta.EsActivo = true;
            Boleta.UsuarioId = 1; // Usuario en sesion

            Boleta.Id = WebApiProvider.BoletasApi.InsertarBoleta(Boleta).Resultado;

            if (Boleta.Id > 0)
            {
                return RedirectToAction("Create", "Actividad", new { id = Boleta.Id });
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Ocurrió un error al ingresar la boleta");
                return View(Boleta);
            }
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            Boleta Boleta = WebApiProvider.BoletasApi.ConsultarBoletaPorId(id).Resultado;

            if (Boleta != null)
            {
                var ListCliente = WebApiProvider.ClientesApi.ConsultarClientes();
                ViewBag.ListCliente = ListCliente.Resultado.Select(c => new DropDownList(c.Nombre, c.Id)).SelectList();

                var ListProyecto = WebApiProvider.ProyectosApi.ConsultarProyectos();
                ViewBag.ListProyecto = ListProyecto.Resultado.Select(p => new DropDownList(p.Nombre, p.Id)).SelectList();

                var ListTiempoInvertido = WebApiProvider.CatalogosApi.ConsultarCatalogoPorTabla("TiempoInvertido");
                ViewBag.ListTiempoInvertido = ListTiempoInvertido.Resultado.Select(c => new DropDownList(c.Nombre, c.Id)).SelectList();

                var ListDepartamento = WebApiProvider.CatalogosApi.ConsultarCatalogoPorTabla("Departamento");
                ViewBag.Departamento = ListDepartamento.Resultado.Select(c => new DropDownList(c.Nombre, c.Id)).SelectList();

                return View(Boleta);
            }
            else
            {
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        public ActionResult Edit(Boleta Boleta)
        {
            Boleta.FechaRegistro = DateTime.Now;
            Boleta.UsuarioId = 1; // Usuario actual

            bool Modificado = WebApiProvider.BoletasApi.ModificarBoleta(Boleta).Resultado;

            if (Modificado)
            {
                return RedirectToAction("Details", new { id = Boleta.Id });
            }
            else
            {
                var ListCliente = WebApiProvider.ClientesApi.ConsultarClientes();
                ViewBag.ListCliente = ListCliente.Resultado.Select(c => new DropDownList(c.Nombre, c.Id)).SelectList();

                var ListProyecto = WebApiProvider.ProyectosApi.ConsultarProyectos();
                ViewBag.ListProyecto = ListProyecto.Resultado.Select(p => new DropDownList(p.Nombre, p.Id)).SelectList();

                var ListTiempoInvertido = WebApiProvider.CatalogosApi.ConsultarCatalogoPorTabla("TiempoInvertido");
                ViewBag.ListTiempoInvertido = ListTiempoInvertido.Resultado.Select(c => new DropDownList(c.Nombre, c.Id)).SelectList();

                var ListDepartamento = WebApiProvider.CatalogosApi.ConsultarCatalogoPorTabla("Departamento");
                ViewBag.Departamento = ListDepartamento.Resultado.Select(c => new DropDownList(c.Nombre, c.Id)).SelectList();

                ModelState.AddModelError(string.Empty, "Ocurrió un error al modificar la boleta");
                return View();
            }
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            Boleta Boleta = WebApiProvider.BoletasApi.ConsultarBoletaPorId(id).Resultado;

            if (Boleta != null)
            {
                var ListCliente = WebApiProvider.ClientesApi.ConsultarClientes();
                ViewBag.ListCliente = ListCliente.Resultado.Select(c => new DropDownList(c.Nombre, c.Id)).SelectList();

                var ListProyecto = WebApiProvider.ProyectosApi.ConsultarProyectos();
                ViewBag.ListProyecto = ListProyecto.Resultado.Select(p => new DropDownList(p.Nombre, p.Id)).SelectList();

                var ListTiempoInvertido = WebApiProvider.CatalogosApi.ConsultarCatalogoPorTabla("TiempoInvertido");
                ViewBag.ListTiempoInvertido = ListTiempoInvertido.Resultado.Select(c => new DropDownList(c.Nombre, c.Id)).SelectList();

                var ListDepartamento = WebApiProvider.CatalogosApi.ConsultarCatalogoPorTabla("Departamento");
                ViewBag.Departamento = ListDepartamento.Resultado.Select(c => new DropDownList(c.Nombre, c.Id)).SelectList();

                return View(Boleta);
            }
            else
            {
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            bool Exito = WebApiProvider.BoletasApi.EliminarBoleta(id).Resultado;

            return Json(JsonResponse.JResponse(Exito, redirects:
            new Redirects(Url.Action("Index"), "Boletas")));
        }
    }
}