using System;
using CGC_GM_BE.Business.Common;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Testing.Business.Common
{
    [TestClass]
    public class Usuario_BLC_Test
    {
        [TestMethod]
        public void ConsultaGenerica()
        {
            Usuario_BLC UsuarioBL = new Usuario_BLC();

            var Lista = UsuarioBL.ConsultaGenerica();

            Assert.IsNotNull(Lista);
        }
    }
}
