using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CGC_GM_BE.Common.Entities.Modelo;

namespace CGC_GM_BE.Services.Metadata.ServiceTimeManagerApi
{
    public interface IBoletasControllerApi
    {
        List<Boleta> ConsultarBoletasV2();
        _Resultado<List<Boleta>> ConsultarBoletas();
        _Resultado<Boleta> ConsultarBoletaPorId(int BoletaId);
        _Resultado<int> InsertarBoleta(Boleta Boleta);
        _Resultado<bool> ModificarBoleta(Boleta Boleta);
        _Resultado<bool> EliminarBoleta(int BoletaId);
    }
}
