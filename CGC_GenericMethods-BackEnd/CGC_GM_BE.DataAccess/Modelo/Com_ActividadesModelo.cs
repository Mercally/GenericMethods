using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CGC_GM_BE.Common.Entities.Modelo;
using CGC_GM_BE.Common.Entities.Constantes;
using CGC_GM_BE.DataAccess.Interfaces;

namespace CGC_GM_BE.DataAccess.Modelo
{
    public class Com_ActividadesModelo : ContextoBase
    {
        public Com_ActividadesModelo(IContextoCustomizado Contexto)
            : base(Contexto) { }

        public _Resultado<List<Actividad>> ConsultaPorBoletaId(int BoletaId, bool SoloActivos = true)
        {
            _ConsultaT_Sql Consulta = new _ConsultaT_Sql()
            {
                ConsultaCruda = @"SELECT Id, BoletaId, Descripcion, EstadoId, FechaActividad, TiempoActividad, FechaRegistro, EsActivo 
                                FROM com.Actividad 
                                WHERE BoletaId = @BoletaId",
                Parametros = new List<SqlParameter>()
                {
                    new SqlParameter("@BoletaId", BoletaId)
                },
                TipoConsulta = TipoConsulta.Query
            };

            if (SoloActivos)
            {
                Consulta.ConsultaCruda += " AND EsActivo = 1;";
            }

            return Ejecutar<List<Actividad>>(Consulta);
        }

        public _Resultado<Actividad> ConsultaPorActividadId(int ActividadId)
        {
            _ConsultaT_Sql Consulta = new _ConsultaT_Sql()
            {
                ConsultaCruda = @"SELECT Id, BoletaId, Descripcion, EstadoId, FechaActividad, TiempoActividad, FechaRegistro, EsActivo 
                                FROM com.Actividad 
                                WHERE Id = @ActividadId",
                Parametros = new List<SqlParameter>()
                {
                    new SqlParameter("@ActividadId", ActividadId)
                },
                TipoConsulta = TipoConsulta.Query
            };

            return Ejecutar<Actividad>(Consulta);
        }

        public _Resultado<int> InsertarActividad(Actividad Actividad)
        {
            _ConsultaT_Sql Consulta = new _ConsultaT_Sql()
            {
                ConsultaCruda = @"INSERT INTO com.Actividad(Descripcion, BoletaId, EstadoId, FechaActividad, TiempoActividad, FechaRegistro, EsActivo) 
                                    VALUES(@Descripcion, @BoletaId, @EstadoId, @FechaActividad, @TiempoActividad, @FechaRegistro, @EsActivo);
                                    SELECT SCOPE_IDENTITY();",
                Parametros = new List<SqlParameter>()
                    {
                        new SqlParameter("Descripcion", Actividad.Descripcion),
                        new SqlParameter("BoletaId", Actividad.BoletaId),
                        new SqlParameter("EstadoId", Actividad.EstadoId),
                        new SqlParameter("FechaActividad", Actividad.FechaActividad),
                        new SqlParameter("TiempoActividad", Actividad.TiempoActividad),
                        new SqlParameter("FechaRegistro", Actividad.FechaRegistro),
                        new SqlParameter("EsActivo", Actividad.EsActivo)
                    },
                TipoConsulta = TipoConsulta.Insert
            };

            return Ejecutar<int>(Consulta);
        }

        public _Resultado<bool> ModificarActividad(Actividad Actividad)
        {
            _ConsultaT_Sql Consulta = new _ConsultaT_Sql()
            {
                ConsultaCruda = @"UPDATE com.Actividad SET Descripcion=@Descripcion, EstadoId=@EstadoId, FechaActividad=@FechaActividad, TiempoActividad=@TiempoActividad 
                                    WHERE Id = @ActividadId;",
                Parametros = new List<SqlParameter>()
                {
                    new SqlParameter("ActividadId", Actividad.Id),
                    new SqlParameter("Descripcion", Actividad.Descripcion),
                    new SqlParameter("EstadoId", Actividad.EstadoId),
                    new SqlParameter("FechaActividad", Actividad.FechaActividad),
                    new SqlParameter("TiempoActividad", Actividad.TiempoActividad)
                },
                TipoConsulta = TipoConsulta.Update
            };

            return Ejecutar<bool>(Consulta);
        }

        public _Resultado<bool> EliminarActividad(int ActividadId, bool EsEliminadoFisico = false)
        {
            string ConsultaCruda = string.Empty;

            if (EsEliminadoFisico)
            {
                ConsultaCruda = "DELETE com.Actividad WHERE Id = @ActividadId;";
            }
            else
            {
                ConsultaCruda = "UPDATE com.Actividad SET EsActivo = 0 WHERE Id = @ActividadId";
            }

            _ConsultaT_Sql Consulta = new _ConsultaT_Sql()
            {
                ConsultaCruda = ConsultaCruda,
                Parametros = new List<SqlParameter>()
                {
                    new SqlParameter("@ActividadId", ActividadId)
                },
                TipoConsulta = TipoConsulta.Delete
            };

            return Ejecutar<bool>(Consulta);
        }
    }
}