using CGC_GM_FE.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CGC_GM_FE.WebApiRestClient.Metadata.ServiceTimeManagerApi
{
    public interface IReportesControllerApi
    {
        _Resultado<List<RptBoletas>> ReporteBoletasFechas(DateTime fechaEntrada, DateTime fechaSalida);
    }
}
