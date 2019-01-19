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

        public _Resultado<Boleta> ConsultarBoletaPorId(int BoletaId)
        {
            var Respuesta = GenericHelper
                .Request<Boleta>(
                Url: $"{ApiUri}/{BoletaId}",
                Method: HttpMethodEnum.HttpGet
                );

            return Respuesta;
        }

        public _Resultado<List<Boleta>> ConsultarBoletas()
        {
            var Respuesta = GenericHelper
                .Request<List<Boleta>>(
                Url: ApiUri,
                Method: HttpMethodEnum.HttpGet
                );

            return Respuesta;
        }

        public _Resultado<List<Boleta>> ConsultarBoletasV2()
        {
            var Respuesta = GenericHelper
                .Request<List<Boleta>>(
                Url: $"{ApiUri}/V2",
                Method: HttpMethodEnum.HttpGet
                );

            return Respuesta;
        }

        public _Resultado<bool> EliminarBoleta(int BoletaId)
        {
            var Respuesta = GenericHelper
                .Request<bool>(
                Url: $"{ApiUri}/{BoletaId}",
                Method: HttpMethodEnum.HttpDelete
                );

            return Respuesta;
        }

        public _Resultado<int> InsertarBoleta(Boleta Boleta)
        {
            var Respuesta = GenericHelper
                .Request<int>(
                Url: ApiUri,
                Method: HttpMethodEnum.HttpPost_Json,
                Data: Boleta
                );

            return Respuesta;
        }

        public _Resultado<bool> ModificarBoleta(Boleta Boleta)
        {
            var Respuesta = GenericHelper
                .Request<bool>(
                Url: ApiUri,
                Method: HttpMethodEnum.HttpPut_Json,
                Data: Boleta
                );

            return Respuesta;
        }

        List<Boleta> IBoletasControllerApi.ConsultarBoletasV2()
        {
            throw new System.NotImplementedException();
        }
    }
}
