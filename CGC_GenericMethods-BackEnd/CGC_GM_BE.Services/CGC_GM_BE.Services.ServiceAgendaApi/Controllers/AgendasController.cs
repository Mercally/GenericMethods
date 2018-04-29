using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using CGC_GM_BE.Services.Metadata.ServiceAgendaApi;
using CGC_GM_BE.Business.Common;
using CGC_GM_BE.Common.Entities;

namespace CGC_GM_BE.Services.ServiceAgendaApi.Controllers
{
    [RoutePrefix("api/Agendas")]
    public class AgendasController : ApiController, IAgendasControllerApi
    {
        Agenda_BLC AgendaBLC = new Agenda_BLC();

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
        [Route("Filtro/{id}")]
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
        public bool Eliminar(int id)
        {
            return AgendaBLC.Eliminar(id);
        }
    }
}
