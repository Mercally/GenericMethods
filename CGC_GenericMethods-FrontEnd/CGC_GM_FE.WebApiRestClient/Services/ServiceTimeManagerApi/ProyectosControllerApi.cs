using System.Collections.Generic;
using System.Configuration;
using CGC_GM_FE.Common.Models;
using CGC_GM_FE.WebApiRestClient.Metadata.ServiceTimeManagerApi;

namespace CGC_GM_FE.WebApiRestClient.Services.ServiceTimeManagerApi
{
    public class ProyectosControllerApi : IProyectosControllerApi
    {
        private string ApiUri
        {
            get
            {
                return ConfigurationSettings.AppSettings["ServiceTimeManagerApi"] + "/Proyectos";
            }
        }

        public _Resultado<Proyecto> ConsultarProyectoPorId(int ProyectoId)
        {
            var Respuesta = GenericHelper
                .Request<Proyecto>(
                Url: $"{ApiUri}/{ProyectoId}",
                Method: HttpMethodEnum.HttpGet
                );

            return Respuesta;
        }

        public _Resultado<List<Proyecto>> ConsultarProyectos()
        {
            var Respuesta = GenericHelper
                .Request<List<Proyecto>>(
                Url: $"{ApiUri}",
                Method: HttpMethodEnum.HttpGet
                );

            return Respuesta;
        }

        public _Resultado<bool> EliminarProyecto(int ProyectoId)
        {
            var Respuesta = GenericHelper
                .Request<bool>(
                Url: $"{ApiUri}/{ProyectoId}",
                Method: HttpMethodEnum.HttpDelete
                );

            return Respuesta;
        }

        public _Resultado<int> InsertarProyecto(Proyecto Proyecto)
        {
            var Respuesta = GenericHelper
                .Request<int>(
                Url: ApiUri,
                Method: HttpMethodEnum.HttpPost_Json,
                Data: Proyecto
                );

            return Respuesta;
        }

        public _Resultado<bool> ModificarProyecto(Proyecto Proyecto)
        {
            var Respuesta = GenericHelper
                .Request<bool>(
                Url: ApiUri,
                Method: HttpMethodEnum.HttpPut_Json,
                Data: Proyecto
                );

            return Respuesta;
        }
    }
}
