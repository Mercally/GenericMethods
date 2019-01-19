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
            var ListCliente = WebApiProvider.ClientesApi.ConsultarClientes().Resultado;
            return View(ListCliente);
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            Cliente Cliente = WebApiProvider.ClientesApi.ConsultarClientePorId(id).Resultado;
            if (Cliente != null)
            {
                Cliente.TipoFormulario = TipoFormularioEnum.Detalle;
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
            Cliente.Id = WebApiProvider.ClientesApi.InsertarCliente(Cliente).Resultado;

            bool Exito = Cliente.Id > 0;

            return Json(JsonResponse.JResponse(Exito, redirects:
             new Redirects(Url.Action("Details", new { id = Cliente.Id }), "Detalle")));
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            Cliente Cliente = WebApiProvider.ClientesApi.ConsultarClientePorId(id).Resultado;
            Cliente.TipoFormulario = TipoFormularioEnum.Editar;

            if (Cliente != null)
            {
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
            bool Exito = WebApiProvider.ClientesApi.ModificarCliente(Cliente).Resultado;

            return Json(JsonResponse.JResponse(Exito, redirects: 
             new Redirects(Url.Action("Details", new { id = Cliente.Id }), "Detalle")));
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            bool Exito = WebApiProvider.ClientesApi.EliminarCliente(id).Resultado;

            return Json(JsonResponse.JResponse(Exito, redirects:
             new Redirects(Url.Action("Index"), "Clientes")));
        }
    }
}