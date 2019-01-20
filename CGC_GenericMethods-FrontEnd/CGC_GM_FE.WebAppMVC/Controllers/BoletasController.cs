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
    public class BoletasController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            var ListBoleta = WebApiProvider.BoletasApi.ConsultarBoletas().Resultado;
            return View(ListBoleta);
        }

        [HttpGet]
        public ActionResult Create()
        {
            CargarListados();

            Boleta Boleta = new Boleta(TipoFormularioEnum.Crear);
            return View("Boleta", Boleta);
        }

        [HttpPost]
        public ActionResult Create(Boleta Boleta)
        {
            Boleta.FechaRegistro = DateTime.Now;
            Boleta.EsActivo = true;
            Boleta.UsuarioId = 1; // Usuario en sesion

            var ResultadoApi = WebApiProvider.BoletasApi.InsertarBoleta(Boleta);

            if (ResultadoApi.EsCorrecto)
            {
                Boleta.Id = ResultadoApi.Resultado;
            }

            return Json(JsonResponse.JResponse(ResultadoApi, redirects:
             new Redirects(Url.Action("Details", new { id = Boleta.Id }), "Detalle")));
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            Boleta Boleta = WebApiProvider.BoletasApi.ConsultarBoletaPorId(id).Resultado;

            if (Boleta != null)
            {
                CargarListados();

                Boleta.TipoFormulario = TipoFormularioEnum.Editar;

                return View("Boleta", Boleta);
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

            var ResultadoApi = WebApiProvider.BoletasApi.ModificarBoleta(Boleta);

            if (ResultadoApi.Resultado)
            {
                return Json(JsonResponse.JResponse(ResultadoApi, redirects:
                    new Redirects(Url.Action("Details", new { id = Boleta.Id }), "Detalle")));
            }
            else
            {
                CargarListados();

                ModelState.AddModelError(string.Empty, "Ocurrió un error al modificar la boleta");
                return View("Boleta");
            }
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            Boleta Boleta = WebApiProvider.BoletasApi.ConsultarBoletaPorId(id).Resultado;

            if (Boleta != null)
            {
                CargarListados();

                Boleta.TipoFormulario = TipoFormularioEnum.Detalle;

                return View("Boleta", Boleta);
            }
            else
            {
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            var ResultadoApi = WebApiProvider.BoletasApi.EliminarBoleta(id);

            return Json(JsonResponse.JResponse(ResultadoApi, redirects:
             new Redirects(Url.Action("Index"), "Boletas")));
        }

        private void CargarListados()
        {
            var ListCliente = WebApiProvider.ClientesApi.ConsultarClientes(true);
            ViewBag.ListCliente = ListCliente.Resultado.Select(c => new DropDownList(c.Nombre, c.Id)).SelectList();

            var ListProyecto = WebApiProvider.ProyectosApi.ConsultarProyectos(true);
            ViewBag.ListProyecto = ListProyecto.Resultado.Select(p => new DropDownList(p.Nombre, p.Id)).SelectList();

            var ListTiempoInvertido = WebApiProvider.CatalogosApi.ConsultarCatalogoPorTabla("TiempoInvertido");
            ViewBag.ListTiempoInvertido = ListTiempoInvertido.Resultado.Select(c => new DropDownList(c.Nombre, c.Id)).SelectList();

            var ListDepartamento = WebApiProvider.CatalogosApi.ConsultarCatalogoPorTabla("Departamento");
            ViewBag.Departamento = ListDepartamento.Resultado.Select(c => new DropDownList(c.Nombre, c.Id)).SelectList();
        }
    }
}