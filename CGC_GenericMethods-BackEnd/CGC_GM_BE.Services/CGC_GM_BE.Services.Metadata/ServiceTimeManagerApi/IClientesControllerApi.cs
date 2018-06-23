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
        Cliente ConsultarClientePorId(int ClienteId);
        int InsertarCliente(Cliente Cliente);
        bool ModificarCliente(Cliente Cliente);
        bool EliminarCliente(int ClienteId);
    }
}
