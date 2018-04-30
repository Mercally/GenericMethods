using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CGC_GM_BE.Common.Entities;
using CGC_GM_BE.DataAccess.Context;

namespace CGC_GM_BE.Business
{
    public class Tarea_BL
    {
        public List<Tarea> ConsultaGenerica()
        {
            List<Tarea> Lista = new List<Tarea>();

            using (var DBContexto = new CGC_GM_Contexto())
            {
                Lista = DBContexto
                    .Age_Tarea_Model
                    .Consulta()
                    .ObtenerResultadoLista<Tarea>();

            }

            return Lista;
        }

        public List<Tarea> ConsultaPorAgendaId(int agendaId)
        {
            List<Tarea> Lista = new List<Tarea>();

            using (var DBContexto = new CGC_GM_Contexto())
            {
                Lista = DBContexto
                    .Age_Tarea_Model
                    .ConsultaPorAgendaId(agendaId)
                    .ObtenerResultadoLista<Tarea>();
            }

            return Lista;
        }

        public Tarea ConsultaPorId(int Id)
        {
            Tarea Obj = new Tarea();

            using (var DBContexto = new CGC_GM_Contexto())
            {
                Obj = DBContexto
                    .Age_Tarea_Model
                    .ConsultaPorId(Id)
                    .ObtenerResultadoUnico<Tarea>();

                if (Obj != null)
                {
                    Obj.Agenda = DBContexto
                    .Age_Agenda_Model
                    .ConsultaPorId(Obj.AgendaId)
                    .ObtenerResultadoUnico<Agenda>();
                }
            }

            return Obj;
        }

        public int Insertar(Tarea Obj)
        {
            int Id = 0;

            using (var DBContexto = new CGC_GM_Contexto())
            {
                Id = DBContexto
                    .Age_Tarea_Model
                    .Insertar(Obj)
                    .ResultadoTipoInsert;

            }

            return Id;
        }

        public bool Modificar(Tarea Obj)
        {
            bool Cambio = false;

            using (var DBContexto = new CGC_GM_Contexto())
            {
                Cambio = DBContexto
                    .Age_Tarea_Model
                    .Modificar(Obj)
                    .ResultadoTipoUpdate;
            }

            return Cambio;
        }

        public bool Eliminar(int id)
        {
            bool Eliminado = false;

            using (var DBContexto = new CGC_GM_Contexto())
            {
                Eliminado = DBContexto
                    .Age_Tarea_Model
                    .Eliminar(id)
                    .ResultadoTipoDelete;
            }

            return Eliminado;
        }
    }
}
