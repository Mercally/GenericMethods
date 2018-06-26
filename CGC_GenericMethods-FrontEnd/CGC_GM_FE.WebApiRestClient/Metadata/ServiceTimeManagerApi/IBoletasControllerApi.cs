using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CGC_GM_FE.Common.Models;

namespace CGC_GM_FE.WebApiRestClient.Metadata.ServiceTimeManagerApi
{
    public interface IBoletasControllerApi
    {
        List<Boleta> ConsultarBoletasV2();
        List<Boleta> ConsultarBoletas();
        Boleta ConsultarBoletaPorId(int BoletaId);
        int InsertarBoleta(Boleta Boleta);
        bool ModificarBoleta(Boleta Boleta);
        bool EliminarBoleta(int BoletaId);
    }
}
