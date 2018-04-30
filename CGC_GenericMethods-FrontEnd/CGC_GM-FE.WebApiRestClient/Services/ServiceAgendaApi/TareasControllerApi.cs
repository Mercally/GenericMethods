using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
                return System.Configuration.ConfigurationSettings.AppSettings["ServiceAgendaApiUri"];
            }
        }

        public int InsertarTarea(Tarea obj)
        {
            var Respuesta = GenericHelper
                .Request<int>($"{ApiUri}/Tareas", HttpMethodEnum.PostJson, obj);

            return Respuesta;
        }

        public bool ModificarTarea(Tarea obj)
        {
            var Respuesta = GenericHelper
                .Request<bool>($"{ApiUri}/Tareas", HttpMethodEnum.PutJson, obj);

            return Respuesta;
        }

        public Tarea ObtenerTareaPorId(int id)
        {
            var Respuesta = GenericHelper
                .Request<Tarea>($"{ApiUri}/Tareas/FiltroTarea/{id}", HttpMethodEnum.Get);

            return Respuesta;
        }

        public List<Tarea> ObtenerTareasPorAgendaId(int id)
        {
            var Respuesta = GenericHelper
                .Request<List<Tarea>>($"{ApiUri}/Tareas/FiltroTareaAgenda/{id}", HttpMethodEnum.Get);

            return Respuesta;
        }

        public List<Tarea> ObtenerTareas()
        {
            var Respuesta = GenericHelper
                .Request<List<Tarea>>($"{ApiUri}/Tareas", HttpMethodEnum.Get);

            return Respuesta;
        }

        public bool EliminarTarea(int id)
        {
            var Respuesta = GenericHelper
                .Request<bool>($"{ApiUri}/Tareas/{id}", HttpMethodEnum.Delete);

            return Respuesta;
        }
    }
}
