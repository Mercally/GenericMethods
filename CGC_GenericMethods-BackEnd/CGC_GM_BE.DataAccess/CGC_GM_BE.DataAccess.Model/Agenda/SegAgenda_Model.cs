using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CGC_GM_BE.Common.Entities;
using CGC_GM_BE.DataAccess.Context.Conexion;
using CGC_GM_BE.DataAccess.Context.Consulta;
using CGC_GM_BE.DataAccess.Context.GenericInterface;

namespace CGC_GM_BE.DataAccess.Model.Agenda
{
    public class AgeAgenda_Model : AjustesComandosGenerico
    {
        public AgeAgenda_Model(int TimeOut = 5) : base(TimeOut) { }

        public IResultadoConsulta Consulta()
        {
            IResultadoConsulta Resultado = new ResultadoGenericoImpl();

            try
            {
                ConsultaT_Sql Consulta = new ConsultaT_Sql()
                {
                    ConsultaCruda = "SELECT Id, Nombre, Descripcion FROM age.Agendas;",
                    TipoConsulta = TipoConsultaEnum.Query,
                    TimeOut = this.TimeOut
                };

                Comandos.Execute(Consulta, Transaccion, Resultado);

            }
            catch (Exception ex)
            {
                Resultado.Excepcion = ex;
                Excepciones.Add(ex);
            }

            return Resultado;
        }

        public IResultadoConsulta ConsultaPorId(int id)
        {
            IResultadoConsulta Resultado = new ResultadoGenericoImpl();

            try
            {
                ConsultaT_Sql Consulta = new ConsultaT_Sql() // Ingresar consulta
                {
                    ConsultaCruda = "SELECT Id, Nombre, Descripcion FROM age.Agendas WHERE Id = @Id;",
                    Parametros = new List<SqlParameter>() {
                        new SqlParameter("@Id", id)
                    },
                    TipoConsulta = TipoConsultaEnum.Query,
                    TimeOut = this.TimeOut
                };

                Comandos.Execute(Consulta, Transaccion, Resultado);

            }
            catch (Exception ex)
            {
                Resultado.Excepcion = ex;
                Excepciones.Add(ex);
            }

            return Resultado;
        }

        public IResultadoConsulta Insertar(Common.Entities.Agenda obj)
        {
            IResultadoConsulta Resultado = new ResultadoGenericoImpl();

            try
            {
                ConsultaT_Sql Consulta = new ConsultaT_Sql()
                {
                    ConsultaCruda = "INSERT INTO age.Agendas(Nombre, Descripcion) " +
                                    "VALUES(@Nombre, @Descripcion); " +
                                    "SELECT CAST(SCOPE_IDENTITY() AS INT) AS Id;",
                    Parametros = new List<SqlParameter>()
                    {
                     new SqlParameter("@Nombre", obj.Nombre),
                     new SqlParameter("@Descripcion", obj.Descripcion)
                    },
                    TipoConsulta = TipoConsultaEnum.Insert,
                    TimeOut = this.TimeOut
                };

                Comandos.Execute(Consulta, Transaccion, Resultado);

            }
            catch (Exception ex)
            {
                Resultado.Excepcion = ex;
                Excepciones.Add(ex);
            }

            return Resultado;
        }

        public IResultadoConsulta Modificar(Common.Entities.Agenda obj)
        {
            IResultadoConsulta Resultado = new ResultadoGenericoImpl();

            try
            {
                ConsultaT_Sql Consulta = new ConsultaT_Sql()
                {
                    ConsultaCruda = "UPDATE age.Agendas SET Nombre=@Nombre, Descripcion=@Descripcion " +
                                    "WHERE Id=@Id;",
                    Parametros = new List<SqlParameter>()
                    {
                     new SqlParameter("@Id", obj.Id),
                     new SqlParameter("@Nombre", obj.Nombre),
                     new SqlParameter("@Descripcion", obj.Descripcion)
                    },
                    TipoConsulta = TipoConsultaEnum.Update,
                    TimeOut = this.TimeOut
                };

                Comandos.Execute(Consulta, Transaccion, Resultado);

            }
            catch (Exception ex)
            {
                Resultado.Excepcion = ex;
                Excepciones.Add(ex);
            }

            return Resultado;
        }

        public IResultadoConsulta Eliminar(int id)
        {
            IResultadoConsulta Resultado = new ResultadoGenericoImpl();

            try
            {
                ConsultaT_Sql Consulta = new ConsultaT_Sql()
                {
                    ConsultaCruda = "DELETE age.Agendas WHERE Id=@Id;",
                    Parametros = new List<SqlParameter>()
                    {
                     new SqlParameter("@Id", id)
                    },
                    TipoConsulta = TipoConsultaEnum.Delete,
                    TimeOut = this.TimeOut
                };

                Comandos.Execute(Consulta, Transaccion, Resultado);

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
