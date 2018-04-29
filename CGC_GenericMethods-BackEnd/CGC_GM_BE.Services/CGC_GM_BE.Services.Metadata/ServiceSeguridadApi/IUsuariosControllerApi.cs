using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CGC_GM_BE.Common.Entities;

namespace CGC_GM_BE.Services.Metadata.ServiceSeguridadApi
{
    public interface IUsuariosControllerApi
    {
        List<Usuario> ObtenerUsuarios();
    }
}
