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
    public class ActividadesController : Controller
    {
        // GET: Index/id:int -> boletaId
        [HttpGet]
        public ActionResult Index(int id)
        {
            var ListActividad = WebApiProvider.ActividadesApi.ConsultarActividadesPorBoletaId(id).Resultado;

            return View(ListActividad);
        }

        // GET: Index/id:int -> actividadId
        [HttpGet]
        public ActionResult Details(int id)
        {
            Actividad Actividad = WebApiProvider.ActividadesApi.ConsultarActividadPorId(id).Resultado;
            return View(Actividad);
        }

        // GET: Create/id:int -> boletaId
        [HttpGet]
        public ActionResult Create(int id)
        {
            var ListEstadoActividad = WebApiProvider.CatalogosApi.ConsultarCatalogoPorTabla("EstadoVisita");
            ViewBag.ListEstadoActividad = ListEstadoActividad.Resultado.Select(c => new DropDownList(c.Nombre, c.Id)).SelectList();

            var ListActividades = WebApiProvider.ActividadesApi.ConsultarActividadesPorBoletaId(id);
            ViewBag.ListActividades = ListActividades.Resultado;

            Actividad model = new Actividad() { BoletaId = id };
            return View(model);
        }

        [HttpPost]
        public ActionResult Create(Actividad Actividad)
        {
            Actividad.FechaRegistro = DateTime.Now;
            Actividad.EsActivo = true;
            Actividad.Id = WebApiProvider.ActividadesApi.InsertarActividad(Actividad).Resultado;

            if (Actividad.Id > 0)
            {
                ModelState.Clear();
                return RedirectToAction("Create", new { id = Actividad.BoletaId });
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Ocurrió un error al crear la actividad");
                return RedirectToAction("Create", new { id = Actividad.BoletaId });
            }
        }

        // GET: Index/id:int -> actividadId
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var ListEstadoActividad = WebApiProvider.CatalogosApi.ConsultarCatalogoPorTabla("EstadoVisita");
            ViewBag.ListEstadoActividad = ListEstadoActividad.Resultado.Select(c => new DropDownList(c.Nombre, c.Id)).SelectList();

            Actividad model = WebApiProvider.ActividadesApi.ConsultarActividadPorId(id).Resultado;

            ViewBag.ListActividades = WebApiProvider.ActividadesApi.ConsultarActividadesPorBoletaId(model.BoletaId);

            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(Actividad Actividad)
        {
            bool EsActualizado = WebApiProvider.ActividadesApi.ModificarActividad(Actividad).Resultado;
            if (EsActualizado)
            {
                return RedirectToAction("Edit", new { id = Actividad.Id });
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Ocurrió un error al modificar la actividad");
                return RedirectToAction("Edit", new { id = Actividad.BoletaId });
            }
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            bool EsEliminado = WebApiProvider.ActividadesApi.EliminarActividad(id).Resultado;

            JsonResponse JsonResponse = new JsonResponse()
            {
                IsSuccess = EsEliminado
            };
            return Json(JsonResponse);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="descripcion"></param>
        /// <param name="fecha"></param>
        /// <param name="tiempo"></param>
        /// <returns></returns>
        private string CombineDescription(string descripcion, DateTime fecha, decimal tiempo)
        {
            return $"{descripcion} - {fecha.ToShortDateString()} - {tiempo.ToString()} H";
        }
    }
}