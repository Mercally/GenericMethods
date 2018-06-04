using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using CGC_GM_FE.Models;
using CGC_GM_FE.WebApiRestClient.Metadata.ServiceCatalogoApi;

namespace CGC_GM_FE.WebApiRestClient.Services.ServiceCatalogoApi
{
    public class CatalogosControllerApi : ICatalogosControllerApi
    {
        private string ApiUri
        {
            get
            {
                return ConfigurationManager.AppSettings["ServiceCatalogoApiUri"];
            }
        }

        public Catalogo ObtenerCatalogoPorId(int id)
        {
            var Respuesta = GenericHelper
                .Request<Catalogo>(
                Url: $"{ApiUri}/Catalogos/{id}",
                Method: HttpMethodEnum.Get
                );

            return Respuesta;
        }

        public List<Catalogo> ObtenerCatalogo(string Tabla, string Campo)
        {
            var Respuesta = GenericHelper
                .Request<List<Catalogo>>(
                Url: $"{ApiUri}/Catalogos/Filtro/{Tabla}/{Campo}",
                Method: HttpMethodEnum.Get
                );

            return Respuesta;
        }
    }
}
