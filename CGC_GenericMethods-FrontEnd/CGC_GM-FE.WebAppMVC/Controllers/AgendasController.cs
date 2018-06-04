using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CGC_GM_FE.Models;
using CGC_GM_FE.WebApiRestClient.Services.ServiceAgendaApi;

namespace CGC_GM_FE.WebAppMVC.Controllers
{
    public class AgendasController : Controller
    {
        AgendasControllerApi AgendaApi = new AgendasControllerApi();
        TareasControllerApi TareasApi = new TareasControllerApi();

        // GET: Agendas
        public ActionResult Index()
        {
            var Lista = AgendaApi.ObtenerAgendas();

            return View(Lista);
        }

        // GET: Agendas
        [HttpPost]
        public ActionResult Paginacion(int NumeroPagina, int TamanoPagina, string Filtro, string Valor)
        {
            var Lista = AgendaApi.ObtenerAgendasPaginadas(NumeroPagina, TamanoPagina, Filtro, Valor);

            return View(Lista);
        }

        // GET: Agendas/id
        public ActionResult Detalle(int id)
        {
            var Agenda = AgendaApi.ObtenerAgendaPorId(id);

            return View(Agenda);
        }

        // GET: Agendas/Nuevo
        public ActionResult Nuevo()
        {
            return View();
        }

        // POST: Agendas/Nuevo
        [HttpPost]
        public ActionResult Nuevo(Agenda obj)
        {
            var AgendaId = AgendaApi.InsertarAgenda(obj);

            if (AgendaId > 0)
            {
                return RedirectToAction("Detalle", new { id = AgendaId });
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Ocurrió un error al crear la nueva agenda.");
                return View(obj);
            }
        }

        // GET: Agendas/Modificar/{id}
        public ActionResult Modificar(int id)
        {
            var Agenda = AgendaApi.ObtenerAgendaPorId(id);

            return View(Agenda);
        }

        // POST: Agendas/Modificar
        [HttpPost]
        public ActionResult Modificar(Agenda obj)
        {
            var Cambios = AgendaApi.ModificarAgenda(obj);

            if (Cambios)
            {
                return RedirectToAction("Detalle", new { id = obj.Id });
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Ocurrió un error al modificar la agenda.");
                return View(obj);
            }
        }

        // GET: Agendas/Eliminar/{id}
        public ActionResult Eliminar(int id)
        {
            var Agenda = AgendaApi.ObtenerAgendaPorId(id);

            return View(Agenda);
        }

        // POST: Agendas/Eliminar
        [HttpPost]
        public ActionResult Eliminar(Agenda obj)
        {
            var Cambios = AgendaApi.EliminarAgenda(obj.Id);

            if (Cambios)
            {
                return RedirectToAction("Index");
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Ocurrió un error al eliminar la agenda.");
                return View(obj);
            }
        }

        // GET: Agendas/Tareas/{id} id=agendaId
        public ActionResult Tareas(int id)
        {
            return RedirectToAction("Index", "Tareas", new { id = id });
        }
    }
}