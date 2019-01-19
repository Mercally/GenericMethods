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
    [RoutePrefix("api/Proyectos")]
    public class ProyectosController : ApiController, IProyectosControllerApi
    {
        [HttpGet]
        public _Resultado<List<Proyecto>> ConsultarProyectos(bool soloActivos = true)
        {
            return ProyectosBL.ConsultarProyectos(soloActivos);
        }

        [HttpGet]
        [Route("{ProyectoId}")]
        public _Resultado<Proyecto> ConsultarProyectoPorId(int ProyectoId)
        {
            return ProyectosBL.ConsultarProyectoPorProyectoId(ProyectoId);
        }

        [HttpDelete]
        [Route("{ProyectoId}")]
        public _Resultado<bool> EliminarProyecto(int ProyectoId)
        {
            return ProyectosBL.EliminarProyectoPorProyectoId(ProyectoId);
        }

        [HttpPost]
        public _Resultado<int> InsertarProyecto(Proyecto Proyecto)
        {
            return ProyectosBL.InsertarProyecto(Proyecto);
        }

        [HttpPut]
        public _Resultado<bool> ModificarProyecto(Proyecto Proyecto)
        {
            return ProyectosBL.ModificarProyecto(Proyecto);
        }
    }
}
