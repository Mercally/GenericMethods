using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CGC_GM_FE.Models;
using CGC_GM_FE.WebApiRestClient.Metadata.ServiceAgendaApi;

namespace CGC_GM_FE.WebApiRestClient.Services.ServiceAgendaApi
{
    public class AgendasControllerApi : IAgendasControllerApi
    {
        private string ApiUri
        {
            get
            {
                return System.Configuration.ConfigurationSettings.AppSettings["ServiceAgendaApiUri"];
            }
        }

        public int InsertarAgenda(Agenda obj)
        {
            var Respuesta = GenericHelper
                .Request<int>(
                Url: $"{ApiUri}/Agendas",
                Method: HttpMethodEnum.PostJson, 
                Data: obj
                );

            return Respuesta;
        }

        public Agenda ObtenerAgendaPorId(int id)
        {
            var Respuesta = GenericHelper
                .Request<Agenda>(
                Url: $"{ApiUri}/Agendas/FiltroAgenda/{id}", 
                Method: HttpMethodEnum.Get
                );

            return Respuesta;
        }

        public List<Agenda> ObtenerAgendas()
        {
            var Respuesta = GenericHelper
                .Request<List<Agenda>>(
                Url: $"{ApiUri}/Agendas", 
                Method: HttpMethodEnum.Get
                );

            return Respuesta;
        }

        public bool ModificarAgenda(Agenda obj)
        {
            var Respuesta = GenericHelper
                .Request<bool>(
                Url: $"{ApiUri}/Agendas",
                Method: HttpMethodEnum.PutJson,
                Data: obj
                );

            return Respuesta;
        }

        public bool EliminarAgenda(int id)
        {
            var Respuesta = GenericHelper
                .Request<bool>(
                Url: $"{ApiUri}/Agendas/{id}", 
                Method: HttpMethodEnum.Delete
                );

            return Respuesta;
        }
    }
}
