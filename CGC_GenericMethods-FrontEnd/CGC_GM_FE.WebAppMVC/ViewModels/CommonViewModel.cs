using CGC_GM_FE.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CGC_GM_FE.WebAppMVC.ViewModels
{
    public class CommonViewModel
    {
        public virtual MvcHtmlString Card_TitlePage()
        {
            return new MvcHtmlString(string.Empty);
        }

        public virtual MvcHtmlString Card_SubTitlePage()
        {
            return new MvcHtmlString(string.Empty);
        }

        public virtual MvcHtmlString Card_Image()
        {
            return new MvcHtmlString(string.Empty);
        }
    }
}