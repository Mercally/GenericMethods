using System.Collections.Generic;
using System.Configuration;
using CGC_GM_FE.WebApiRestClient.Metadata.ServiceTimeManagerApi;
using CGC_GM_FE.Common.Models;

namespace CGC_GM_FE.WebApiRestClient.Services.ServiceTimeManagerApi
{
    public class ActividadesControllerApi : IActividadesControllerApi
    {
        private string ApiUri
        {
            get
            {
                return ConfigurationSettings.AppSettings["ServiceTimeManagerApi"] + "/Actividades";
            }
        }

        public _Resultado<List<Actividad>> ConsultarActividadesPorBoletaId(int BoletaId)
        {
            var Respuesta = GenericHelper
                .Request<List<Actividad>>(
                Url: $"{ApiUri}/ActividadesBoleta/{BoletaId}",
                Method: HttpMethodEnum.HttpGet
                );

            return Respuesta;
        }

        public _Resultado<Actividad> ConsultarActividadPorId(int ActividadId)
        {
            var Respuesta = GenericHelper
                .Request<Actividad>(
                Url: $"{ApiUri}/{ActividadId}",
                Method: HttpMethodEnum.HttpGet
                );

            return Respuesta;
        }

        public _Resultado<bool> EliminarActividad(int ActividadId)
        {
            var Respuesta = GenericHelper
                .Request<bool>(
                Url: $"{ApiUri}/{ActividadId}",
                Method: HttpMethodEnum.HttpPut_Json
                );

            return Respuesta;
        }

        public _Resultado<int> InsertarActividad(Actividad Actividad)
        {
            var Respuesta = GenericHelper
                .Request<int>(
                Url: ApiUri,
                Method: HttpMethodEnum.HttpPost_Json,
                Data: Actividad
                );

            return Respuesta;
        }

        public _Resultado<bool> ModificarActividad(Actividad Actividad)
        {
            var Respuesta = GenericHelper
                .Request<bool>(
                Url: ApiUri,
                Method: HttpMethodEnum.HttpPut_Json,
                Data: Actividad
                );

            return Respuesta;
        }
    }
}
