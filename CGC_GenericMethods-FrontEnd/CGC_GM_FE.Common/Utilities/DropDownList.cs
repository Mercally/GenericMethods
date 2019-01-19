using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CGC_GM_FE.Common.Utilities
{
    /// <summary>
    /// Crea un elemento de DropDown
    /// </summary>
    public class DropDownList
    {
        public DropDownList(string Texto, object Valor)
        {
            this.Texto = Texto;
            this.Valor = Valor;
        }

        public string Texto { get; set; }
        public object Valor { get; set; }
    }
}
