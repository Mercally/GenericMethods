using System.Collections.Generic;
using System.Configuration;
using CGC_GM_FE.Common.Models;
using CGC_GM_FE.WebApiRestClient.Metadata.ServiceTimeManagerApi;

namespace CGC_GM_FE.WebApiRestClient.Services.ServiceTimeManagerApi
{
    public class BoletasControllerApi : IBoletasControllerApi
    {
        private string ApiUri
        {
            get
            {
                return ConfigurationSettings.AppSettings["ServiceTimeManagerApi"] + "/Boletas";
            }
        }

        public Boleta ConsultarBoletaPorId(int BoletaId)
        {
            var Respuesta = GenericHelper
                .Request<Boleta>(
                Url: $"{ApiUri}/{BoletaId}",
                Method: HttpMethodEnum.HttpGet
                );

            return Respuesta;
        }

        public List<Boleta> ConsultarBoletas()
        {
            var Respuesta = GenericHelper
                .Request<List<Boleta>>(
                Url: $"{ApiUri}",
                Method: HttpMethodEnum.HttpGet
                );

            return Respuesta;
        }

        public bool EliminarBoleta(int BoletaId)
        {
            var Respuesta = GenericHelper
                .Request<bool>(
                Url: $"{ApiUri}/{BoletaId}",
                Method: HttpMethodEnum.HttpDelete
                );

            return Respuesta;
        }

        public int InsertarBoleta(Boleta Boleta)
        {
            var Respuesta = GenericHelper
                .Request<int>(
                Url: ApiUri,
                Method: HttpMethodEnum.HttpPost_Json,
                Data: Boleta
                );

            return Respuesta;
        }

        public bool ModificarBoleta(Boleta Boleta)
        {
            var Respuesta = GenericHelper
                .Request<bool>(
                Url: ApiUri,
                Method: HttpMethodEnum.HttpPut_Json,
                Data: Boleta
                );

            return Respuesta;
        }
    }
}
