using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
                return System.Configuration.ConfigurationSettings.AppSettings["ServiceSeguridadApiUri"];
            }
        }

        public List<Usuario> ObtenerUsuarios()
        {
            var Respuesta = GenericHelper
                .Request<List<Usuario>>($"{ApiUri}/Usuarios", HttpMethodEnum.Get);

            return Respuesta;
        }
    }
}
