using System.Web;
using System.Web.Mvc;

namespace Alit.Marker.Service.Update
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
