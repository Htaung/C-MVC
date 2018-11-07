using System.Web;
using System.Web.Mvc;
using TestMVC.Filters;

namespace TestMVC
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            //filters.Add(new HandleErrorAttribute());//Old line Exception Filter
            filters.Add(new EmployeeExceptionFilter());
            filters.Add(new AuthorizeAttribute());//New Line
        }
    }
}
