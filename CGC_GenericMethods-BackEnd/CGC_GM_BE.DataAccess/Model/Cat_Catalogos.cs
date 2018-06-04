using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CGC_GM_BE.Common.Entities;
using CGC_GM_BE.DataAccess.Conexion;
using CGC_GM_BE.DataAccess.Consulta;
using CGC_GM_BE.DataAccess.Interface;
using CGC_GM_BE.DataAccess.Implement;
using CGC_GM_BE.DataAccess.Context;
using System.Data.SqlClient;

namespace CGC_GM_BE.DataAccess.Model
{
    public class Cat_Catalogos
    {
        public CGC_GM_Contexto Contexto { get; }

        internal Cat_Catalogos(CGC_GM_Contexto Contexto)
        {
            this.Contexto = Contexto;
        }

        public IResultadoConsulta Consulta(string Tabla, string Campo)
        {
            IResultadoConsulta Resultado = new ResultadoGenericoImpl();

            try
            {
                ConsultaT_Sql Consulta = new ConsultaT_Sql()
                {
                    ConsultaCruda = @"SELECT Id, Tabla, Campo, Codigo, Valor FROM cat.Catalogos 
                                    WHERE Tabla=@Tabla AND Campo=@Campo ORDER BY Valor ASC;",
                    Parametros = new List<SqlParameter>()
                    {
                        new SqlParameter("@Tabla", Tabla),
                        new SqlParameter("@Campo", Campo)
                    },
                    TipoConsulta = TipoConsultaEnum.Query,
                    TimeOut = Contexto.TimeOut
                };

                Resultado = Contexto.Comandos.Ejecutar(Consulta);
            }
            catch (Exception ex)
            {
                Resultado.Excepcion = ex;
                Contexto.Excepciones.Add(ex);
            }

            return Resultado;
        }

        public IResultadoConsulta ConsultaPorId(int id)
        {
            IResultadoConsulta Resultado = new ResultadoGenericoImpl();

            try
            {
                ConsultaT_Sql Consulta = new ConsultaT_Sql()
                {
                    ConsultaCruda = "SELECT Id, Tabla, Campo, Codigo, Valor FROM cat.Catalogos WHERE Id=@Id;",
                    Parametros = new List<SqlParameter>() {
                        new SqlParameter("@Id", id)
                    },
                    TipoConsulta = TipoConsultaEnum.Query,
                    TimeOut = Contexto.TimeOut
                };

                Resultado = Contexto.Comandos.Ejecutar(Consulta);
            }
            catch (Exception ex)
            {
                Resultado.Excepcion = ex;
                Contexto.Excepciones.Add(ex);
            }

            return Resultado;
        }

    }
}
