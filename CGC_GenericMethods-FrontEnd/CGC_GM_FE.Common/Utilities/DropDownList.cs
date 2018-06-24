using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CGC_GM_FE.Common.Utilities
{
    public class DropDownList
    {
        public DropDownList(string Texto, object Valor)
        {
            this.Texto = Texto;
            this.Valor = Valor as string;
        }

        public string Texto { get; set; }
        public string Valor { get; set; }
    }
}
