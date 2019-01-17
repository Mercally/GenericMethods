using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CGC_GM_BE.Common.Entities;

namespace CGC_GM_BE.Services.Metadata.ServiceTimeManagerApi
{
    public interface IClientesControllerApi
    {
        _Resultado<List<Cliente>> ConsultarClientes();
        _Resultado<Cliente> ConsultarClientePorId(int ClienteId);
        _Resultado<int> InsertarCliente(Cliente Cliente);
        _Resultado<bool> ModificarCliente(Cliente Cliente);
        _Resultado<bool> EliminarCliente(int ClienteId);
    }
}
