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
        _Resultado<List<Cliente>> ConsultarClientes(bool soloActivos = false);
        _Resultado<Cliente> ConsultarClientePorId(int ClienteId);
        _Resultado<int> InsertarCliente(Cliente Cliente);
        _Resultado<bool> ModificarCliente(Cliente Cliente);
        _Resultado<bool> EliminarCliente(int ClienteId);
    }
}
