using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using CGC_GM_BE.Services.Metadata.ServiceSeguridadApi;
using CGC_GM_BE.Common.Entities;
using CGC_GM_BE.Business;

namespace CGC_GM_BE.Services.ServiceSeguridadApi.Controllers
{
    [RoutePrefix("api/Usuarios")]
    public class UsuariosController : ApiController, IUsuariosControllerApi
    {
        Usuario_BL UsuarioBLC = new Usuario_BL();

        [HttpGet]
        public List<Usuario> ObtenerUsuarios()
        {
            return UsuarioBLC.ConsultaGenerica();
        }
    }
}
