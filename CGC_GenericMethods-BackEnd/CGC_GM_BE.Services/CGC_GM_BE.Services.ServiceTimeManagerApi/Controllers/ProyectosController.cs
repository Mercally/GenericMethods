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
    [RoutePrefix("api/Proyectos")]
    public class ProyectosController : ApiController, IProyectosControllerApi
    {
        [HttpGet]
        [Route("{ProyectoId}")]
        public Proyecto ConsultarProyectoPorId(int ProyectoId)
        {
            return ProyectosBL.ConsultarProyectoPorProyectoId(ProyectoId);
        }

        [HttpDelete]
        [Route("{ProyectoId}")]
        public bool EliminarProyecto(int ProyectoId)
        {
            return ProyectosBL.EliminarProyectoPorProyectoId(ProyectoId);
        }

        [HttpPost]
        public int InsertarProyecto(Proyecto Proyecto)
        {
            return ProyectosBL.InsertarProyecto(Proyecto);
        }

        [HttpPut]
        public bool ModificarProyecto(Proyecto Proyecto)
        {
            return ProyectosBL.ModificarProyecto(Proyecto);
        }
    }
}
