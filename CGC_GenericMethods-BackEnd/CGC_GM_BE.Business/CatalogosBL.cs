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
        public static _Resultado<List<Catalogo>> ConsultarCatalogoPorTabla(string Tabla)
        {
            var ListaCatalogo = new _Resultado<List<Catalogo>>();

            using (var Contexto = new CGC_GM_Contexto())
            {
                ListaCatalogo =
                     Contexto
                    .Cat_CatalogosModelo
                    .ConsultaPorTabla(Tabla);
            }

            return ListaCatalogo;
        }

        public static _Resultado<Catalogo> ConsultarCatalogoPorCatalogoId(int CatalogoId, string Tabla)
        {
            var Catalogo = new _Resultado<Catalogo>();

            using (var Contexto = new CGC_GM_Contexto())
            {
                Catalogo =
                     Contexto
                    .Cat_CatalogosModelo
                    .ConsultaPorTablaYId(CatalogoId, Tabla);
            }

            return Catalogo;
        }

        public static _Resultado<int> InsertarCatalogo(Catalogo Catalogo, string Tabla)
        {
            var CatalogoId = new _Resultado<int>();

            using (var Contexto = new CGC_GM_Contexto())
            {
                CatalogoId =
                     Contexto
                    .Cat_CatalogosModelo
                    .InsertarCatalogo(Catalogo, Tabla);
            }

            return CatalogoId;
        }

        public static _Resultado<bool> ModificarCatalogo(Catalogo Catalogo, string Tabla)
        {
            var Modificado = new _Resultado<bool>();

            using (var Contexto = new CGC_GM_Contexto())
            {
                Modificado =
                     Contexto
                    .Cat_CatalogosModelo
                    .ModificarCatalogo(Catalogo, Tabla);
            }

            return Modificado;
        }

        public static _Resultado<bool> EliminarCatalogoPorCatalogoId(int CatalogoId, string Tabla)
        {
            var Eliminado = new _Resultado<bool>();

            using (var Contexto = new CGC_GM_Contexto())
            {
                Eliminado =
                     Contexto
                    .Cat_CatalogosModelo
                    .EliminarCatalogo(CatalogoId, Tabla);
            }

            return Eliminado;
        }
    }
}
