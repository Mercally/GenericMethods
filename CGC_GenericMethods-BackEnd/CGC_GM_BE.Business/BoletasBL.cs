using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CGC_GM_BE.Common.Entities;
using CGC_GM_BE.DataAccess;

namespace CGC_GM_BE.Business
{
    public class BoletasBL
    {
        public static _Resultado<List<Boleta>> ConsultarBoletas()
        {
            var Boletas = new _Resultado<List<Boleta>>();

            using (var Contexto = new CGC_GM_Contexto())
            {
                Boletas =
                     Contexto
                    .Com_BoletasModelo
                    .ConsultarBoletas();
            }

            return Boletas;
        }

        public static List<Boleta> ConsultarBoletasV2()
        {
            var Boletas = new List<Boleta>();

            using (var Contexto = new CGC_GM_Contexto())
            {
                Boletas =
                     Contexto
                    .Com_BoletasModelo
                    .ConsultarBoletasV2()
                    .ConvertirResultadoLista();
            }

            return Boletas;
        }

        public static _Resultado<Boleta> ConsultarBoletaPorBoletaId(int BoletaId)
        {
            var Boleta = new _Resultado<Boleta>();

            using (var Contexto = new CGC_GM_Contexto())
            {
                Boleta =
                     Contexto
                    .Com_BoletasModelo
                    .ConsultaPorBoletaId(BoletaId);
            }

            return Boleta;
        }

        public static _Resultado<int> InsertarBoleta(Boleta Boleta)
        {
            var BoletaId = new _Resultado<int>();

            using (var Contexto = new CGC_GM_Contexto())
            {
                BoletaId =
                     Contexto
                    .Com_BoletasModelo
                    .InsertarBoleta(Boleta);
            }

            return BoletaId;
        }

        public static _Resultado<bool> ModificarBoleta(Boleta Boleta)
        {
            var Modificado = new _Resultado<bool>();

            using (var Contexto = new CGC_GM_Contexto())
            {
                Modificado =
                     Contexto
                    .Com_BoletasModelo
                    .ModificarBoleta(Boleta);
            }

            return Modificado;
        }

        public static _Resultado<bool> EliminarBoletaPorBoletaId(int BoletaId)
        {
            var Eliminado = new _Resultado<bool>();

            using (var Contexto = new CGC_GM_Contexto())
            {
                Eliminado =
                 Contexto
                .Com_BoletasModelo
                .EliminarBoleta(BoletaId);
            }

            return Eliminado;
        }
    }
}
