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
    public class Neg_ProyectosModelo : ContextoBase
    {
        public Neg_ProyectosModelo(IContextoCustomizado Contexto)
            : base(Contexto) { }

        public _Resultado ConsultaProyectos()
        {
            _ConsultaT_Sql Consulta = new _ConsultaT_Sql()
            {
                ConsultaCruda = @"SELECT Id, Nombre, FechaRegistro, EsActivo 
                                  FROM neg.Proyecto 
                                  WHERE EsActivo = 1;",
                TipoConsulta = _TipoConsultaEnum.Query
            };

            return Ejecutar(Consulta);
        }

        public _Resultado ConsultaPorProyectoId(int ProyectoId)
        {
            _ConsultaT_Sql Consulta = new _ConsultaT_Sql()
            {
                ConsultaCruda = @"SELECT Id, Nombre, FechaRegistro, EsActivo 
                                  FROM neg.Proyecto 
                                  WHERE Id = @ProyectoId;",
                Parametros = new List<SqlParameter>()
                {
                    new SqlParameter("@ProyectoId", ProyectoId)
                },
                TipoConsulta = _TipoConsultaEnum.Query
            };

            return Ejecutar(Consulta);
        }

        public _Resultado InsertarProyecto(Proyecto Proyecto)
        {
            _ConsultaT_Sql Consulta = new _ConsultaT_Sql()
            {
                ConsultaCruda = @"INSERT INTO neg.Proyecto(Nombre, FechaRegistro, EsActivo) 
                                  VALUES(@Nombre, @FechaRegistro, @EsActivo);
                                  SELECT SCOPE_IDENTITY();",
                Parametros = new List<SqlParameter>() {
                                new SqlParameter("Nombre", Proyecto.Nombre),
                                new SqlParameter("FechaRegistro", Proyecto.FechaRegistro),
                                new SqlParameter("EsActivo", Proyecto.EsActivo)
                            },
                TipoConsulta = _TipoConsultaEnum.Insert
            };

            return Ejecutar(Consulta);
        }

        public _Resultado ModificarProyecto(Proyecto Proyecto)
        {
            _ConsultaT_Sql Consulta = new _ConsultaT_Sql()
            {
                ConsultaCruda = @"UPDATE neg.Proyecto SET Nombre=@Nombre, FechaRegistro=@FechaRegistro, EsActivo=@EsActivo 
                                  WHERE Id = @ProyectoId;",
                Parametros = new List<SqlParameter>()
                {
                    new SqlParameter("ProyectoId", Proyecto.Id),
                    new SqlParameter("Nombre", Proyecto.Nombre),
                    new SqlParameter("FechaRegistro", Proyecto.FechaRegistro),
                    new SqlParameter("EsActivo", Proyecto.EsActivo)
                },
                TipoConsulta = _TipoConsultaEnum.Update
            };

            return Ejecutar(Consulta);
        }

        public _Resultado EliminarProyecto(int ProyectoId, bool EsEliminadoFisico = false)
        {
            string ConsultaCruda = string.Empty;

            if (EsEliminadoFisico)
            {
                ConsultaCruda = "DELETE neg.Proyecto WHERE Id = @ProyectoId;";
            }
            else
            {
                ConsultaCruda = "UPDATE neg.Proyecto SET EsActivo = 0 WHERE Id = @ProyectoId";
            }

            _ConsultaT_Sql Consulta = new _ConsultaT_Sql()
            {
                ConsultaCruda = ConsultaCruda,
                Parametros = new List<SqlParameter>()
                {
                    new SqlParameter("@ProyectoId", ProyectoId)
                },
                TipoConsulta = _TipoConsultaEnum.Delete
            };

            return Ejecutar(Consulta);
        }
    }
}
