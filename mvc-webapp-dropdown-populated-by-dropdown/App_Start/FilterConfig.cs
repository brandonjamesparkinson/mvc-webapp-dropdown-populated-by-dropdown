using System.Web;
using System.Web.Mvc;

namespace mvc_webapp_dropdown_populated_by_dropdown
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
