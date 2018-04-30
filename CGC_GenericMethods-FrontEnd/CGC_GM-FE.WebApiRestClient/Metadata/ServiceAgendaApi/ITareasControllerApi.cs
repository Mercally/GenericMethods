using CGC_GM_FE.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CGC_GM_FE.WebApiRestClient.Metadata.ServiceAgendaApi
{
    public interface ITareasControllerApi
    {
        List<Tarea> ObtenerTareas();
        List<Tarea> ObtenerTareasPorAgendaId(int agendaId);
        int InsertarTarea(Tarea obj);
        Tarea ObtenerTareaPorId(int id);
        bool ModificarTarea(Tarea obj);
        bool EliminarTarea(int id);
    }
}
