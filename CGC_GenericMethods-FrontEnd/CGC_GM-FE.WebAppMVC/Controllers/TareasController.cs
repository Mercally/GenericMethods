using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CGC_GM_FE.Models;
using CGC_GM_FE.WebApiRestClient.Services.ServiceAgendaApi;

namespace CGC_GM_FE.WebAppMVC.Controllers
{
    public class TareasController : Controller
    {
        TareasControllerApi TareasApi = new TareasControllerApi();

        // GET: Tareas/{id} id=agendaId
        public ActionResult Index(int id)
        {
            var Lista = TareasApi.ObtenerTareas();

            return View(Lista);
        }

        // GET: Tareas/{id}
        public ActionResult Detalle(int id)
        {
            var Tarea = TareasApi.ObtenerTareaPorId(id);

            return View(Tarea);
        }

        // GET: Tareas/Nuevo/id
        public ActionResult Nuevo(int id)
        {
            return View();
        }

        // POST: Tareas/Nuevo
        [HttpPost]
        public ActionResult Nuevo(Tarea obj)
        {
            var AgendaId = TareasApi.InsertarTarea(obj);

            if (AgendaId > 0)
            {
                return RedirectToAction("Detalle", new { id = AgendaId });
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