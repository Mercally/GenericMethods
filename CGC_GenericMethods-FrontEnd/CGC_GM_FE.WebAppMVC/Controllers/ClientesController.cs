using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CGC_GM_FE.Common.Models;
using CGC_GM_FE.Common.Utilities;
using CGC_GM_FE.WebApiRestClient.Services;

namespace CGC_GM_FE.WebAppMVC.Controllers
{
    public class ClientesController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            var ListCliente = WebApiProvider.ClientesApi.ConsultarClientes();
            return View(ListCliente);
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            Cliente Cliente = WebApiProvider.ClientesApi.ConsultarClientePorId(id);
            if (Cliente != null)
            {
                return View(Cliente);
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
        public ActionResult Create(Cliente Cliente)
        {
            Cliente.EsActivo = true;
            Cliente.FechaRegistro = DateTime.Now;

            Cliente.Id = WebApiProvider.ClientesApi.InsertarCliente(Cliente);
            if (Cliente.Id > 0)
            {
                return RedirectToAction("Details", new { id = Cliente.Id });
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Ocurrió un error al ingresar el cliente");
                return View();
            }
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            Cliente Cliente = WebApiProvider.ClientesApi.ConsultarClientePorId(id);
            if (Cliente != null)
            {
                return View(Cliente);
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
            bool Success = WebApiProvider.ClientesApi.ModificarCliente(Cliente);
            if (Success)
            {
                return RedirectToAction("Details", new { id = Cliente.Id });
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Ocurrió un error al modificar el cliente");
                return View();
            }
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            bool IsDelete = WebApiProvider.ClientesApi.EliminarCliente(id);

            JsonResponse JsonResponse = new JsonResponse()
            {
                IsSuccess = IsDelete
            };
            return Json(JsonResponse);
        }
    }
}