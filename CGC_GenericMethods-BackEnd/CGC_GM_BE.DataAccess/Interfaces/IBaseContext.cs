using CGC_GM_BE.DataAccess.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CGC_GM_BE.DataAccess.Interfaces
{
    public interface IBaseContext
    {
        _Resultado Ejecutar(_ConsultaT_Sql Consulta);
    }
}
