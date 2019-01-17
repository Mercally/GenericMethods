using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CGC_GM_BE.Common.Entities;
using CGC_GM_BE.Common.Exceptions;
using CGC_GM_BE.DataAccess;

namespace CGC_GM_BE.Business
{
    public class ActividadesBL
    {
        public static _Resultado<List<Actividad>> ConsultarActividadesPorBoletaId(int BoletaId)
        {
            _Resultado<List<Actividad>> ListaActividades = null;

            try
            {
                using (var Contexto = new CGC_GM_Contexto())
                {
                    ListaActividades =
                         Contexto
                        .Com_ActividadesModelo
                        .ConsultaPorBoletaId(BoletaId);
                }
            }
            catch (Exception ex)
            {
                ManageExceptions.AddExceptionBL(ListaActividades, ex);
            }

            return ListaActividades;
        }

        public static _Resultado<Actividad> ConsultarActividadPorActividadId(int ActividadId)
        {
            var Actividad = new _Resultado<Actividad>();

            try
            {
                using (var Contexto = new CGC_GM_Contexto())
                {
                    Actividad =
                         Contexto
                        .Com_ActividadesModelo
                        .ConsultaPorActividadId(ActividadId);
                }

            }
            catch (Exception ex)
            {
                ManageExceptions.AddExceptionBL(Actividad, ex);
            }

            return Actividad;
        }

        public static _Resultado<int> InsertarActividad(Actividad Actividad)
        {
            var ActividadId = new _Resultado<int>();

            using (var Contexto = new CGC_GM_Contexto())
            {
                ActividadId =
                     Contexto
                    .Com_ActividadesModelo
                    .InsertarActividad(Actividad);
            }

            return ActividadId;
        }

        public static _Resultado<bool> ModificarActividad(Actividad Actividad)
        {
            var Modificado = new _Resultado<bool>();

            using (var Contexto = new CGC_GM_Contexto())
            {
                Modificado =
                     Contexto
                    .Com_ActividadesModelo
                    .ModificarActividad(Actividad);
            }

            return Modificado;
        }

        public static _Resultado<bool> EliminarActividadPorActividadId(int ActividadId)
        {
            var Eliminado = new _Resultado<bool>();

            using (var Contexto = new CGC_GM_Contexto())
            {
                Eliminado =
                     Contexto
                    .Com_ActividadesModelo
                    .EliminarActividad(ActividadId);
            }

            return Eliminado;
        }
    }
}
