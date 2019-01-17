using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CGC_GM_BE.Common.Entities;
using CGC_GM_BE.DataAccess;

namespace CGC_GM_BE.Business
{    
    public class ProyectosBL
    {
        public static _Resultado<List<Proyecto>> ConsultarProyectos()
        {
            var ListaProyecto = new _Resultado<List<Proyecto>>();

            using (var Contexto = new CGC_GM_Contexto())
            {
                ListaProyecto =
                     Contexto
                    .Neg_ProyectosModelo
                    .ConsultaProyectos<List<Proyecto>>();
            }

            return ListaProyecto;
        }

        public static _Resultado<Proyecto> ConsultarProyectoPorProyectoId(int ProyectoId)
        {
            var Proyecto = new _Resultado<Proyecto>();

            using (var Contexto = new CGC_GM_Contexto())
            {
                Proyecto =
                     Contexto
                    .Neg_ProyectosModelo
                    .ConsultaPorProyectoId<Proyecto>(ProyectoId);
            }

            return Proyecto;
        }

        public static int InsertarProyecto(Proyecto Proyecto)
        {
            int ProyectoId = 0;

            using (var Contexto = new CGC_GM_Contexto())
            {
                ProyectoId =
                     Contexto
                    .Neg_ProyectosModelo
                    .InsertarProyecto(Proyecto);
            }

            return ProyectoId;
        }

        public static bool ModificarProyecto(Proyecto Proyecto)
        {
            bool Modificado = false;

            using (var Contexto = new CGC_GM_Contexto())
            {
                Modificado =
                     Contexto
                    .Neg_ProyectosModelo
                    .ModificarProyecto(Proyecto);
            }

            return Modificado;
        }

        public static bool EliminarProyectoPorProyectoId(int ProyectoId)
        {
            bool Eliminado = false;

            using (var Contexto = new CGC_GM_Contexto())
            {
                Eliminado =
                     Contexto
                    .Neg_ProyectosModelo
                    .EliminarProyecto(ProyectoId);
            }

            return Eliminado;
        }
    }
}
