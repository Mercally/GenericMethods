using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using CGC_GM_BE.Common.Entities.Modelo;
using CGC_GM_BE.DataAccess.Interfaces;
using CGC_GM_BE.Common.Extensions;

namespace CGC_GM_BE.DataAccess.Modelo
{
    public class Cat_CatalogosModelo : ContextoBase
    {
        public Cat_CatalogosModelo(IContextoCustomizado Contexto) 
            : base(Contexto) { }

        public _Resultado<List<Catalogo>> ConsultaPorTabla(string Tabla)
        {
            _ConsultaT_Sql Consulta = new _ConsultaT_Sql()
            {
                ConsultaCruda = $@"SELECT Id, Nombre, FechaRegistro, EsActivo 
                                   FROM cat.{Tabla};",
                _TipoConsulta = TipoConsulta.Query
            };

            return Ejecutar<List<Catalogo>>(Consulta);
        }

        public _Resultado<Catalogo> ConsultaPorTablaYId(int Id, string Tabla)
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
                _TipoConsulta = TipoConsulta.Query
            };

            return Ejecutar<Catalogo>(Consulta);
        }

        public _Resultado<List<Catalogo>> ConsultaPorTabla(string Tabla, bool SoloActivos = true)
        {
            _ConsultaT_Sql Consulta = new _ConsultaT_Sql()
            {
                ConsultaCruda = $@"SELECT Id, Nombre, FechaRegistro, EsActivo 
                                   FROM cat.{Tabla} ",
                _TipoConsulta = TipoConsulta.Query
            };

            if (SoloActivos)
            {
                Consulta.ConsultaCruda += " WHERE EsActivo = 1;";
            }

            return Ejecutar<List<Catalogo>>(Consulta);
        }

        public _Resultado<int> InsertarCatalogo(Catalogo Catalogo, string Tabla)
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
                _TipoConsulta = TipoConsulta.Insert
            };

            return Ejecutar<int>(Consulta);
        }

        public _Resultado<bool> ModificarCatalogo(Catalogo Catalogo, string Tabla)
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
                _TipoConsulta = TipoConsulta.Update
            };

            return Ejecutar<bool>(Consulta);
        }

        public _Resultado<bool> EliminarCatalogo(int Id, string Tabla, bool EsEliminadoFisico = false)
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
                _TipoConsulta = TipoConsulta.Delete
            };

            return Ejecutar<bool>(Consulta);
        }
    }
}
