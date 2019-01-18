using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CGC_GM_BE.Business;
using CGC_GM_BE.Common.Entities.Modelo;

namespace CGC_GM_BE.Testing.Business
{
    [TestClass]
    public class BoletasBL_UnitTest
    {
        [TestMethod]
        public void BoletasBL_ConsultarBoletasV2()
        {
            var Boletas = BoletasBL.ConsultarBoletasV2();

            Assert.IsNotNull(Boletas);
        }
    }
}
