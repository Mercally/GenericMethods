using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CGC_GM_FE.Models;

namespace CGC_GM_FE.WebApiRestClient.Metadata.ServiceSeguridadApi
{
    internal interface IUsuariosControllerApi
    {
        List<Usuario> ObtenerUsuarios();
    }
}
