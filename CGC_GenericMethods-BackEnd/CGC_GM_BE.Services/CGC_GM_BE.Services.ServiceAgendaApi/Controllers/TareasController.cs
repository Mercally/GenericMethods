using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using CGC_GM_BE.Services.Metadata.ServiceAgendaApi;
using CGC_GM_BE.Common.Entities;
using CGC_GM_BE.Business;


namespace CGC_GM_BE.Services.ServiceAgendaApi.Controllers
{
    [RoutePrefix("api/Tareas")]
    public class TareasController : ApiController, ITareasControllerApi
    {
        Tarea_BL TareaBLC = new Tarea_BL();

        [HttpGet]
        public List<Tarea> ObtenerTareas()
        {
            return TareaBLC.ConsultaGenerica();
        }

        [HttpGet]
        [Route("FiltroTareaAgenda/{id}")]
        public List<Tarea> ObtenerTareasPorAgendaId(int id)
        {
            return TareaBLC.ConsultaPorAgendaId(id);
        }

        [HttpGet]
        [Route("FiltroTarea/{id}")]
        public Tarea ObtenerTareaPorId(int id)
        {
            return TareaBLC.ConsultaPorId(id);
        }

        [HttpPost]
        public int InsertarTarea(Tarea obj)
        {
            return TareaBLC.Insertar(obj);
        }

        [HttpPut]
        public bool ModificarTarea(Tarea obj)
        {
            return TareaBLC.Modificar(obj);
        }

        [HttpDelete]
        public bool EliminarTarea(int id)
        {
            return TareaBLC.Eliminar(id);
        }
    }
}
