using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CGC_GM_FE.Models;
using CGC_GM_FE.WebApiRestClient.Services.ServiceAgendaApi;
using CGC_GM_FE.WebApiRestClient.Services.ServiceCatalogoApi;

namespace CGC_GM_FE.WebAppMVC.Controllers
{
    public class TareasController : Controller
    {
        TareasControllerApi TareasApi = new TareasControllerApi();
        AgendasControllerApi AgendasApi = new AgendasControllerApi();
        CatalogosControllerApi CatalogoApi = new CatalogosControllerApi();

        // GET: Tareas/{id} id=agendaId
        public ActionResult Index(int id)
        {
            var Lista = TareasApi.ObtenerTareasPorAgendaId(id);
            var Agenda = AgendasApi.ObtenerAgendaPorId(id);
            ViewBag.NombreAgenda = Agenda.Nombre;

            return View(Lista);
        }

        // GET: Tareas/{id}
        public ActionResult Detalle(int id)
        {
            var Tarea = TareasApi.ObtenerTareaPorId(id);

            return View(Tarea);
        }

        // GET: Tareas/Nuevo/id=AgendaId
        public ActionResult Nuevo(int id)
        {
            var Agenda = AgendasApi.ObtenerAgendaPorId(id);
            ViewBag.NombreAgenda = Agenda.Nombre;
            ViewBag.AgendaId = id;

            var Estados = CatalogoApi.ObtenerCatalogo("Tareas", "EstadoId");
            ViewBag.Estados = new SelectList(
                Estados.Select(x => new SelectListItem()
                {
                    Text = x.Valor,
                    Value = x.Id.ToString()
                }), "Value", "Text");

            return View();
        }

        // POST: Tareas/Nuevo
        [HttpPost]
        public ActionResult Nuevo(Tarea obj)
        {
            var TareaId = TareasApi.InsertarTarea(obj);

            if (TareaId > 0)
            {
                return RedirectToAction("Detalle", new { id = TareaId });
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Ocurrió un error al crear la nueva tarea.");
                return View(obj);
            }
        }

        // GET: Tareas/Modificar/{id}
        public ActionResult Modificar(int id)
        {
            var Tarea = TareasApi.ObtenerTareaPorId(id);

            var Estados = CatalogoApi.ObtenerCatalogo("Tareas", "EstadoId");
            ViewBag.Estados = new SelectList(
                Estados.Select(x => new SelectListItem()
                {
                    Text = x.Valor,
                    Value = x.Id.ToString()
                }), "Value", "Text", Tarea.EstadoId);

            return View(Tarea);
        }

        // POST: Tareas/Modificar
        [HttpPost]
        public ActionResult Modificar(Tarea obj)
        {
            var Cambios = TareasApi.ModificarTarea(obj);

            if (Cambios)
            {
                return RedirectToAction("Detalle", new { id = obj.Id });
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Ocurrió un error al modificar la tarea.");
                return View(obj);
            }
        }

        // GET: Tareas/Eliminar/{id}
        public ActionResult Eliminar(int id)
        {
            var Tarea = TareasApi.ObtenerTareaPorId(id);

            return View(Tarea);
        }

        // POST: Tareas/Eliminar
        [HttpPost]
        public ActionResult Eliminar(Tarea obj)
        {
            var Cambios = TareasApi.EliminarTarea(obj.Id);

            if (Cambios)
            {
                return RedirectToAction("Index", new { id = obj.AgendaId });
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Ocurrió un error al eliminar la tarea.");
                return View(obj);
            }
        }
    }
}