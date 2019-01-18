using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CGC_GM_BE.Common.Entities.Modelo;

namespace CGC_GM_BE.Services.Metadata.ServiceTimeManagerApi
{
    public interface IProyectosControllerApi
    {
        _Resultado<List<Proyecto>> ConsultarProyectos();
        _Resultado<Proyecto> ConsultarProyectoPorId(int ProyectoId);
        _Resultado<int> InsertarProyecto(Proyecto Proyecto);
        _Resultado<bool> ModificarProyecto(Proyecto Proyecto);
        _Resultado<bool> EliminarProyecto(int ProyectoId);
    }
}
