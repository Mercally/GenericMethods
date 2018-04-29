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
                .Request<int>($"{ApiUri}/Agendas", HttpMethodEnum.PostJson, obj);

            return Respuesta;
        }

        public Agenda ObtenerAgendaPorId(int id)
        {
            var Respuesta = GenericHelper
                .Request<Agenda>($"{ApiUri}/Agendas/Filtro/{id}", HttpMethodEnum.Get);

            return Respuesta;
        }

        public List<Agenda> ObtenerAgendas()
        {
            var Respuesta = GenericHelper
                .Request<List<Agenda>>($"{ApiUri}/Agendas", HttpMethodEnum.Get);

            return Respuesta;
        }

        public bool ModificarAgenda(Agenda obj)
        {
            var Respuesta = GenericHelper
                .Request<bool>($"{ApiUri}/Agendas", HttpMethodEnum.PutJson, obj);

            return Respuesta;
        }

        public bool Eliminar(int id)
        {
            var Respuesta = GenericHelper
                .Request<bool>($"{ApiUri}/Agendas/{id}", HttpMethodEnum.Delete);

            return Respuesta;
        }
    }
}
