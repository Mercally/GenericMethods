using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//> usings
using CGC_GM_BE.Common.Entities;
using CGC_GM_BE.DataAccess.Interface;
using CGC_GM_BE.DataAccess.Implement;
using CGC_GM_BE.DataAccess.Context;

namespace CGC_GM_BE.DataAccess.Model
{
    public class Age_Agenda_Model : CGC_GM_Contexto
    {   
        public IResultadoConsulta ConsultaPaginada(int NumeroPagina, int TamanoPagina, string Filtro, string Valor)
        {
            IResultadoConsulta Resultado = new ResultadoGenericoImpl();

            try
            {
                _ConsultaT_Sql Consulta = new _ConsultaT_Sql()
                {
                    ConsultaCruda =
                                    @"SELECT 
                                    Id,
                                    Nombre,
                                    Descripcion
                                    FROM age.Agendas AS Age
                                    ORDER BY Age.Nombre ASC
                                    OFFSET @NumeroPagina ROWS
                                    FETCH NEXT @TamanoPagina ROWS ONLY;",
                    Parametros = new List<SqlParameter>() {
                        new SqlParameter("@NumeroPagina", NumeroPagina),
                        new SqlParameter("@TamanoPagina", TamanoPagina)
                    },
                    TipoConsulta = _TipoConsultaEnum.Query,
                    
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

        public IResultadoConsulta Consulta()
        {
            IResultadoConsulta Resultado = new ResultadoGenericoImpl();

            try
            {
                _ConsultaT_Sql Consulta = new _ConsultaT_Sql()
                {
                    ConsultaCruda = @"SELECT Id, Nombre, Descripcion FROM age.Agendas AS Age ORDER BY Age.Nombre ASC;",
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
                _ConsultaT_Sql Consulta = new _ConsultaT_Sql() // Ingresar consulta
                {
                    ConsultaCruda = @"SELECT Id, Nombre, Descripcion FROM age.Agendas WHERE Id = @Id;",
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

        public IResultadoConsulta Insertar(Common.Entities.Agenda Obj)
        {
            IResultadoConsulta Resultado = new ResultadoGenericoImpl();

            try
            {
                _ConsultaT_Sql Consulta = new _ConsultaT_Sql()
                {
                    ConsultaCruda = @"INSERT INTO age.Agendas(Nombre, Descripcion) 
                                    VALUES(@Nombre, @Descripcion); 
                                    SELECT CAST(SCOPE_IDENTITY() AS INT) AS Id;",
                    Parametros = new List<SqlParameter>()
                    {
                        new SqlParameter("@Nombre", Obj.Nombre),
                        new SqlParameter("@Descripcion", string.IsNullOrEmpty(Obj.Descripcion) ?  DBNull.Value.ToString() : Obj.Descripcion)
                    },
                    TipoConsulta = _TipoConsultaEnum.Insert
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

        public IResultadoConsulta Modificar(Common.Entities.Agenda Obj)
        {
            IResultadoConsulta Resultado = new ResultadoGenericoImpl();

            try
            {
                _ConsultaT_Sql Consulta = new _ConsultaT_Sql()
                {
                    ConsultaCruda = @"UPDATE age.Agendas SET Nombre=@Nombre, Descripcion=@Descripcion WHERE Id=@Id;",
                    Parametros = new List<SqlParameter>()
                    {
                     new SqlParameter("@Id", Obj.Id),
                     new SqlParameter("@Nombre", Obj.Nombre),
                     new SqlParameter("@Descripcion", string.IsNullOrEmpty(Obj.Descripcion) ?  DBNull.Value.ToString() : Obj.Descripcion)
                    },
                    TipoConsulta = _TipoConsultaEnum.Update
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

        public IResultadoConsulta Eliminar(int Id)
        {
            IResultadoConsulta Resultado = new ResultadoGenericoImpl();

            try
            {
                _ConsultaT_Sql Consulta = new _ConsultaT_Sql()
                {
                    ConsultaCruda = @"DELETE age.Agendas WHERE Id=@Id;",
                    Parametros = new List<SqlParameter>()
                    {
                     new SqlParameter("@Id", Id)
                    },
                    TipoConsulta = _TipoConsultaEnum.Delete
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
