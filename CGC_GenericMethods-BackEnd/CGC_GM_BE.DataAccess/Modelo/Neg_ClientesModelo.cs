using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using CGC_GM_BE.Common.Entities.Modelo;
using CGC_GM_BE.DataAccess.Interfaces;
using CGC_GM_BE.Common.Extensions;

namespace CGC_GM_BE.DataAccess.Modelo
{
    public class Neg_ClientesModelo : ContextoBase
    {
        public Neg_ClientesModelo(IContextoCustomizado Contexto)
            : base(Contexto) { }

        public _Resultado<List<Cliente>> ConsultaClientes()
        {
            _ConsultaT_Sql Consulta = new _ConsultaT_Sql()
            {
                ConsultaCruda = @"SELECT Id, Nombre, FechaRegistro, EsActivo 
                                  FROM neg.Cliente
                                  WHERE EsActivo = 1;",
                _TipoConsulta = TipoConsulta.Query
            };

            return Ejecutar<List<Cliente>>(Consulta);
        }

        public _Resultado<Cliente> ConsultaPorClienteId(int ClienteId)
        {
            _ConsultaT_Sql Consulta = new _ConsultaT_Sql()
            {
                ConsultaCruda = @"SELECT Id, Nombre, FechaRegistro, EsActivo 
                                  FROM neg.Cliente WHERE Id = @ClienteId",
                Parametros = new List<SqlParameter>()
                {
                    new SqlParameter("@ClienteId", ClienteId)
                },
                _TipoConsulta = TipoConsulta.Query
            };

            return Ejecutar<Cliente>(Consulta);
        }

        public _Resultado<int> InsertarCliente(Cliente Cliente)
        {
            return Ejecutar<int>(Cliente, TipoConsulta.Insert);
        }

        public _Resultado<bool> ModificarCliente(Cliente Cliente)
        {
            return Ejecutar<bool>(_ConsultaT_Sql.CreateQuery(Cliente, TipoConsulta.Update));
        }

        public _Resultado<bool> EliminarCliente(int ClienteId, bool EsEliminadoFisico = false)
        {
            string ConsultaCruda = string.Empty;

            if (EsEliminadoFisico)
            {
                ConsultaCruda = "DELETE neg.Cliente WHERE Id = @ClienteId;";
            }
            else
            {
                ConsultaCruda = "UPDATE neg.Cliente SET EsActivo = 0 WHERE Id = @ClienteId";
            }

            _ConsultaT_Sql Consulta = new _ConsultaT_Sql()
            {
                ConsultaCruda = ConsultaCruda,
                Parametros = new List<SqlParameter>()
                {
                    new SqlParameter("@ClienteId", ClienteId)
                },
                _TipoConsulta = TipoConsulta.Delete
            };

            return Ejecutar<bool>(Consulta);
        }
    }
}
