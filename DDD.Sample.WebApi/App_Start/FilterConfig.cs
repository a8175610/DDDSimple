using System.Web;
using System.Web.Mvc;
using DDD.Sample.WebApi.Common.Attribute;

namespace DDD.Sample.WebApi
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            //filters.Add(new HandleErrorAttribute());
            //定义自定义的异常处理
            filters.Add(new CustomerErrorAttrubute());
        }
    }
}
