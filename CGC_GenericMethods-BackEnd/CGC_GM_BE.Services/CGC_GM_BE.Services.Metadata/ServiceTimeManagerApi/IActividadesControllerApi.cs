using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CGC_GM_BE.Common.Entities.Modelo;

namespace CGC_GM_BE.Services.Metadata.ServiceTimeManagerApi
{
    public interface IActividadesControllerApi
    {
        _Resultado<List<Actividad>> ConsultarActividadesPorBoletaId(int BoletaId);
        _Resultado<Actividad> ConsultarActividadPorId(int ActividadId);
        _Resultado<int> InsertarActividad(Actividad Actividad);
        _Resultado<bool> ModificarActividad(Actividad Actividad);
        _Resultado<bool> EliminarActividad(int ActividadId);
    }
}
