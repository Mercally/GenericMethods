using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using CGC_GM_BE.Common.Entities.Modelo;
using CGC_GM_BE.Business;
using CGC_GM_BE.Services.Metadata.ServiceTimeManagerApi;

namespace CGC_GM_BE.Services.ServiceTimeManagerApi.Controllers
{
    [RoutePrefix("api/Actividades")]
    public class ActividadesController : ApiController, IActividadesControllerApi
    {
        [HttpGet]
        [Route("ActividadesBoleta/{BoletaId}")]
        public _Resultado<List<Actividad>> ConsultarActividadesPorBoletaId(int BoletaId)
        {
            return ActividadesBL.ConsultarActividadesPorBoletaId(BoletaId);   
        }

        [HttpGet]
        [Route("{ActividadId}")]
        public _Resultado<Actividad> ConsultarActividadPorId(int ActividadId)
        {
            return ActividadesBL.ConsultarActividadPorActividadId(ActividadId);
        }

        [HttpDelete]
        [Route("{ActividadId}")]
        public _Resultado<bool> EliminarActividad(int ActividadId)
        {
            return ActividadesBL.EliminarActividadPorActividadId(ActividadId);
        }

        [HttpPost]
        public _Resultado<int> InsertarActividad(Actividad Actividad)
        {
            return ActividadesBL.InsertarActividad(Actividad);
        }

        [HttpPut]
        public _Resultado<bool> ModificarActividad(Actividad Actividad)
        {
            return ActividadesBL.ModificarActividad(Actividad);
        }
    }
}
