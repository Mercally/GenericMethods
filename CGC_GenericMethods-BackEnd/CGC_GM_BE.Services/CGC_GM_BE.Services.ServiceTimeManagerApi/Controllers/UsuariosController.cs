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
        public _Resultado<Usuario> ConsultarUsuarioPorId(int UsuarioId)
        {
            return UsuariosBL.ConsultarUsuarioPorUsuarioId(UsuarioId);
        }

        [HttpDelete]
        [Route("{UsuarioId}")]
        public _Resultado<bool> EliminarUsuario(int UsuarioId)
        {
            return UsuariosBL.EliminarUsuarioPorUsuarioId(UsuarioId);
        }

        [HttpPost]
        public _Resultado<int> InsertarUsuario(Usuario Usuario)
        {
            return UsuariosBL.InsertarUsuario(Usuario);
        }

        [HttpPut]
        public _Resultado<bool> ModificarUsuario(Usuario Usuario)
        {
            return UsuariosBL.ModificarUsuario(Usuario);
        }
    }
}
