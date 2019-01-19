using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CGC_GM_FE.WebAppMVC.Models.Utilities
{
    public class Redirects
    {
        public Redirects(string urlRedirect, string nameRedirect)
        {
            UrlRedirect = urlRedirect;
            NameRedirect = nameRedirect;
        }
        public string UrlRedirect { get; set; }
        public string NameRedirect { get; set; }
    }
}