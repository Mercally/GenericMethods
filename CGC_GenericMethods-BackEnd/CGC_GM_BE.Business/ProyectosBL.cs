using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CGC_GM_BE.Common.Entities.Modelo;
using CGC_GM_BE.DataAccess;

namespace CGC_GM_BE.Business
{    
    public class ProyectosBL
    {
        public static _Resultado<List<Proyecto>> ConsultarProyectos(bool soloActivos)
        {
            var ListaProyecto = new _Resultado<List<Proyecto>>();

            using (var Contexto = new CGC_GM_Contexto())
            {
                ListaProyecto =
                     Contexto
                    .Neg_ProyectosModelo
                    .ConsultaProyectos(soloActivos);
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
                    .ConsultaPorProyectoId(ProyectoId);
            }

            return Proyecto;
        }

        public static _Resultado<int> InsertarProyecto(Proyecto Proyecto)
        {
            var ProyectoId = new _Resultado<int>();

            using (var Contexto = new CGC_GM_Contexto())
            {
                ProyectoId =
                     Contexto
                    .Neg_ProyectosModelo
                    .InsertarProyecto(Proyecto);
            }

            return ProyectoId;
        }

        public static _Resultado<bool> ModificarProyecto(Proyecto Proyecto)
        {
            var Modificado = new _Resultado<bool>();

            using (var Contexto = new CGC_GM_Contexto())
            {
                Modificado =
                     Contexto
                    .Neg_ProyectosModelo
                    .ModificarProyecto(Proyecto);
            }

            return Modificado;
        }

        public static _Resultado<bool> EliminarProyectoPorProyectoId(int ProyectoId)
        {
            var Eliminado = new _Resultado<bool>(); ;

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
