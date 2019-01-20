using System.Web;
using System.Web.Mvc;

namespace CGC_GM_BE.Services.ServiceTimeManagerApi
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
