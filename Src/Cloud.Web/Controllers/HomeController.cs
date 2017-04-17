using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Cloud.Domain;
using XCode.Membership;
using Cloud.Common;
using Cloud.Domain.Dto;

namespace Cloud.Web.Controllers
{
    /// <summary>主页控制器</summary>
    [CloudAuthorize]
    public class HomeController : Controller
    {
        /// <summary>首页</summary>
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>欢迎页</summary>
        public ActionResult Welcome()
        {
            return View();
        }

        /// <summary>关于</summary>
        public ActionResult About()
        {
            return View();
        }
        /// <summary>错误页</summary>
        /// <param name="statusCode">Http状态码</param>
        /// <param name="statusText">状态说明</param>
        /// <returns></returns>
        public ActionResult Error(Int32? statusCode, String statusText)
        {
            ViewBag.StatusCode = statusCode.HasValue ? statusCode : 0;
            ViewBag.StatusText = statusText;

            return View();
        }
        /// <summary>测试页面</summary>
        [AllowAnonymous]
        public ActionResult Test(String str)
        {
            str = str.MD5();

            return Content(str);
        }

        /// <summary>获取客户端所需的数据</summary>
        public ActionResult GetClientData()
        {
            AjaxResult result = new AjaxResult();
            Admin user = ManageProvider.User as Admin;
            if (user != null)
            {
                ClientDataDto dto = new ClientDataDto();
                dto.PermissionManager = PermissionManager.Current;
                //因为会修改,为了不影响缓存中的实体，这里使用克隆
                dto.Admin = user.CloneEntity();
                //安全信息置空
                dto.Admin.Password = dto.Admin.RawPassword = dto.Admin.Salt = null;
                result.Data = dto;
                result.Msg = "获取成功。";
                result.Status = 1;
            }
            else
            {
                result.Status = 0;
                result.Msg = "获取客户端数据失败";
            }
            return Json(result, JsonRequestBehavior.AllowGet); ;
        }
    }
}