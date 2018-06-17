using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
//> usings
using CGC_GM_BE.Common.Entities;
using CGC_GM_BE.DataAccess.Interface;
using CGC_GM_BE.DataAccess.Implement;
using CGC_GM_BE.DataAccess.Context;

namespace CGC_GM_BE.DataAccess.Model
{
    public class Age_Tarea_Model : CGC_GM_Contexto
    {
        public IResultadoConsulta Consulta()
        {
            IResultadoConsulta Resultado = new ResultadoGenericoImpl();

            try
            {
                _ConsultaT_Sql Consulta = new _ConsultaT_Sql() // Ingresar consulta
                {
                    ConsultaCruda =
                    @"SELECT t.Id, t.AgendaId, t.Nombre, t.Descripcion, t.FechaVencimiento, t.FechaRecordatorio, t.EstadoId, c.Valor AS EstadoDescripcion 
                    FROM age.Tareas AS t 
                    INNER JOIN cat.Catalogos AS c ON c.Id = t.EstadoId;",
                    TipoConsulta = _TipoConsultaEnum.Query
                };

                Resultado = Comandos.Ejecutar(Consulta); // Obtener tipo de resultado

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
                    ConsultaCruda = @"SELECT t.Id, t.AgendaId, t.Nombre, t.Descripcion, t.FechaVencimiento, t.FechaRecordatorio, t.EstadoId, c.Valor AS EstadoDescripcion
                                    FROM age.Tareas AS t 
                                    INNER JOIN cat.Catalogos AS c ON c.Id = t.EstadoId 
                                    WHERE t.Id=@Id;",
                    Parametros = new List<SqlParameter>()
                    {
                        new SqlParameter("@Id", Id)
                    },
                    TipoConsulta = _TipoConsultaEnum.Query
                };

                Resultado = Comandos.Ejecutar(Consulta); // Obtener tipo de resultado

            }
            catch (Exception ex)
            {
                Resultado.Excepcion = ex;
                Excepciones.Add(ex);
            }

            return Resultado;
        }

        public IResultadoConsulta ConsultaPorAgendaId(int AgendaId)
        {
            IResultadoConsulta Resultado = new ResultadoGenericoImpl();

            try
            {
                _ConsultaT_Sql Consulta = new _ConsultaT_Sql() // Ingresar consulta
                {
                    ConsultaCruda = @"SELECT Id, AgendaId, Nombre, Descripcion FROM age.Tareas WHERE AgendaId=@AgendaId;",
                    Parametros = new List<SqlParameter>()
                    {
                        new SqlParameter("@AgendaId", AgendaId)
                    },
                    TipoConsulta = _TipoConsultaEnum.Query
                };

                Resultado = Comandos.Ejecutar(Consulta); // Obtener tipo de resultado

            }
            catch (Exception ex)
            {
                Resultado.Excepcion = ex;
                Excepciones.Add(ex);
            }

            return Resultado;
        }

        public IResultadoConsulta Insertar(Tarea obj)
        {
            IResultadoConsulta Resultado = new ResultadoGenericoImpl();

            try
            {
                _ConsultaT_Sql Consulta = new _ConsultaT_Sql()
                {
                    ConsultaCruda = @"INSERT INTO age.Tareas(AgendaId, Nombre, Descripcion, EstadoId, FechaVencimiento, FechaRecordatorio) 
                                    VALUES(@AgendaId, @Nombre, @Descripcion, @EstadoId, null, null); 
                                    SELECT CAST(SCOPE_IDENTITY() AS INT) AS Id;",
                    Parametros = new List<SqlParameter>()
                    {
                        new SqlParameter("@AgendaId", obj.AgendaId),
                        new SqlParameter("@Nombre", obj.Nombre),
                        new SqlParameter("@Descripcion", string.IsNullOrEmpty(obj.Descripcion) ?  DBNull.Value.ToString() : obj.Descripcion),
                        new SqlParameter("@EstadoId", obj.EstadoId)
                        //new SqlParameter("@fechaVencimiento", obj.FechaVencimiento),
                        //new SqlParameter("@fechaRecordatorio", obj.FechaRecordatorio)
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

        public IResultadoConsulta Modificar(Tarea obj)
        {
            IResultadoConsulta Resultado = new ResultadoGenericoImpl();

            try
            {
                _ConsultaT_Sql Consulta = new _ConsultaT_Sql()
                {
                    ConsultaCruda = @"UPDATE age.Tareas SET AgendaId=@AgendaId, Nombre=@Nombre, Descripcion=@Descripcion, EstadoId=@EstadoId
                                    WHERE Id=@Id;",
                    Parametros = new List<SqlParameter>()
                    {
                        new SqlParameter("@Id", obj.Id),
                        new SqlParameter("@AgendaId", obj.AgendaId),
                        new SqlParameter("@Nombre", obj.Nombre),
                        new SqlParameter("@Descripcion", string.IsNullOrEmpty(obj.Descripcion) ?  DBNull.Value.ToString() : obj.Descripcion),
                        new SqlParameter("@EstadoId", obj.EstadoId)
                        //new SqlParameter("@fechaVencimiento", obj.FechaVencimiento),
                        //new SqlParameter("@fechaRecordatorio", obj.FechaRecordatorio)
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
                    ConsultaCruda = @"DELETE age.Tareas WHERE Id=@Id;",
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

        public IResultadoConsulta EliminarPorAgendaId(int Id)
        {
            IResultadoConsulta Resultado = new ResultadoGenericoImpl();

            try
            {
                _ConsultaT_Sql Consulta = new _ConsultaT_Sql()
                {
                    ConsultaCruda = @"DELETE age.Tareas WHERE AgendaId=@Id;",
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
