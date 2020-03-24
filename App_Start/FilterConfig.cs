using System.Web;
using System.Web.Mvc;
using Arctodus.Filters;

namespace Arctodus
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
            filters.Add(new Filters.VerifySession());
        }
    }
}
