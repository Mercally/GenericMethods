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
        Usuario ConsultarUsuarioPorId(int UsuarioId);
        int InsertarUsuario(Usuario Usuario);
        bool ModificarUsuario(Usuario Usuario);
        bool EliminarUsuario(int UsuarioId);
    }
}
