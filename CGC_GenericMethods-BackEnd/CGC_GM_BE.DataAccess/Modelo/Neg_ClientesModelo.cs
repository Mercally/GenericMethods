using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using CGC_GM_BE.Common.Entities;
using CGC_GM_BE.DataAccess.Interfaces;
using CGC_GM_BE.Common.Entities.Constantes;

namespace CGC_GM_BE.DataAccess.Modelo
{
    public class Neg_ClientesModelo : ContextoBase
    {
        public Neg_ClientesModelo(IContextoCustomizado Contexto)
            : base(Contexto) { }

        public _Resultado<T> ConsultaClientes<T>()
        {
            _ConsultaT_Sql Consulta = new _ConsultaT_Sql()
            {
                ConsultaCruda = @"SELECT Id, Nombre, FechaRegistro, EsActivo 
                                  FROM neg.Cliente
                                  WHERE EsActivo = 1;",
                TipoConsulta = TipoConsulta.Query
            };

            return Ejecutar<T>(Consulta);
        }

        public _Resultado<T> ConsultaPorClienteId<T>(int ClienteId)
        {
            _ConsultaT_Sql Consulta = new _ConsultaT_Sql()
            {
                ConsultaCruda = @"SELECT Id, Nombre, FechaRegistro, EsActivo 
                                  FROM neg.Cliente WHERE Id = @ClienteId",
                Parametros = new List<SqlParameter>()
                {
                    new SqlParameter("@ClienteId", ClienteId)
                },
                TipoConsulta = TipoConsulta.Query
            };

            return Ejecutar<T>(Consulta);
        }

        public _Resultado<T> InsertarCliente<T>(Cliente Cliente)
        {
            return Ejecutar<T>(Cliente, TipoConsulta.Insert);
        }

        public _Resultado<T> ModificarCliente<T>(Cliente Cliente)
        {
            return Ejecutar<T>(_ConsultaT_Sql.CreateQuery(Cliente, TipoConsulta.Update));
        }

        public _Resultado<T> EliminarCliente<T>(int ClienteId, bool EsEliminadoFisico = false)
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
                TipoConsulta = TipoConsulta.Delete
            };

            return Ejecutar<T>(Consulta);
        }
    }
}
