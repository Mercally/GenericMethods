using System.Collections.Generic;
using System.Configuration;
using CGC_GM_FE.Common.Models;
using CGC_GM_FE.WebApiRestClient.Metadata.ServiceTimeManagerApi;

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

        public List<Actividad> ConsultarActividadesPorBoletaId(int BoletaId)
        {
            var Respuesta = GenericHelper
                .Request<List<Actividad>>(
                Url: $"{ApiUri}/ActividadesBoleta/{BoletaId}",
                Method: HttpMethodEnum.HttpPut_Json
                );

            return Respuesta;
        }

        public Actividad ConsultarActividadPorId(int ActividadId)
        {
            var Respuesta = GenericHelper
                .Request<Actividad>(
                Url: $"{ApiUri}/{ActividadId}",
                Method: HttpMethodEnum.HttpPut_Json
                );

            return Respuesta;
        }

        public bool EliminarActividad(int ActividadId)
        {
            var Respuesta = GenericHelper
                .Request<bool>(
                Url: $"{ApiUri}/{ActividadId}",
                Method: HttpMethodEnum.HttpPut_Json
                );

            return Respuesta;
        }

        public int InsertarActividad(Actividad Actividad)
        {
            var Respuesta = GenericHelper
                .Request<int>(
                Url: ApiUri,
                Method: HttpMethodEnum.HttpPost_Json
                );

            return Respuesta;
        }

        public bool ModificarActividad(Actividad Actividad)
        {
            var Respuesta = GenericHelper
                .Request<bool>(
                Url: ApiUri,
                Method: HttpMethodEnum.HttpPut_Json
                );

            return Respuesta;
        }
    }
}
