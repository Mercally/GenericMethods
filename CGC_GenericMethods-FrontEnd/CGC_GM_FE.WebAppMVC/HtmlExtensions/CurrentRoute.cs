using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CGC_GM_FE.WebAppMVC.HtmlExtensions
{
    public class CurrentRoute
    {
        public CurrentRoute(string controller = null)
        {
            this.Action = "";
            this.Controller = controller;
            this.Route = new object();
        }

        public string Controller { get; set; }
        public string Action { get; set; }
        public object Route { get; set; }
    }
}