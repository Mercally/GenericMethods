using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CGC_GM_FE.Common.Models
{
    public class _Resultado<T>
    {
        public _Resultado()
        {

        }

        public _Resultado(Exception exception)
        {
            if (exception == null)
            {
                ListaErrores = new List<Exception>();
            }
            else
            {
                ListaErrores = new List<Exception>() { exception };
            }
        }

        public List<Exception> ListaErrores { get; set; }
        public bool EsCorrecto { get; set; }
        public T Resultado { get; set; }
    }
}
