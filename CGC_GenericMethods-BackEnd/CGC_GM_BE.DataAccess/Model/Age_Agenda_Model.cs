using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CGC_GM_BE.Common.Entities;
using CGC_GM_BE.DataAccess.Conexion;
using CGC_GM_BE.DataAccess.Consulta;
using CGC_GM_BE.DataAccess.Interface;
using CGC_GM_BE.DataAccess.Implement;
using CGC_GM_BE.DataAccess.Context;

namespace CGC_GM_BE.DataAccess.Model
{
    public class Age_Agenda_Model
    {
        public CGC_GM_Contexto Contexto { get; }

        internal Age_Agenda_Model(CGC_GM_Contexto Contexto)
        {
            this.Contexto = Contexto;
        }

        public IResultadoConsulta ConsultaPaginada(int NumeroPagina, int TamanoPagina, string Filtro, string Valor)
        {
            IResultadoConsulta Resultado = new ResultadoGenericoImpl();

            try
            {
                ConsultaT_Sql Consulta = new ConsultaT_Sql()
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

        public IResultadoConsulta Consulta()
        {
            IResultadoConsulta Resultado = new ResultadoGenericoImpl();

            try
            {
                ConsultaT_Sql Consulta = new ConsultaT_Sql()
                {
                    ConsultaCruda = @"SELECT Id, Nombre, Descripcion FROM age.Agendas AS Age ORDER BY Age.Nombre ASC;",
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

        public IResultadoConsulta ConsultaPorId(int Id)
        {
            IResultadoConsulta Resultado = new ResultadoGenericoImpl();

            try
            {
                ConsultaT_Sql Consulta = new ConsultaT_Sql() // Ingresar consulta
                {
                    ConsultaCruda = @"SELECT Id, Nombre, Descripcion FROM age.Agendas WHERE Id = @Id;",
                    Parametros = new List<SqlParameter>() {
                        new SqlParameter("@Id", Id)
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

        public IResultadoConsulta Insertar(Common.Entities.Agenda Obj)
        {
            IResultadoConsulta Resultado = new ResultadoGenericoImpl();

            try
            {
                ConsultaT_Sql Consulta = new ConsultaT_Sql()
                {
                    ConsultaCruda = @"INSERT INTO age.Agendas(Nombre, Descripcion) 
                                    VALUES(@Nombre, @Descripcion); 
                                    SELECT CAST(SCOPE_IDENTITY() AS INT) AS Id;",
                    Parametros = new List<SqlParameter>()
                    {
                        new SqlParameter("@Nombre", Obj.Nombre),
                        new SqlParameter("@Descripcion", string.IsNullOrEmpty(Obj.Descripcion) ?  DBNull.Value.ToString() : Obj.Descripcion)
                    },
                    TipoConsulta = TipoConsultaEnum.Insert,
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

        public IResultadoConsulta Modificar(Common.Entities.Agenda Obj)
        {
            IResultadoConsulta Resultado = new ResultadoGenericoImpl();

            try
            {
                ConsultaT_Sql Consulta = new ConsultaT_Sql()
                {
                    ConsultaCruda = @"UPDATE age.Agendas SET Nombre=@Nombre, Descripcion=@Descripcion WHERE Id=@Id;",
                    Parametros = new List<SqlParameter>()
                    {
                     new SqlParameter("@Id", Obj.Id),
                     new SqlParameter("@Nombre", Obj.Nombre),
                     new SqlParameter("@Descripcion", string.IsNullOrEmpty(Obj.Descripcion) ?  DBNull.Value.ToString() : Obj.Descripcion)
                    },
                    TipoConsulta = TipoConsultaEnum.Update,
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

        public IResultadoConsulta Eliminar(int Id)
        {
            IResultadoConsulta Resultado = new ResultadoGenericoImpl();

            try
            {
                ConsultaT_Sql Consulta = new ConsultaT_Sql()
                {
                    ConsultaCruda = @"DELETE age.Agendas WHERE Id=@Id;",
                    Parametros = new List<SqlParameter>()
                    {
                     new SqlParameter("@Id", Id)
                    },
                    TipoConsulta = TipoConsultaEnum.Delete,
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
