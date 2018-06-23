using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CGC_GM_BE.Common.Entities;
using CGC_GM_BE.DataAccess;

namespace CGC_GM_BE.Business
{    
    public class CatalogosBL
    {
        public static Catalogo ConsultarCatalogoPorCatalogoId(int CatalogoId, string Tabla)
        {
            var Catalogo = new Catalogo();

            using (var Contexto = new CGC_GM_Contexto())
            {
                Catalogo =
                     Contexto
                    .Cat_CatalogosModelo
                    .ConsultaPorTablaYId(CatalogoId, Tabla)
                    .ConvertiresultadoUnico<Catalogo>();
            }

            return Catalogo;
        }

        public static int InsertarCatalogo(Catalogo Catalogo, string Tabla)
        {
            int CatalogoId = 0;

            using (var Contexto = new CGC_GM_Contexto())
            {
                CatalogoId =
                     Contexto
                    .Cat_CatalogosModelo
                    .InsertarCatalogo(Catalogo, Tabla)
                    .ResultadoTipoInsert;
            }

            return CatalogoId;
        }

        public static bool ModificarCatalogo(Catalogo Catalogo, string Tabla)
        {
            bool Modificado = false;

            using (var Contexto = new CGC_GM_Contexto())
            {
                Modificado =
                     Contexto
                    .Cat_CatalogosModelo
                    .ModificarCatalogo(Catalogo, Tabla)
                    .ResultadoTipoUpdate;
            }

            return Modificado;
        }

        public static bool EliminarCatalogoPorCatalogoId(int CatalogoId, string Tabla)
        {
            bool Eliminado = false;

            using (var Contexto = new CGC_GM_Contexto())
            {
                Eliminado =
                     Contexto
                    .Cat_CatalogosModelo
                    .EliminarCatalogo(CatalogoId, Tabla)
                    .ResultadoTipoUpdate;
            }

            return Eliminado;
        }
    }
}
