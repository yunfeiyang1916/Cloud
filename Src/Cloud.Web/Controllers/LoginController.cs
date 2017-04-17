using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Cloud.Common;
using Cloud.Domain;
using XCode.Membership;
using Cloud.Web;
using System.Web.Security;

namespace Cloud.Web.Controllers
{
    /// <summary>登陆控制器</summary>
    public class LoginController : Controller
    {
        /// <summary>首页</summary>
        [HttpGet]
        public ActionResult Index()
        {
            //已登陆
            if (ManageProvider.User != null)
            {
                return Redirect("/Home/Index");
            }
            else
            {
                return View();
            }
        }

        /// <summary>获取验证码</summary>
        [HttpGet]
        public ActionResult GetAuthCode()
        {
            String chkCode;
            Byte[] fileContents = VerifyCode.GetVerifyCode(out chkCode);
            Session[Consts.SessionVerifyCode] = chkCode;
            return File(fileContents, "image/gif");
        }
        /// <summary>登陆</summary>
        /// <param name="userName">用户名</param>
        /// <param name="password">密码</param>
        /// <param name="code">验证码</param>
        /// <param name="rememberme">是否记住密码</param>
        /// <returns></returns>
        public ActionResult Login(String userName, String password, String code, Boolean? rememberme)
        {
            String chkCode = Session[Consts.SessionVerifyCode] + "";
            //验证码用过之后需要销毁，否则会有安全漏洞
            Session.Remove(Consts.SessionVerifyCode);
            if (chkCode.ToLower() != code.ToLower())
            {
                throw new ArgumentException("验证码错误，请重新输入！");
            }
            var provider = ManageProvider.Provider;
            var admin = provider.Login(userName, password, rememberme ?? false);
            if (admin != null)
            {
                FormsAuthentication.SetAuthCookie(userName, rememberme ?? false);
                return Json(new AjaxResult { Status = 1, Msg = "登陆成功！" });
            }
            return Json(new AjaxResult { Status = 0, Msg = "登陆失败！" });
        }
        /// <summary>登出</summary>
        public ActionResult Logout()
        {
            var provider = ManageProvider.Provider;
            provider.Logout();
            Session.Abandon();
            Session.Clear();
            return Redirect("/Login/Index");
        }

    }
}