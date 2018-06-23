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
    [RoutePrefix("api/Boletas")]
    public class BoletasController : ApiController, IBoletasControllerApi
    {
        [HttpGet]
        [Route("{BoletaId}")]
        public Boleta ConsultarBoletaPorId(int BoletaId)
        {
            return BoletasBL.ConsultarBoletaPorBoletaId(BoletaId);
        }

        [HttpDelete]
        [Route("{BoletaId}")]
        public bool EliminarBoleta(int BoletaId)
        {
            return BoletasBL.EliminarBoletaPorBoletaId(BoletaId);
        }

        [HttpPost]
        public int InsertarBoleta(Boleta Boleta)
        {
            return BoletasBL.InsertarBoleta(Boleta);
        }

        [HttpPut]
        public bool ModificarBoleta(Boleta Boleta)
        {
            return BoletasBL.ModificarBoleta(Boleta);
        }
    }
}
