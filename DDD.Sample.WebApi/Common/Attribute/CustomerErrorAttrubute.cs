using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DDD.Sample.Infrastructure.Helper;

namespace DDD.Sample.WebApi.Common.Attribute
{
    [System.AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = false)]
    sealed class CustomerErrorAttrubute : FilterAttribute, IExceptionFilter
    {
        public void OnException(ExceptionContext filterContext)
        {
            if (!filterContext.ExceptionHandled)
            {
                //记录异常日志
                LogHelper.WriteLog("", filterContext.Exception);
                filterContext.ExceptionHandled = true;
                var result = new ViewResult
                {
                    ViewName = "Error"
                };
                //显示错误页面
                filterContext.Result = result;
            }
        }
    }
}