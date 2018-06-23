using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CGC_GM_BE.Common.Entities;

namespace CGC_GM_BE.Services.Metadata.ServiceTimeManagerApi
{
    public interface ICatalogosControllerApi
    {
        Catalogo ConsultarCatalogoPorId(int CatalogoId, string Tabla);
        int InsertarCatalogo(Catalogo Catalogo, string Tabla);
        bool ModificarCatalogo(Catalogo Catalogo, string Tabla);
        bool EliminarCatalogo(int CatalogoId, string Tabla);
    }
}
