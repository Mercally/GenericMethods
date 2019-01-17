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
        public static _Resultado<Usuario> ConsultarUsuarioPorUsuarioId(int UsuarioId)
        {
            var Usuario = new _Resultado<Usuario>();

            using (var Contexto = new CGC_GM_Contexto())
            {
                Usuario =
                     Contexto
                    .Seg_UsuariosModelo
                    .ConsultarUsuarioPorUsuarioId(UsuarioId);
            }

            return Usuario;
        }

        public static _Resultado<int> InsertarUsuario(Usuario Usuario)
        {
            var UsuarioId = new _Resultado<int>();

            using (var Contexto = new CGC_GM_Contexto())
            {
                UsuarioId =
                     Contexto
                    .Seg_UsuariosModelo
                    .InsertarUsuario(Usuario);
            }

            return UsuarioId;
        }

        public static _Resultado<bool> ModificarUsuario(Usuario Usuario)
        {
            var Modificado = new _Resultado<bool>();

            using (var Contexto = new CGC_GM_Contexto())
            {
                Modificado =
                     Contexto
                    .Seg_UsuariosModelo
                    .ModificarUsuario(Usuario);
            }

            return Modificado;
        }

        public static _Resultado<bool> EliminarUsuarioPorUsuarioId(int UsuarioId)
        {
            var Eliminado = new _Resultado<bool>();

            using (var Contexto = new CGC_GM_Contexto())
            {
                Eliminado =
                     Contexto
                    .Seg_UsuariosModelo
                    .EliminarUsuario(UsuarioId);
            }

            return Eliminado;
        }
    }
}
