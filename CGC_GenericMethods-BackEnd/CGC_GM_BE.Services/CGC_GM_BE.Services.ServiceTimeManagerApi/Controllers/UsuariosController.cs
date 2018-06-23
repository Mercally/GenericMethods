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
    [RoutePrefix("api/Usuarios")]
    public class UsuariosController : ApiController, IUsuariosControllerApi
    {
        [HttpGet]
        [Route("{UsuarioId}")]
        public Usuario ConsultarUsuarioPorId(int UsuarioId)
        {
            return UsuariosBL.ConsultarUsuarioPorUsuarioId(UsuarioId);
        }

        [HttpDelete]
        [Route("{UsuarioId}")]
        public bool EliminarUsuario(int UsuarioId)
        {
            return UsuariosBL.EliminarUsuarioPorUsuarioId(UsuarioId);
        }

        [HttpPost]
        public int InsertarUsuario(Usuario Usuario)
        {
            return UsuariosBL.InsertarUsuario(Usuario);
        }

        [HttpPut]
        public bool ModificarUsuario(Usuario Usuario)
        {
            return UsuariosBL.ModificarUsuario(Usuario);
        }
    }
}
