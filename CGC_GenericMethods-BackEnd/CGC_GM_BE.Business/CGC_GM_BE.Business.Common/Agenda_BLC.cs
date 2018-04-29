using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CGC_GM_BE.Common.Entities;
using CGC_GM_BE.DataAccess.Context.GenericInterface;
using CGC_GM_BE.DataAccess.Model.Agenda;

namespace CGC_GM_BE.Business.Common
{
    public class Agenda_BLC
    {
        public List<Agenda> ConsultaGenerica()
        {
            List<Agenda> Lista = new List<Agenda>();

            // Transaccion termina con el bloque using
            using (var ConsultasAgeAgenda = new AgeAgenda_Model())
            {
                Lista = ConsultasAgeAgenda
                        .Consulta()
                        .ObtenerResultadoLista<Agenda>();

            }

            return Lista;
        }

        public Agenda ConsultaPorId(int Id)
        {
            Agenda Obj = new Agenda();

            // Transaccion termina con el bloque using
            using (var ConsultasAgeAgenda = new AgeAgenda_Model())
            {
                Obj = ConsultasAgeAgenda
                        .ConsultaPorId(Id)
                        .ObtenerResultadoUnico<Agenda>();

            }

            return Obj;
        }

        public int Insertar(Agenda Obj)
        {
            int Id = 0;

            // Transaccion termina con el bloque using
            using (var ConsultasAgeAgenda = new AgeAgenda_Model())
            {
                Id = ConsultasAgeAgenda
                        .Insertar(Obj)
                        .ResultadoTipoInsert;

            }

            return Id;
        }

        public bool Modificar(Agenda Obj)
        {
            bool Cambio = false;

            // Transaccion termina con el bloque using
            using (var ConsultasAgeAgenda = new AgeAgenda_Model())
            {
                Cambio = ConsultasAgeAgenda
                        .Modificar(Obj)
                        .ResultadoTipoUpdate;

            }

            return Cambio;
        }

        public bool Eliminar(int id)
        {
            bool Eliminado = false;

            using (var ConsultasAgeAgenda = new AgeAgenda_Model())
            {
                Eliminado = ConsultasAgeAgenda
                    .Eliminar(id)
                    .ResultadoTipoDelete;
            }

            return Eliminado;
        }
    }
}
