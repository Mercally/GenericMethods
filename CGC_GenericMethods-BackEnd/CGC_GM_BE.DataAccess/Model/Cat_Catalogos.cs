using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//> usings
using CGC_GM_BE.Common.Entities;
using CGC_GM_BE.DataAccess.Interface;
using CGC_GM_BE.DataAccess.Implement;
using CGC_GM_BE.DataAccess.Context;
using System.Data.SqlClient;

namespace CGC_GM_BE.DataAccess.Model
{
    public class Cat_Catalogos : CGC_GM_Contexto
    {
        public IResultadoConsulta Consulta(string Tabla, string Campo)
        {
            IResultadoConsulta Resultado = new ResultadoGenericoImpl();

            try
            {
                _ConsultaT_Sql Consulta = new _ConsultaT_Sql()
                {
                    ConsultaCruda = @"SELECT Id, Tabla, Campo, Codigo, Valor FROM cat.Catalogos 
                                    WHERE Tabla=@Tabla AND Campo=@Campo ORDER BY Valor ASC;",
                    Parametros = new List<SqlParameter>()
                    {
                        new SqlParameter("@Tabla", Tabla),
                        new SqlParameter("@Campo", Campo)
                    },
                    TipoConsulta = _TipoConsultaEnum.Query
                };

                Resultado = Comandos.Ejecutar(Consulta);
            }
            catch (Exception ex)
            {
                Resultado.Excepcion = ex;
                Excepciones.Add(ex);
            }

            return Resultado;
        }

        public IResultadoConsulta ConsultaPorId(int Id)
        {
            IResultadoConsulta Resultado = new ResultadoGenericoImpl();

            try
            {
                _ConsultaT_Sql Consulta = new _ConsultaT_Sql()
                {
                    ConsultaCruda = @"SELECT Id, Tabla, Campo, Codigo, Valor FROM cat.Catalogos WHERE Id=@Id;",
                    Parametros = new List<SqlParameter>() {
                        new SqlParameter("@Id", Id)
                    },
                    TipoConsulta = _TipoConsultaEnum.Query
                };

                Resultado = Comandos.Ejecutar(Consulta);
            }
            catch (Exception ex)
            {
                Resultado.Excepcion = ex;
                Excepciones.Add(ex);
            }

            return Resultado;
        }

    }
}
