using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CGC_GM_BE.DataAccess.Interface
{
    public interface IResultadoConsulta
    {
        List<T> ObtenerResultadoLista<T>();

        T ObtenerResultadoUnico<T>();

        int ResultadoTipoInsert { get; set; }

        bool ResultadoTipoUpdate { get; set; }

        bool ResultadoTipoDelete { get; set; }

        DataTable ResultadoTipoQuery { get; set; }

        int CantidadCambios { get; set; }

        bool EsCorrecto { get; }

        System.Exception Excepcion { get; set; }
    }
}
