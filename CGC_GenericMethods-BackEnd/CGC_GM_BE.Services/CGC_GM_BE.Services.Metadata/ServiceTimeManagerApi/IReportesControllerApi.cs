using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CGC_GM_BE.Common.Entities.Modelo;

namespace CGC_GM_BE.Services.Metadata.ServiceTimeManagerApi
{
    public interface IReportesControllerApi
    {
        _Resultado<List<RptBoletas>> ReporteBoletasFechas(string fechaEntrada, string fechaSalida);

    }
}
