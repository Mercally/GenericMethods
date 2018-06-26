using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CGC_GM_BE.Business;
using CGC_GM_BE.Common.Entities;

namespace CGC_GM_BE.Testing.Business
{
    [TestClass]
    public class ClientesBL_UnitTest
    {
        [TestMethod]
        public void ClientesBL_Insertar()
        {
            var Cliente = new Cliente()
            {
                EsActivo = true,
                FechaRegistro = DateTime.Now,
                Id = 0,
                Nombre = "Prueba"
            };

            var Boletas = ClientesBL.InsertarCliente(Cliente);

            Assert.IsNotNull(Boletas);
        }
    }
}
