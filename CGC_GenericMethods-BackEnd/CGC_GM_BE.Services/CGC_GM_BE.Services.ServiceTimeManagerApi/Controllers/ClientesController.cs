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
    [RoutePrefix("api/Clientes")]
    public class ClientesController : ApiController, IClientesControllerApi
    {
        [HttpGet]
        public List<Cliente> ConsultarClientes()
        {
            return ClientesBL.ConsultarClientes();
        }

        [HttpGet]
        [Route("{ClienteId}")]
        public Cliente ConsultarClientePorId(int ClienteId)
        {
            return ClientesBL.ConsultarClientePorClienteId(ClienteId);
        }

        [HttpDelete]
        [Route("{ClienteId}")]
        public bool EliminarCliente(int ClienteId)
        {
            return ClientesBL.EliminarClientePorClienteId(ClienteId);
        }

        [HttpPost]
        public int InsertarCliente(Cliente Cliente)
        {
            return ClientesBL.InsertarCliente(Cliente);
        }

        [HttpPut]
        public bool ModificarCliente(Cliente Cliente)
        {
            return ClientesBL.ModificarCliente(Cliente);
        }
    }
}
