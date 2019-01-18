﻿using System;
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
    [RoutePrefix("api/Boletas")]
    public class BoletasController : ApiController, IBoletasControllerApi
    {
        [HttpGet]
        [Route("{BoletaId}")]
        public _Resultado<Boleta> ConsultarBoletaPorId(int BoletaId)
        {
            return BoletasBL.ConsultarBoletaPorBoletaId(BoletaId);
        }

        [HttpGet]
        public _Resultado<List<Boleta>> ConsultarBoletas()
        {
            return BoletasBL.ConsultarBoletas();
        }

        [HttpGet]
        [Route("V2")]
        public List<Boleta> ConsultarBoletasV2()
        {
            return BoletasBL.ConsultarBoletasV2();
        }

        [HttpDelete]
        [Route("{BoletaId}")]
        public _Resultado<bool> EliminarBoleta(int BoletaId)
        {
            return BoletasBL.EliminarBoletaPorBoletaId(BoletaId);
        }

        [HttpPost]
        public _Resultado<int> InsertarBoleta(Boleta Boleta)
        {
            return BoletasBL.InsertarBoleta(Boleta);
        }

        [HttpPut]
        public _Resultado<bool> ModificarBoleta(Boleta Boleta)
        {
            return BoletasBL.ModificarBoleta(Boleta);
        }
    }
}
