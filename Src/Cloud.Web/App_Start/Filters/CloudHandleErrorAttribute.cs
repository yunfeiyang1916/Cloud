using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using NewLife.Log;

namespace Cloud.Web
{
    /// <summary>用于拦截由操作方法引发的异常</summary>
    public class CloudHandleErrorAttribute : HandleErrorAttribute
    {
        /// <summary>在发生异常时调用</summary>
        /// <param name="filterContext">异常上下文</param>>
        public override void OnException(ExceptionContext filterContext)
        {
            XTrace.WriteException(filterContext.Exception);
            //判断是不是ajax请求
            if (filterContext.HttpContext.Request.IsAjaxRequest())
            {

                filterContext.ExceptionHandled = true;
                filterContext.HttpContext.Response.StatusCode = 200;
                filterContext.Result = new JsonResult { Data = new AjaxResult { Status = 0, Msg = filterContext.Exception.Message } };
            }
            base.OnException(filterContext);
        }
    }
}
