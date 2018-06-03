using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CGC_GM_BE.Business;

namespace CGC_GM_BE.Testing.Business
{
    [TestClass]
    public class Agenda_BL_Test
    {
        [TestMethod]
        public void TestMethod1()
        {
            Agenda_BL AgendaBL = new Agenda_BL();
            int NumPagina = 1, TamanoPagina = 1;
            string Filtro = "", Valor = "";

            var Lista = AgendaBL.ConsultaPaginada(NumPagina, TamanoPagina, Filtro, Valor);

            Assert.IsNotNull(Lista);
        }
    }
}
