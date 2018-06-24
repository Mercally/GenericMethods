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
        public static List<Boleta> ConsultarBoletas()
        {
            var Boletas = new List<Boleta>();

            using (var Contexto = new CGC_GM_Contexto())
            {
                Boletas =
                     Contexto
                    .Com_BoletasModelo
                    .ConsultarBoletas()
                    .ConvertirResultadoLista<Boleta>();
            }

            return Boletas;
        }

        public static Boleta ConsultarBoletaPorBoletaId(int BoletaId)
        {
            var Boleta = new Boleta();

            using (var Contexto = new CGC_GM_Contexto())
            {
                Boleta =
                     Contexto
                    .Com_BoletasModelo
                    .ConsultaPorBoletaId(BoletaId)
                    .ConvertiresultadoUnico<Boleta>();
            }

            return Boleta;
        }

        public static int InsertarBoleta(Boleta Boleta)
        {
            int BoletaId = 0;

            using (var Contexto = new CGC_GM_Contexto())
            {
                BoletaId =
                     Contexto
                    .Com_BoletasModelo
                    .InsertarBoleta(Boleta)
                    .ResultadoTipoInsert;
            }

            return BoletaId;
        }

        public static bool ModificarBoleta(Boleta Boleta)
        {
            bool Modificado = false;

            using (var Contexto = new CGC_GM_Contexto())
            {
                Modificado =
                     Contexto
                    .Com_BoletasModelo
                    .ModificarBoleta(Boleta)
                    .ResultadoTipoUpdate;
            }

            return Modificado;
        }

        public static bool EliminarBoletaPorBoletaId(int BoletaId)
        {
            bool Eliminado = false;

            using (var Contexto = new CGC_GM_Contexto())
            {
                Eliminado =
                     Contexto
                    .Com_BoletasModelo
                    .EliminarBoleta(BoletaId)
                    .ResultadoTipoUpdate;
            }

            return Eliminado;
        }
    }
}
