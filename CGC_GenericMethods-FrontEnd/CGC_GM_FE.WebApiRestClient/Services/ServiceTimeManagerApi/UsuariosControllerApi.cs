using System.Collections.Generic;
using System.Configuration;
using CGC_GM_FE.Common.Models;
using CGC_GM_FE.WebApiRestClient.Metadata.ServiceTimeManagerApi;

namespace CGC_GM_FE.WebApiRestClient.Services.ServiceTimeManagerApi
{
    public class UsuariosControllerApi : IUsuariosControllerApi
    {
        private string ApiUri
        {
            get
            {
                return ConfigurationSettings.AppSettings["ServiceTimeManagerApi"] + "/Usuarios";
            }
        }

        public _Resultado<Usuario> ConsultarUsuarioPorId(int UsuarioId)
        {
            var Respuesta = GenericHelper
                .Request<Usuario>(
                Url: ApiUri,
                Method: HttpMethodEnum.HttpGet
                );

            return Respuesta;
        }

        public _Resultado<bool> EliminarUsuario(int UsuarioId)
        {
            var Respuesta = GenericHelper
                .Request<bool>(
                Url: $"{ApiUri}/{UsuarioId}",
                Method: HttpMethodEnum.HttpDelete
                );

            return Respuesta;
        }

        public _Resultado<int> InsertarUsuario(Usuario Usuario)
        {
            var Respuesta = GenericHelper
                .Request<int>(
                Url: ApiUri,
                Method: HttpMethodEnum.HttpPost_Json,
                Data: Usuario
                );

            return Respuesta;
        }

        public _Resultado<bool> ModificarUsuario(Usuario Usuario)
        {
            var Respuesta = GenericHelper
                .Request<bool>(
                Url: ApiUri,
                Method: HttpMethodEnum.HttpPut_Json,
                Data: Usuario
                );

            return Respuesta;
        }
    }
}
