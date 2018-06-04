using CGC_GM_BE.Common.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CGC_GM_BE.Services.Metadata.ServiceCatalogoApi
{
    public interface ICatalogosControllerApi
    {
        Catalogo ObtenerCatalogoPorId(int id);
        List<Catalogo> ObtenerCatalogo(string Tabla, string Campo);
    }
}
