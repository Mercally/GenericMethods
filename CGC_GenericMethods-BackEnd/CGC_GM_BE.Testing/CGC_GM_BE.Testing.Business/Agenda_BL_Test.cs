using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CGC_GM_BE.Business;

namespace CGC_GM_BE.Testing.Business
{
    [TestClass]
    public class Agenda_BL_Test
    {
        [TestMethod]
        public void TestMethod()
        {
            Agenda_BL AgendaBL = new Agenda_BL();
            var Lista = AgendaBL.ConsultaGenerica();

            Assert.IsNotNull(Lista);
        }
    }
}
