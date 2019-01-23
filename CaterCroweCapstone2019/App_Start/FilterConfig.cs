using System.Diagnostics.CodeAnalysis;
using System.Web;
using System.Web.Mvc;

namespace CaterCroweCapstone2019
{
    [ExcludeFromCodeCoverage]
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
