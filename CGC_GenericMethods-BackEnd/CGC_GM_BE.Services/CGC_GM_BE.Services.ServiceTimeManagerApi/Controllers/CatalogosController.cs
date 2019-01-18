using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using CGC_GM_BE.Common.Entities.Modelo;
using CGC_GM_BE.Business;
using CGC_GM_BE.Services.Metadata.ServiceTimeManagerApi;

namespace CGC_GM_BE.Services.ServiceTimeManagerApi.Controllers
{
    [RoutePrefix("api/Catalogos")]
    public class CatalogosController : ApiController, ICatalogosControllerApi
    {
        [HttpGet]
        [Route("{Tabla}")]
        public _Resultado<List<Catalogo>> ConsultarCatalogoPorTabla(string Tabla)
        {
            return CatalogosBL.ConsultarCatalogoPorTabla(Tabla);
        }

        [HttpGet]
        [Route("{CatalogoId}/{Tabla}")]
        public _Resultado<Catalogo> ConsultarCatalogoPorId(int CatalogoId, string Tabla)
        {
            return CatalogosBL.ConsultarCatalogoPorCatalogoId(CatalogoId, Tabla);
        }

        [HttpDelete]
        [Route("{CatalogoId}/{Tabla}")]
        public _Resultado<bool> EliminarCatalogo(int CatalogoId, string Tabla)
        {
            return CatalogosBL.EliminarCatalogoPorCatalogoId(CatalogoId, Tabla);
        }

        [HttpPost]
        [Route("{Tabla}")]
        public _Resultado<int> InsertarCatalogo(Catalogo Catalogo, string Tabla)
        {
            return CatalogosBL.InsertarCatalogo(Catalogo, Tabla);
        }

        [HttpPut]
        [Route("{Tabla}")]
        public _Resultado<bool> ModificarCatalogo(Catalogo Catalogo, string Tabla)
        {
            return CatalogosBL.ModificarCatalogo(Catalogo, Tabla);
        }
    }
}
