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
    public class Cat_CatalogosModelo : ContextoBase
    {
        public Cat_CatalogosModelo(IContextoCustomizado Contexto) 
            : base(Contexto) { }

        public _Resultado ConsultaPorTablaYId(int Id, string Tabla)
        {
            _ConsultaT_Sql Consulta = new _ConsultaT_Sql()
            {
                ConsultaCruda = $@"SELECT Id, Nombre, FechaRegistro, EsActivo 
                                   FROM cat.{Tabla} 
                                   WHERE Id = @Id;",
                Parametros = new List<SqlParameter>()
                {
                    new SqlParameter("@Id", Id)
                },
                TipoConsulta = _TipoConsultaEnum.Query
            };

            return Ejecutar(Consulta);
        }

        public _Resultado ConsultaPorTabla(string Tabla, bool SoloActivos = true)
        {
            _ConsultaT_Sql Consulta = new _ConsultaT_Sql()
            {
                ConsultaCruda = $@"SELECT Id, Nombre, FechaRegistro, EsActivo 
                                   FROM cat.{Tabla} ",
                TipoConsulta = _TipoConsultaEnum.Query
            };

            if (SoloActivos)
            {
                Consulta.ConsultaCruda += " WHERE EsActivo = 1;";
            }

            return Ejecutar(Consulta);
        }

        public _Resultado InsertarCatalogo(Catalogo Catalogo, string Tabla)
        {
            _ConsultaT_Sql Consulta = new _ConsultaT_Sql()
            {
                ConsultaCruda = $@"INSERT INTO cat.{Tabla}(Nombre, FechaRegistro, EsActivo)
                                    VALUES(@Nombre, @FechaRegistro, @EsActivo);
                                    SELECT SCOPE_IDENTITY();",
                Parametros = new List<SqlParameter>() {
                                new SqlParameter("Nombre", Catalogo.Nombre),
                                new SqlParameter("FechaRegistro", Catalogo.FechaRegistro),
                                new SqlParameter("EsActivo", Catalogo.EsActivo)
                            },
                TipoConsulta = _TipoConsultaEnum.Insert
            };

            return Ejecutar(Consulta);
        }

        public _Resultado ModificarCatalogo(Catalogo Catalogo, string Tabla)
        {
            _ConsultaT_Sql Consulta = new _ConsultaT_Sql()
            {
                ConsultaCruda = $@"UPDATE cat.{Tabla} SET Nombre=@Nombre, FechaRegistro=@FechaRegistro, EsActivo=@EsActivo
                                   WHERE Id = @Id;",
                Parametros = new List<SqlParameter>() {
                                new SqlParameter("Id", Catalogo.Id),
                                new SqlParameter("Nombre", Catalogo.Nombre),
                                new SqlParameter("FechaRegistro", Catalogo.FechaRegistro),
                                new SqlParameter("EsActivo", Catalogo.EsActivo)
                                },
                TipoConsulta = _TipoConsultaEnum.Update
            };

            return Ejecutar(Consulta);
        }

        public _Resultado EliminarCatalogo(int Id, string Tabla, bool EsEliminadoFisico = false)
        {
            string ConsultaCruda = string.Empty;

            if (EsEliminadoFisico)
            {
                ConsultaCruda = $"DELETE cat.{Tabla} WHERE Id = @Id;";
            }
            else
            {
                ConsultaCruda = $"UPDATE cat.{Tabla} SET EsActivo = 0 WHERE Id = @Id";
            }

            _ConsultaT_Sql Consulta = new _ConsultaT_Sql()
            {
                ConsultaCruda = ConsultaCruda,
                Parametros = new List<SqlParameter>()
                {
                    new SqlParameter("@Id", Id)
                },
                TipoConsulta = _TipoConsultaEnum.Delete
            };

            return Ejecutar(Consulta);
        }
    }
}
