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
    [RoutePrefix("api/Agendas")]
    public class AgendasController : ApiController, IAgendasControllerApi
    {
        Agenda_BL AgendaBLC = new Agenda_BL();

        [HttpPost]
        public int InsertarAgenda(Agenda obj)
        {
            return AgendaBLC.Insertar(obj);
        }

        [HttpGet]
        public List<Agenda> ObtenerAgendas()
        {
            return AgendaBLC.ConsultaGenerica();
        }

        [HttpGet]
        [Route("FiltroAgenda/{id}")]
        public Agenda ObtenerAgendaPorId(int id)
        {
            return AgendaBLC.ConsultaPorId(id);
        }

        [HttpPut]
        public bool ModificarAgenda(Agenda obj)
        {
            return AgendaBLC.Modificar(obj);
        }

        [HttpDelete]
        public bool EliminarAgenda(int id)
        {
            return AgendaBLC.Eliminar(id);
        }
    }
}
