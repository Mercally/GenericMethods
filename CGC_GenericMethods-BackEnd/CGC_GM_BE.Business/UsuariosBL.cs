using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CGC_GM_BE.Common.Entities;
using CGC_GM_BE.DataAccess;

namespace CGC_GM_BE.Business
{    
    public class UsuariosBL
    {
        public static Usuario ConsultarUsuarioPorUsuarioId(int UsuarioId)
        {
            var Usuario = new Usuario();

            using (var Contexto = new CGC_GM_Contexto())
            {
                Usuario =
                     Contexto
                    .Seg_UsuariosModelo
                    .ConsultarUsuarioPorUsuarioId(UsuarioId)
                    .ConvertiresultadoUnico<Usuario>();
            }

            return Usuario;
        }

        public static int InsertarUsuario(Usuario Usuario)
        {
            int UsuarioId = 0;

            using (var Contexto = new CGC_GM_Contexto())
            {
                UsuarioId =
                     Contexto
                    .Seg_UsuariosModelo
                    .InsertarUsuario(Usuario)
                    .ResultadoTipoInsert;
            }

            return UsuarioId;
        }

        public static bool ModificarUsuario(Usuario Usuario)
        {
            bool Modificado = false;

            using (var Contexto = new CGC_GM_Contexto())
            {
                Modificado =
                     Contexto
                    .Seg_UsuariosModelo
                    .ModificarUsuario(Usuario)
                    .ResultadoTipoUpdate;
            }

            return Modificado;
        }

        public static bool EliminarUsuarioPorUsuarioId(int UsuarioId)
        {
            bool Eliminado = false;

            using (var Contexto = new CGC_GM_Contexto())
            {
                Eliminado =
                     Contexto
                    .Seg_UsuariosModelo
                    .EliminarUsuario(UsuarioId)
                    .ResultadoTipoUpdate;
            }

            return Eliminado;
        }
    }
}
