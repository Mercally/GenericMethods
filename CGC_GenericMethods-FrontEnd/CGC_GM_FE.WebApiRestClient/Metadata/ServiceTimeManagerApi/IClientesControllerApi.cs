using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CGC_GM_FE.Common.Models;

namespace CGC_GM_FE.WebApiRestClient.Metadata.ServiceTimeManagerApi
{
    public interface IClientesControllerApi
    {
        List<Cliente> ConsultarClientes();
        Cliente ConsultarClientePorId(int ClienteId);
        int InsertarCliente(Cliente Cliente);
        bool ModificarCliente(Cliente Cliente);
        bool EliminarCliente(int ClienteId);
    }
}
