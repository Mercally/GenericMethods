using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using CGC_GM_BE.DataAccess.Interfaces;
using CGC_GM_BE.Common.Entities;
using CGC_GM_BE.Common.Entities.Constantes;

namespace CGC_GM_BE.DataAccess.Modelo
{
    public class Seg_UsuariosModelo : ContextoBase
    {
        public Seg_UsuariosModelo(IContextoCustomizado Contexto) : base(Contexto) { }

        public _Resultado<List<Usuario>> ConsultarUsuarioPorUsuarioId(int UsuarioId)
        {
            _ConsultaT_Sql Consulta = new _ConsultaT_Sql()
            {
                ConsultaCruda = @"SELECT Id, Nombre, Apellido, Correo, FechaRegistro, EsActivo 
                                  FROM seg.Usuarios 
                                  WHERE Id = @UsuarioId;",
                Parametros = new List<SqlParameter>()
                {
                    new SqlParameter("@UsuarioId", UsuarioId)
                },
                TipoConsulta = TipoConsulta.Query
            };

            return Ejecutar<List<Usuario>>(Consulta);
        }

        public _Resultado<int> InsertarUsuario(Usuario Usuario)
        {
            _ConsultaT_Sql Consulta = new _ConsultaT_Sql()
            {
                ConsultaCruda = @"INSERT INTO seg.Usuario(Nombre, Apellido, Correo, Contrasenia, FechaRegistro, EsActivo)  
                                  VALUES(@Nombre, @Apellido, @Correo, @Contrasenia, @FechaRegistro, @EsActivo);
                                  SELECT SCOPE_IDENTITY();",
                Parametros = new List<SqlParameter>() {
                                new SqlParameter("Nombre", Usuario.Nombre),
                                new SqlParameter("Apellido", Usuario.Apellido),
                                new SqlParameter("Correo", Usuario.Correo),
                                new SqlParameter("Contrasenia", Usuario.Contrasenia),
                                new SqlParameter("FechaRegistro", Usuario.FechaRegistro),
                                new SqlParameter("EsActivo", Usuario.EsActivo)
                            },
                TipoConsulta = TipoConsulta.Insert
            };

            return Ejecutar<int>(Consulta);
        }

        public _Resultado<int> ModificarUsuario(Usuario Usuario)
        {
            _ConsultaT_Sql Consulta = new _ConsultaT_Sql()
            {
                ConsultaCruda = @"UPDATE seg.Usuario SET Nombre=@Nombre, Apellido=@Apellido, Correo=@Correo, Contrasenia=@Contrasenia, FechaRegistro=@FechaRegistro, EsActivo=@EsActivo 
                                  WHERE Id = @UsuarioId;",
                Parametros = new List<SqlParameter>() {
                                new SqlParameter("UsuarioId", Usuario.Id),
                                new SqlParameter("Nombre", Usuario.Nombre),
                                new SqlParameter("Apellido", Usuario.Apellido),
                                new SqlParameter("Correo", Usuario.Correo),
                                new SqlParameter("Contrasenia", Usuario.Contrasenia),
                                new SqlParameter("FechaRegistro", Usuario.FechaRegistro),
                                new SqlParameter("EsActivo", Usuario.EsActivo)
                                },
                TipoConsulta = TipoConsulta.Update
            };

            return Ejecutar<int>(Consulta);
        }

        public _Resultado<int> EliminarUsuario(int UsuarioId, bool EsEliminadoFisico = false)
        {
            string ConsultaCruda = string.Empty;

            if (EsEliminadoFisico)
            {
                ConsultaCruda = "DELETE seg.Usuario WHERE Id = @UsuarioId;";
            }
            else
            {
                ConsultaCruda = "UPDATE seg.Usuario SET EsActivo = 0 WHERE Id = @UsuarioId";
            }

            _ConsultaT_Sql Consulta = new _ConsultaT_Sql()
            {
                ConsultaCruda = ConsultaCruda,
                Parametros = new List<SqlParameter>()
                {
                    new SqlParameter("@UsuarioId", UsuarioId)
                },
                TipoConsulta = TipoConsulta.Delete
            };

            return Ejecutar<int>(Consulta);
        }
    }
}
