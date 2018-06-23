using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CGC_GM_BE.Common.Entities;
using CGC_GM_BE.DataAccess;

namespace CGC_GM_BE.Business
{    
    public class ActividadesBL
    {
        public static List<Actividad> ConsultarActividadesPorBoletaId(int BoletaId)
        {
            var ListaActividades = new List<Actividad>();

            using (var Contexto = new CGC_GM_Contexto())
            {
                ListaActividades = 
                     Contexto
                    .Com_ActividadesModelo
                    .ConsultaPorBoletaId(BoletaId)
                    .ConvertirResultadoLista<Actividad>();
            }

            return ListaActividades;
        }

        public static Actividad ConsultarActividadPorActividadId(int ActividadId)
        {
            var Actividad = new Actividad();

            using (var Contexto = new CGC_GM_Contexto())
            {
                Actividad =
                     Contexto
                    .Com_ActividadesModelo
                    .ConsultaPorActividadId(ActividadId)
                    .ConvertiresultadoUnico<Actividad>();
            }

            return Actividad;
        }

        public static int InsertarActividad(Actividad Actividad)
        {
            int ActividadId = 0;

            using (var Contexto = new CGC_GM_Contexto())
            {
                ActividadId =
                     Contexto
                    .Com_ActividadesModelo
                    .InsertarActividad(Actividad)
                    .ResultadoTipoInsert;
            }

            return ActividadId;
        }

        public static bool ModificarActividad(Actividad Actividad)
        {
            bool Modificado = false;

            using (var Contexto = new CGC_GM_Contexto())
            {
                Modificado =
                     Contexto
                    .Com_ActividadesModelo
                    .ModificarActividad(Actividad)
                    .ResultadoTipoUpdate;
            }

            return Modificado;
        }

        public static bool EliminarActividadPorActividadId(int ActividadId)
        {
            bool Eliminado = false;

            using (var Contexto = new CGC_GM_Contexto())
            {
                Eliminado =
                     Contexto
                    .Com_ActividadesModelo
                    .EliminarActividad(ActividadId)
                    .ResultadoTipoUpdate;
            }

            return Eliminado;
        }
    }
}
