using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using CGC_GM_FE.Models;
using CGC_GM_FE.WebApiRestClient.Metadata.ServiceAgendaApi;

namespace CGC_GM_FE.WebApiRestClient.Services.ServiceAgendaApi
{
    public class TareasControllerApi : ITareasControllerApi
    {
        private string ApiUri
        {
            get
            {
                return ConfigurationManager.AppSettings["ServiceAgendaApiUri"];
            }
        }

        public int InsertarTarea(Tarea obj)
        {
            var Respuesta = GenericHelper
                .Request<int>(
                Url: $"{ApiUri}/Tareas",
                Method: HttpMethodEnum.PostJson,
                Data: obj
                );

            return Respuesta;
        }

        public bool ModificarTarea(Tarea obj)
        {
            var Respuesta = GenericHelper
                .Request<bool>(
                Url: $"{ApiUri}/Tareas",
                Method: HttpMethodEnum.PutJson,
                Data: obj
                );

            return Respuesta;
        }

        public Tarea ObtenerTareaPorId(int id)
        {
            var Respuesta = GenericHelper
                .Request<Tarea>(
                Url: $"{ApiUri}/Tareas/FiltroTarea/{id}", 
                Method: HttpMethodEnum.Get
                );

            return Respuesta;
        }

        public List<Tarea> ObtenerTareasPorAgendaId(int id)
        {
            var Respuesta = GenericHelper
                .Request<List<Tarea>>(
                Url: $"{ApiUri}/Tareas/FiltroTareaAgenda/{id}",
                Method: HttpMethodEnum.Get
                );

            return Respuesta;
        }

        public List<Tarea> ObtenerTareas()
        {
            var Respuesta = GenericHelper
                .Request<List<Tarea>>(
                Url: $"{ApiUri}/Tareas", 
                Method: HttpMethodEnum.Get
                );

            return Respuesta;
        }

        public bool EliminarTarea(int id)
        {
            var Respuesta = GenericHelper
                .Request<bool>(
                Url: $"{ApiUri}/Tareas/{id}",
                Method: HttpMethodEnum.Delete
                );

            return Respuesta;
        }
    }
}
