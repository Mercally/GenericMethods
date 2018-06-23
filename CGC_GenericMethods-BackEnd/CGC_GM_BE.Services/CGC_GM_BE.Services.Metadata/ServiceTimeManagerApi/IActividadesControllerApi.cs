using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CGC_GM_BE.Common.Entities;

namespace CGC_GM_BE.Services.Metadata.ServiceTimeManagerApi
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
