using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;

namespace CGC_GM_FE.WebAppMVC
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new StyleBundle("~/bundles/datatable/css").Include(
                       "~/Scripts/DataTables/jquery.dataTables.min.css",
                       "~/Scripts/DataTables/dataTables.bootstrap.min.css"));

            bundles.Add(new ScriptBundle("~/bundles/datatable/scripts").Include(
                        "~/Scripts/DataTables/jquery.dataTables.min.js",
                        "~/Scripts/DataTables/dataTables.bootstrap.min.js"));           
        }
    }
}