using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using CGC_GM_BE.Common.Entities.Modelo;
using CGC_GM_BE.DataAccess.Interfaces;
using CGC_GM_BE.Common.Entities.Constantes;

namespace CGC_GM_BE.DataAccess.Modelo
{
    public class Neg_ProyectosModelo : ContextoBase
    {
        public Neg_ProyectosModelo(IContextoCustomizado Contexto)
            : base(Contexto) { }

        public _Resultado<List<Proyecto>> ConsultaProyectos()
        {
            _ConsultaT_Sql Consulta = new _ConsultaT_Sql()
            {
                ConsultaCruda = @"SELECT Id, Nombre, FechaRegistro, EsActivo 
                                  FROM neg.Proyecto 
                                  WHERE EsActivo = 1;",
                TipoConsulta = TipoConsulta.Query
            };

            return Ejecutar<List<Proyecto>>(Consulta);
        }

        public _Resultado<Proyecto> ConsultaPorProyectoId(int ProyectoId)
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
                TipoConsulta = TipoConsulta.Query
            };

            return Ejecutar<Proyecto>(Consulta);
        }

        public _Resultado<int> InsertarProyecto(Proyecto Proyecto)
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
                TipoConsulta = TipoConsulta.Insert
            };

            return Ejecutar<int>(Consulta);
        }

        public _Resultado<bool> ModificarProyecto(Proyecto Proyecto)
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
                TipoConsulta = TipoConsulta.Update
            };

            return Ejecutar<bool>(Consulta);
        }

        public _Resultado<bool> EliminarProyecto(int ProyectoId, bool EsEliminadoFisico = false)
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
                TipoConsulta = TipoConsulta.Delete
            };

            return Ejecutar<bool>(Consulta);
        }
    }
}
