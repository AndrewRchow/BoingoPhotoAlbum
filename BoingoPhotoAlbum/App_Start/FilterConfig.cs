using System.Web;
using System.Web.Mvc;

namespace BoingoPhotoAlbum
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
