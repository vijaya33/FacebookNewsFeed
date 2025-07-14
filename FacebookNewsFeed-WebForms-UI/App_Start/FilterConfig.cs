using System.Web;
using System.Web.Mvc;

namespace FacebookNewsFeed_WebForms_UI
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
