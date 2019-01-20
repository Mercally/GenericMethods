using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CGC_GM_FE.WebApiRestClient.Metadata.ServiceTimeManagerApi;
using CGC_GM_FE.WebApiRestClient.Services.ServiceTimeManagerApi;

namespace CGC_GM_FE.WebApiRestClient.Services
{
    public static class WebApiProvider
    {
        public static ICatalogosControllerApi CatalogosApi
        {
            get
            {
                return new CatalogosControllerApi();
            }
        }

        public static IClientesControllerApi ClientesApi
        {
            get
            {
                return new ClientesControllerApi();
            }
        }

        public static IActividadesControllerApi ActividadesApi
        {
            get
            {
                return new ActividadesControllerApi();
            }
        }

        public static IBoletasControllerApi BoletasApi
        {
            get
            {
                return new BoletasControllerApi();
            }
        }

        public static IProyectosControllerApi ProyectosApi
        {
            get
            {
                return new ProyectosControllerApi();
            }
        }

        public static IUsuariosControllerApi UsuariosApi
        {
            get
            {
                return new UsuariosControllerApi();
            }
        }

        public static IReportesControllerApi ReportesApi
        {
            get
            {
                return new ReportesControllerApi();
            }
        }
    }
}
