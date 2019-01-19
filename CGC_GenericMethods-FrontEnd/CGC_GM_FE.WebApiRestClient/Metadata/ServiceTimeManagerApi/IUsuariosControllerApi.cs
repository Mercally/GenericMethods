using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CGC_GM_FE.Common.Models;

namespace CGC_GM_FE.WebApiRestClient.Metadata.ServiceTimeManagerApi
{
    public interface IUsuariosControllerApi
    {
        _Resultado<Usuario> ConsultarUsuarioPorId(int UsuarioId);
        _Resultado<int> InsertarUsuario(Usuario Usuario);
        _Resultado<bool> ModificarUsuario(Usuario Usuario);
        _Resultado<bool> EliminarUsuario(int UsuarioId);
    }
}
