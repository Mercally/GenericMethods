using System.Collections.Generic;
using System.Configuration;
using CGC_GM_FE.WebApiRestClient.Metadata.ServiceSeguridadApi;
using CGC_GM_FE.Models;

namespace CGC_GM_FE.WebApiRestClient.Services.ServiceSeguridadApi
{
    public class UsuariosControllerApi : IUsuariosControllerApi
    {
        private string ApiUri
        {
            get
            {
                return ConfigurationManager.AppSettings["ServiceSeguridadApiUri"];
            }
        }

        public List<Usuario> ObtenerUsuarios()
        {
            var Respuesta = GenericHelper
                .Request<List<Usuario>>(
                Url: $"{ApiUri}/Usuarios",
                Method: HttpMethodEnum.Get
                );

            return Respuesta;
        }
    }
}
