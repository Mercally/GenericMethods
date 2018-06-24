using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CGC_GM_FE.Common.Models;

namespace CGC_GM_FE.WebApiRestClient.Metadata.ServiceTimeManagerApi
{
    public interface IActividadesControllerApi
    {
        List<Actividad> ConsultarActividadesPorBoletaId(int BoletaId);
        Actividad ConsultarActividadPorId(int ActividadId);
        int InsertarActividad(Actividad Actividad);
        bool ModificarActividad(Actividad Actividad);
        bool EliminarActividad(int ActividadId);
    }
}
