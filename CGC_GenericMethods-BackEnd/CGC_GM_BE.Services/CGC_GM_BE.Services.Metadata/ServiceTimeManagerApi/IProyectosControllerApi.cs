using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CGC_GM_BE.Common.Entities;

namespace CGC_GM_BE.Services.Metadata.ServiceTimeManagerApi
{
    public interface IProyectosControllerApi
    {
        List<Proyecto> ConsultarProyectos();
        Proyecto ConsultarProyectoPorId(int ProyectoId);
        int InsertarProyecto(Proyecto Proyecto);
        bool ModificarProyecto(Proyecto Proyecto);
        bool EliminarProyecto(int ProyectoId);
    }
}
