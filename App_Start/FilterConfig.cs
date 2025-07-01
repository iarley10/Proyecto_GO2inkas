using System.Web;
using System.Web.Mvc;

namespace Proyecto_GO2inkas
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
