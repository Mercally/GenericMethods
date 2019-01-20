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
    public class ActividadesController : Controller
    {
        // GET: Index/id:int -> boletaId
        [HttpGet]
        public ActionResult Index(int id)
        {
            var ResultadoApi = WebApiProvider.ActividadesApi.ConsultarActividadesPorBoletaId(id);
            return View(ResultadoApi);
        }

        // GET: Index/id:int -> actividadId
        [HttpGet]
        public ActionResult Details(int id)
        {
            var ResultadoApi = WebApiProvider.ActividadesApi.ConsultarActividadPorId(id);

            if (ResultadoApi.EsCorrecto)
            {
                CargarListas(ResultadoApi);

                ResultadoApi.Resultado.TipoFormulario = TipoFormularioEnum.Detalle;
            }

            return View("Actividad", ResultadoApi);
        }

        // GET: Create/id:int -> boletaId
        [HttpGet]
        public ActionResult Create(int id)
        {
            var ResultadoApi = new _Resultado<Actividad>() {
                EsCorrecto = true,
                ListaErrores = new List<Exception>(),
                Resultado = new Actividad() { BoletaId = id, FechaActividad = DateTime.Now }
            };

            CargarListas(ResultadoApi);

            ResultadoApi.Resultado.TipoFormulario = TipoFormularioEnum.Crear;

            return View("Actividad", ResultadoApi);
        }

        [HttpPost]
        public ActionResult Create(_Resultado<Actividad> Actividad)
        {
            Actividad.Resultado.FechaRegistro = DateTime.Now;
            Actividad.Resultado.EsActivo = true;
            Actividad.Resultado.Id = WebApiProvider.ActividadesApi.InsertarActividad(Actividad.Resultado).Resultado;

            if (Actividad.Resultado.Id > 0)
            {
                ModelState.Clear();
                return RedirectToAction("Create", new { id = Actividad.Resultado.BoletaId });
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Ocurrió un error al crear la actividad");
                return RedirectToAction("Create", new { id = Actividad.Resultado.BoletaId });
            }
        }

        // GET: Index/id:int -> actividadId
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var ResultadoApi = WebApiProvider.ActividadesApi.ConsultarActividadPorId(id);
            
            if (ResultadoApi.EsCorrecto)
            {
                CargarListas(ResultadoApi);

                ResultadoApi.Resultado.TipoFormulario = TipoFormularioEnum.Editar;
            }

            return View("Actividad", ResultadoApi);
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
            var ResultadoApi = WebApiProvider.ActividadesApi.EliminarActividad(id);

            return Json(JsonResponse.JResponse(ResultadoApi, redirects:
            new Redirects(Url.Action("Index"), "Actividades")));
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

        private void CargarListas(_Resultado<Actividad> ResultadoApi)
        {
            var ListEstadoActividad = WebApiProvider.CatalogosApi.ConsultarCatalogoPorTabla("EstadoVisita");
            ViewBag.ListEstadoActividad = ListEstadoActividad.Resultado.Select(c => new DropDownList(c.Nombre, c.Id)).SelectList();
            ViewBag.ListActividades = WebApiProvider.ActividadesApi.ConsultarActividadesPorBoletaId(ResultadoApi.Resultado.BoletaId);
        }
    }
}