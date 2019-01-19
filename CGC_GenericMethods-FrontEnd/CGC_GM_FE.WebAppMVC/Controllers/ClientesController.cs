using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CGC_GM_FE.Common.Models;
using CGC_GM_FE.WebAppMVC.Models.Utilities;
using CGC_GM_FE.WebApiRestClient.Services;

namespace CGC_GM_FE.WebAppMVC.Controllers
{
    public class ClientesController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            var ListCliente = WebApiProvider.ClientesApi.ConsultarClientes(false).Resultado;
            return View(ListCliente);
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            var ResultadoApi = WebApiProvider.ClientesApi.ConsultarClientePorId(id);
            if (ResultadoApi.EsCorrecto)
            {
                var Cliente = ResultadoApi.Resultado;

                Cliente.TipoFormulario = TipoFormularioEnum.Editar;
                return View("Cliente", Cliente);
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
            var Model = new Cliente(TipoFormularioEnum.Crear);
            return View("Cliente", Model);
        }

        [HttpPost]
        public ActionResult Create(Cliente Cliente)
        {
            var ResultadoApi = WebApiProvider.ClientesApi.InsertarCliente(Cliente);

            if (ResultadoApi.EsCorrecto)
            {
                Cliente.Id = ResultadoApi.Resultado;
            }

            return Json(JsonResponse.JResponse(ResultadoApi, redirects:
             new Redirects(Url.Action("Details", new { id = Cliente.Id }), "Detalle")));
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var ResultadoApi = WebApiProvider.ClientesApi.ConsultarClientePorId(id);
            if (ResultadoApi.EsCorrecto)
            {
                var Cliente = ResultadoApi.Resultado;

                Cliente.TipoFormulario = TipoFormularioEnum.Editar;
                return View("Cliente", Cliente);
            }
            else
            {
                // Alerta de error
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        public ActionResult Edit(Cliente Cliente)
        {
            var ResultadoApi = WebApiProvider.ClientesApi.ModificarCliente(Cliente);

            return Json(JsonResponse.JResponse(ResultadoApi, redirects: 
             new Redirects(Url.Action("Details", new { id = Cliente.Id }), "Detalle")));
        }

        [HttpGet]
        public ActionResult PartialDelete(int id)
        {
            var ResultadoApi = WebApiProvider.ClientesApi.ConsultarClientePorId(id);
            if (ResultadoApi.EsCorrecto)
            {
                var Cliente = ResultadoApi.Resultado;

                Cliente.TipoFormulario = TipoFormularioEnum.Eliminar;
                return View("Cliente", Cliente);
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
            var ResultadoApi = WebApiProvider.ClientesApi.EliminarCliente(id);

            return Json(JsonResponse.JResponse(ResultadoApi, redirects:
             new Redirects(Url.Action("Index"), "Clientes")));
        }
    }
}