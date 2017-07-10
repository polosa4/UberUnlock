using System.Web;
using System.Web.Mvc;

namespace UberUnlock
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
            filters.Add(new CategoryFilter());
        }
    }
}
