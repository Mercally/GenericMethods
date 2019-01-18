using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CGC_GM_BE.Common.Entities.Modelo;
using CGC_GM_BE.DataAccess;

namespace CGC_GM_BE.Business
{    
    public class ClientesBL
    {
        public static _Resultado<List<Cliente>> ConsultarClientes()
        {
            var ListaCliente = new _Resultado<List<Cliente>>();

            using (var Contexto = new CGC_GM_Contexto())
            {
                ListaCliente =
                     Contexto
                    .Neg_ClientesModelo
                    .ConsultaClientes();
            }

            return ListaCliente;
        }

        public static _Resultado<Cliente> ConsultarClientePorClienteId(int ClienteId)
        {
            var Cliente = new _Resultado<Cliente>();

            using (var Contexto = new CGC_GM_Contexto())
            {
                Cliente =
                     Contexto
                    .Neg_ClientesModelo
                    .ConsultaPorClienteId(ClienteId);
            }

            return Cliente;
        }

        public static _Resultado<int> InsertarCliente(Cliente Cliente)
        {
            var ClienteId = new _Resultado<int>();

            using (var Contexto = new CGC_GM_Contexto())
            {
                ClienteId =
                     Contexto
                    .Neg_ClientesModelo
                    .InsertarCliente(Cliente);
            }

            return ClienteId;
        }

        public static _Resultado<bool> ModificarCliente(Cliente Cliente)
        {
            var Modificado = new _Resultado<bool>();

            using (var Contexto = new CGC_GM_Contexto())
            {
                Modificado =
                     Contexto
                    .Neg_ClientesModelo
                    .ModificarCliente(Cliente);
            }

            return Modificado;
        }

        public static _Resultado<bool> EliminarClientePorClienteId(int ClienteId)
        {
            var Eliminado = new _Resultado<bool>();

            using (var Contexto = new CGC_GM_Contexto())
            {
                Eliminado =
                     Contexto
                    .Neg_ClientesModelo
                    .EliminarCliente(ClienteId);
            }

            return Eliminado;
        }
    }
}
