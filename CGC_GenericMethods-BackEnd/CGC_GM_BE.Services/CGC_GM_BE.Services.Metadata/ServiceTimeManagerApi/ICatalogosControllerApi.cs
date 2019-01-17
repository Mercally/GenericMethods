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
        _Resultado<List<Catalogo>> ConsultarCatalogoPorTabla(string Tabla);
        _Resultado<Catalogo> ConsultarCatalogoPorId(int CatalogoId, string Tabla);
        _Resultado<int> InsertarCatalogo(Catalogo Catalogo, string Tabla);
        _Resultado<bool> ModificarCatalogo(Catalogo Catalogo, string Tabla);
        _Resultado<bool> EliminarCatalogo(int CatalogoId, string Tabla);
    }
}
