using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CGC_GM_BE.Common.Entities;
using CGC_GM_BE.DataAccess;

namespace CGC_GM_BE.Business
{    
    public class ClientesBL
    {
        public static List<Cliente> ConsultarClientes()
        {
            var ListaCliente = new List<Cliente>();

            using (var Contexto = new CGC_GM_Contexto())
            {
                ListaCliente =
                     Contexto
                    .Neg_ClientesModelo
                    .ConsultaClientes()
                    .ConvertirResultadoLista<Cliente>();
            }

            return ListaCliente;
        }

        public static Cliente ConsultarClientePorClienteId(int ClienteId)
        {
            var Cliente = new Cliente();

            using (var Contexto = new CGC_GM_Contexto())
            {
                Cliente =
                     Contexto
                    .Neg_ClientesModelo
                    .ConsultaPorClienteId(ClienteId)
                    .ConvertiresultadoUnico<Cliente>();
            }

            return Cliente;
        }

        public static int InsertarCliente(Cliente Cliente)
        {
            int ClienteId = 0;

            using (var Contexto = new CGC_GM_Contexto())
            {
                ClienteId =
                     Contexto
                    .Neg_ClientesModelo
                    .InsertarCliente(Cliente)
                    .ResultadoTipoInsert;
            }

            return ClienteId;
        }

        public static bool ModificarCliente(Cliente Cliente)
        {
            bool Modificado = false;

            using (var Contexto = new CGC_GM_Contexto())
            {
                Modificado =
                     Contexto
                    .Neg_ClientesModelo
                    .ModificarCliente(Cliente)
                    .ResultadoTipoUpdate;
            }

            return Modificado;
        }

        public static bool EliminarClientePorClienteId(int ClienteId)
        {
            bool Eliminado = false;

            using (var Contexto = new CGC_GM_Contexto())
            {
                Eliminado =
                     Contexto
                    .Neg_ClientesModelo
                    .EliminarCliente(ClienteId)
                    .ResultadoTipoUpdate;
            }

            return Eliminado;
        }
    }
}
