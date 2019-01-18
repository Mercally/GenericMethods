using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CGC_GM_BE.Business;
using CGC_GM_BE.Common.Entities.Modelo;

namespace CGC_GM_BE.Testing.Business
{
    [TestClass]
    public class ActividadesBL_UnitTest
    {
        [TestMethod]
        public void ActividadesBL_ConsultarActividadesPorBoletaId()
        {
            int BoletaId = 1;

            var Actividades = ActividadesBL.ConsultarActividadesPorBoletaId(BoletaId);

            Assert.IsNotNull(Actividades);
        }
    }
}
