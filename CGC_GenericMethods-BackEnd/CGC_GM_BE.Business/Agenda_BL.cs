using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CGC_GM_BE.Common.Entities;
using CGC_GM_BE.DataAccess.Context;
using CGC_GM_BE.DataAccess.Model;

namespace CGC_GM_BE.Business
{
    public class Agenda_BL
    {
        public List<Agenda> ConsultaPaginada(int NumeroPagina, int TamanoPagina, string Filtro, string Valor)
        {
            List<Agenda> Lista = new List<Agenda>();
            
            using (var DBContexto = new CGC_GM_Contexto())
            {
                Lista = DBContexto
                        .Age_Agenda_Model
                        .ConsultaPaginada(NumeroPagina, TamanoPagina, Filtro, Valor)
                        .ObtenerResultadoLista<Agenda>();

            }

            return Lista;
        }

        public List<Agenda> ConsultaGenerica()
        {
            List<Agenda> Lista = new List<Agenda>();

            using (var DBContexto = new CGC_GM_Contexto())
            {
                Lista = DBContexto
                        .Age_Agenda_Model
                        .Consulta()
                        .ObtenerResultadoLista<Agenda>();

            }

            return Lista;
        }

        public Agenda ConsultaPorId(int Id)
        {
            Agenda Obj = new Agenda();

            using (var DBContexto = new CGC_GM_Contexto())
            {
                Obj = DBContexto
                    .Age_Agenda_Model
                    .ConsultaPorId(Id)
                    .ObtenerResultadoUnico<Agenda>();

            }

            return Obj;
        }

        public int Insertar(Agenda Obj)
        {
            int Id = 0;

            using (var DBContexto = new CGC_GM_Contexto())
            {
                Id = DBContexto
                    .Age_Agenda_Model
                    .Insertar(Obj)
                    .ResultadoTipoInsert;

            }

            return Id;
        }

        public bool Modificar(Agenda Obj)
        {
            bool Cambio = false;

            using (var DBContexto = new CGC_GM_Contexto())
            {
                Cambio = DBContexto
                    .Age_Agenda_Model
                    .Modificar(Obj)
                    .ResultadoTipoUpdate;

            }

            return Cambio;
        }

        public bool Eliminar(int Id)
        {
            bool Eliminado = false;

            using (var DBContexto = new CGC_GM_Contexto())
            {
                Eliminado = DBContexto
                    .Age_Agenda_Model
                    .Eliminar(Id)
                    .ResultadoTipoDelete;
            }

            return Eliminado;
        }

        public bool EliminarAgendaYTareas(int Id)
        {
            bool Eliminado = false;

            using (var DBContexto = new CGC_GM_Contexto())
            {
                Eliminado = DBContexto
                        .Age_Tarea_Model
                        .EliminarPorAgendaId(Id)
                        .ResultadoTipoDelete;

                if (Eliminado)
                {
                    Eliminado = DBContexto
                        .Age_Agenda_Model
                        .Eliminar(Id)
                        .ResultadoTipoDelete;
                }
            }

            return Eliminado;
        }
    }
}
