using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CGC_GM_BE.Common.Entities;

namespace CGC_GM_BE.Services.Metadata.ServiceAgendaApi
{
    public interface IAgendasControllerApi
    {
        List<Agenda> ObtenerAgendas();
        List<Agenda> ObtenerAgendasPaginadas(int NumeroPagina, int TamanoPagina, string Filtro, string Valor);
        int InsertarAgenda(Agenda obj);
        Agenda ObtenerAgendaPorId(int id);
        bool ModificarAgenda(Agenda obj);
        bool EliminarAgenda(int id);
        bool EliminarAgendaYTareas(int id);
    }
}
