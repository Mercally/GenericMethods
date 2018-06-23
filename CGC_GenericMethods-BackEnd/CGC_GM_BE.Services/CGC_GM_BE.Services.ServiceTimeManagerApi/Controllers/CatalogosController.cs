using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using CGC_GM_BE.Common.Entities;
using CGC_GM_BE.Business;
using CGC_GM_BE.Services.Metadata.ServiceTimeManagerApi;

namespace CGC_GM_BE.Services.ServiceTimeManagerApi.Controllers
{
    [RoutePrefix("api/Catalogos")]
    public class CatalogosController : ApiController, ICatalogosControllerApi
    {
        [HttpGet]
        [Route("{CatalogoId}/{Tabla}")]
        public Catalogo ConsultarCatalogoPorId(int CatalogoId, string Tabla)
        {
            return CatalogosBL.ConsultarCatalogoPorCatalogoId(CatalogoId, Tabla);
        }

        [HttpDelete]
        [Route("{CatalogoId}/{Tabla}")]
        public bool EliminarCatalogo(int CatalogoId, string Tabla)
        {
            return CatalogosBL.EliminarCatalogoPorCatalogoId(CatalogoId, Tabla);
        }

        [HttpPost]
        [Route("{Tabla}")]
        public int InsertarCatalogo(Catalogo Catalogo, string Tabla)
        {
            return CatalogosBL.InsertarCatalogo(Catalogo, Tabla);
        }

        [HttpPut]
        [Route("{Tabla}")]
        public bool ModificarCatalogo(Catalogo Catalogo, string Tabla)
        {
            return CatalogosBL.ModificarCatalogo(Catalogo, Tabla);
        }
    }
}
