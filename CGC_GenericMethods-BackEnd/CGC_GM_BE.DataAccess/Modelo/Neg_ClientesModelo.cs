using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using CGC_GM_BE.Common.Entities;
using CGC_GM_BE.DataAccess.Interfaces;

namespace CGC_GM_BE.DataAccess.Modelo
{
    public class Neg_ClientesModelo : ContextoBase
    {
        public Neg_ClientesModelo(IContextoCustomizado Contexto)
            : base(Contexto) { }

        public _Resultado ConsultaPorClienteId(int ClienteId)
        {
            _ConsultaT_Sql Consulta = new _ConsultaT_Sql()
            {
                ConsultaCruda = @"SELECT Id, Nombre, FechaRegistro, EsActivo 
                                  FROM neg.Cliente WHERE Id = @ClienteId",
                Parametros = new List<SqlParameter>()
                {
                    new SqlParameter("@ClienteId", ClienteId)
                },
                TipoConsulta = _TipoConsultaEnum.Query
            };

            return Ejecutar(Consulta);
        }

        public _Resultado InsertarCliente(Cliente Cliente)
        {
            _ConsultaT_Sql Consulta = new _ConsultaT_Sql()
            {
                ConsultaCruda = @"INSERT INTO neg.Cliente(Nombre, FechaRegistro, EsActivo) 
                                  VALUES(@Nombre, @FechaRegistro, @EsActivo);
                                  SELECT SCOPE_IDENTITY();",
                Parametros = new List<SqlParameter>() {
                                new SqlParameter("Nombre", Cliente.Nombre),
                                new SqlParameter("FechaRegistro", Cliente.FechaRegistro),
                                new SqlParameter("EsActivo", Cliente.EsActivo)
                            },
                TipoConsulta = _TipoConsultaEnum.Insert
            };

            return Ejecutar(Consulta);
        }

        public _Resultado ModificarCliente(Cliente Cliente)
        {
            _ConsultaT_Sql Consulta = new _ConsultaT_Sql()
            {
                ConsultaCruda = @"UPDATE neg.Cliente SET Nombre=@Nombre, FechaRegistro=@FechaRegistro, EsActivo=@EsActivo 
                                  WHERE Id = @ClienteId;",
                Parametros = new List<SqlParameter>()
                {
                    new SqlParameter("ClienteId", Cliente.Id),
                    new SqlParameter("Nombre", Cliente.Nombre),
                    new SqlParameter("FechaRegistro", Cliente.FechaRegistro),
                    new SqlParameter("EsActivo", Cliente.EsActivo)
                },
                TipoConsulta = _TipoConsultaEnum.Update
            };

            return Ejecutar(Consulta);
        }

        public _Resultado EliminarCliente(int ClienteId, bool EsEliminadoFisico = false)
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
                TipoConsulta = _TipoConsultaEnum.Delete
            };

            return Ejecutar(Consulta);
        }
    }
}
