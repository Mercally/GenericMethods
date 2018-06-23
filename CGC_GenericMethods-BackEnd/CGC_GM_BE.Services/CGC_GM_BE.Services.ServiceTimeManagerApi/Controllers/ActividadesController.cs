using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using CGC_GM_BE.Common.Entities;
using CGC_GM_BE.Business;
using CGC_GM_BE.Services.Metadata.ServiceTimeManagerApi;

namespace CGC_GM_BE.Services.ServiceTimeManagerApi.Controllers
{
    [RoutePrefix("api/Actividades")]
    public class ActividadesController : ApiController, IActividadesControllerApi
    {
        [HttpGet]
        [Route("ActividadesBoleta/{BoletaId}")]
        public List<Actividad> ConsultarActividadesPorBoletaId(int BoletaId)
        {
            return ActividadesBL.ConsultarActividadesPorBoletaId(BoletaId);
        }

        [HttpGet]
        [Route("{ActiviadId}")]
        public Actividad ConsultarActividadPorId(int ActividadId)
        {
            return ActividadesBL.ConsultarActividadPorActividadId(ActividadId);
        }

        [HttpDelete]
        [Route("{ActividadId}")]
        public bool EliminarActividad(int ActividadId)
        {
            return ActividadesBL.EliminarActividadPorActividadId(ActividadId);
        }

        [HttpPost]
        public int InsertarActividad(Actividad Actividad)
        {
            return ActividadesBL.InsertarActividad(Actividad);
        }

        [HttpPut]
        public bool ModificarActividad(Actividad Actividad)
        {
            return ActividadesBL.ModificarActividad(Actividad);
        }
    }
}
