using System.Collections.Generic;
using System.Configuration;
using CGC_GM_FE.Common.Models;
using CGC_GM_FE.WebApiRestClient.Metadata.ServiceTimeManagerApi;

namespace CGC_GM_FE.WebApiRestClient.Services.ServiceTimeManagerApi
{
    public class CatalogosControllerApi : ICatalogosControllerApi
    {
        private string ApiUri
        {
            get
            {
                return ConfigurationSettings.AppSettings["ServiceTimeManagerApi"] + "/Catalogos";
            }
        }

        public _Resultado<List<Catalogo>> ConsultarCatalogoPorTabla(string Tabla)
        {
            var Respuesta = GenericHelper
                .Request<List<Catalogo>>(
                Url: $"{ApiUri}/{Tabla}",
                Method: HttpMethodEnum.HttpGet
                );

            return Respuesta;
        }

        public _Resultado<Catalogo> ConsultarCatalogoPorId(int CatalogoId, string Tabla)
        {
            var Respuesta = GenericHelper
                .Request<Catalogo>(
                Url: $"{ApiUri}/{CatalogoId}/{Tabla}",
                Method: HttpMethodEnum.HttpGet
                );

            return Respuesta;
        }

        public _Resultado<bool> EliminarCatalogo(int CatalogoId, string Tabla)
        {
            var Respuesta = GenericHelper
                .Request<bool>(
                Url: $"{ApiUri}/{CatalogoId}/{Tabla}",
                Method: HttpMethodEnum.HttpDelete
                );

            return Respuesta;
        }

        public _Resultado<int> InsertarCatalogo(Catalogo Catalogo, string Tabla)
        {
            var Respuesta = GenericHelper
                .Request<int>(
                Url: $"{ApiUri}/{Tabla}",
                Method: HttpMethodEnum.HttpPost_Json,
                Data: Catalogo
                );

            return Respuesta;
        }

        public _Resultado<bool> ModificarCatalogo(Catalogo Catalogo, string Tabla)
        {
            var Respuesta = GenericHelper
                .Request<bool>(
                Url: $"{ApiUri}/{Tabla}",
                Method: HttpMethodEnum.HttpPut_Json,
                Data: Catalogo
                );

            return Respuesta;
        }
    }
}
