using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using CGC_GM_BE.Common.Entities;
using CGC_GM_BE.Services.Metadata.ServiceCatalogoApi;
using CGC_GM_BE.Business;

namespace CGC_GM_BE.Services.ServiceCatalogoApi.Controllers
{
    [RoutePrefix("api/Catalogos")]
    public class CatalogosController : ApiController, ICatalogosControllerApi
    {

        Catalogo_BL Catalogo = new Catalogo_BL();

        [HttpGet]
        [Route("Filtro/{Tabla}/{Campo}")]
        public List<Catalogo> ObtenerCatalogo(string Tabla, string Campo)
        {
            return Catalogo.Consulta(Tabla, Campo);
        }

        [HttpGet]
        [Route("{id}")]
        public Catalogo ObtenerCatalogoPorId(int id)
        {
            return Catalogo.ConsultaPorId(id);
        }
    }
}
