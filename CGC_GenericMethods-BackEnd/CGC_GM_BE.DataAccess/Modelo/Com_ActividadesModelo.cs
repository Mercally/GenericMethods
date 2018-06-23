using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CGC_GM_BE.Common.Entities;
using CGC_GM_BE.DataAccess.Interfaces;

namespace CGC_GM_BE.DataAccess.Modelo
{
    public class Com_ActividadesModelo : ContextoBase
    {
        public Com_ActividadesModelo(IContextoCustomizado Contexto)
            : base(Contexto) { }

        public _Resultado ConsultaPorBoletaId(int BoletaId, bool SoloActivos = true)
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
                TipoConsulta = _TipoConsultaEnum.Query
            };

            if (SoloActivos)
            {
                Consulta.ConsultaCruda += " AND EsActivo = 1;";
            }

            return base.Ejecutar(Consulta);
        }

        public _Resultado ConsultaPorActividadId(int ActividadId)
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
                TipoConsulta = _TipoConsultaEnum.Query
            };

            return base.Ejecutar(Consulta);
        }

        public _Resultado InsertarActividad(Actividad Actividad)
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
                TipoConsulta = _TipoConsultaEnum.Insert
            };

            return base.Ejecutar(Consulta);
        }

        public _Resultado ModificarActividad(Actividad Actividad)
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
                TipoConsulta = _TipoConsultaEnum.Update
            };

            return base.Ejecutar(Consulta);
        }

        public _Resultado EliminarActividad(int ActividadId, bool EsEliminadoFisico = false)
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
                TipoConsulta = _TipoConsultaEnum.Delete
            };

            return base.Ejecutar(Consulta);
        }
    }
}