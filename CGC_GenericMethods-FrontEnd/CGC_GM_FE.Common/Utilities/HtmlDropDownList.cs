using CGC_GM_FE.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace CGC_GM_FE.Common.Utilities
{
    public static class HtmlDropDownList
    {
        public static SelectList SelectList(this IEnumerable<DropDownList> Lista, DropDownList DefaultItem = null)
        {
            List<SelectListItem> ListItems =
                Lista.Select(x =>
                new SelectListItem()
                {
                    Text = x.Texto,
                    Value = x.Valor.StringOrNull()
                }).ToList();

            if (DefaultItem != null)
            {
                ListItems.Insert(0,
                    new SelectListItem()
                    {
                        Text = DefaultItem.Texto,
                        Value = DefaultItem.Valor.StringOrNull()
                    });
            }

            return new SelectList(ListItems, "Value", "Text"); ;
        }

        private static string StringOrNull(this object Value)
        {
            string _Value = string.Empty;

            if (Value == null)
            {
                _Value = string.Empty;
            }
            else
            {
                _Value = Value.ToString();
            }

            return _Value;
        }
    }
}
