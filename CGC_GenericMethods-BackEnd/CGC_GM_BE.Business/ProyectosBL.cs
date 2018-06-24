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
        public static List<Proyecto> ConsultarProyectos()
        {
            var ListaProyecto = new List<Proyecto>();

            using (var Contexto = new CGC_GM_Contexto())
            {
                ListaProyecto =
                     Contexto
                    .Neg_ProyectosModelo
                    .ConsultaProyectos()
                    .ConvertirResultadoLista<Proyecto>();
            }

            return ListaProyecto;
        }

        public static Proyecto ConsultarProyectoPorProyectoId(int ProyectoId)
        {
            var Proyecto = new Proyecto();

            using (var Contexto = new CGC_GM_Contexto())
            {
                Proyecto =
                     Contexto
                    .Neg_ProyectosModelo
                    .ConsultaPorProyectoId(ProyectoId)
                    .ConvertiresultadoUnico<Proyecto>();
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
                    .InsertarProyecto(Proyecto)
                    .ResultadoTipoInsert;
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
                    .ModificarProyecto(Proyecto)
                    .ResultadoTipoUpdate;
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
                    .EliminarProyecto(ProyectoId)
                    .ResultadoTipoUpdate;
            }

            return Eliminado;
        }
    }
}
