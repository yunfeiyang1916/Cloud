using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NewLife.Web;
using Cloud.Common;
using Cloud.Domain;
using System.Net;

namespace Cloud.Web
{
    /// <summary>指定对控制器或操作方法的访问只限于满足授权要求的用户</summary>
    public class CloudAuthorizeAttribute : AuthorizeAttribute
    {
        #region 属性

        /// <summary>资源名称。需要增加新菜单而不需要控制器名称时，指定资源名称</summary>
        public String ResourceName { get; set; }

        /// <summary>授权项</summary>
        public PermissionEnum Permission { get; set; }

        #endregion

        #region 构造
        /// <summary>指定对控制器或操作方法的访问只限于满足授权要求的用户</summary>
        public CloudAuthorizeAttribute()
        {

        }
        /// <summary>指定对控制器或操作方法的访问只限于满足授权要求的用户</summary>
        /// <param name="Ignore">是否忽略验证</param>
        public CloudAuthorizeAttribute(PermissionEnum permission)
        {
            Permission = permission;
        }

        #endregion

        #region 方法
        /// <summary>在过程请求授权时调用</summary>
        /// <param name="filterContext"></param>
        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            //基类方法会检查AllowAnonymous
            //base.OnAuthorization(filterContext);
            var act = filterContext.ActionDescriptor;
            // 允许匿名访问时，直接跳过检查
            if (act.IsDefined(typeof(AllowAnonymousAttribute), true) || act.ControllerDescriptor.IsDefined(typeof(AllowAnonymousAttribute), true)) return;
            var user = XCode.Membership.ManageProvider.User as Admin;
            var context = filterContext.HttpContext;
            var request = context.Request;
            var response = context.Response;

            #region 验证登陆
            //判断是否登陆
            if (user == null)
            {
                //往Cookie中写入登陆超时
                WebHelper.WriteCookie(Consts.CookieLoginError, "Timeout");
                //非ajax请求，增加js跳转
                if (!request.IsAjaxRequest()) response.Write("<script>top.location.href = '/Login/Index';</script>");
                //这个方法会将StatusCode设置为401,并设置响应结果为HttpUnauthorizedResult
                //HandleUnauthorizedRequest(filterContext);
                filterContext.Result = new HttpStatusCodeResult(HttpStatusCode.Unauthorized, Utils.StringToISO_8859_1("401 登陆超时"));
                return;
            }
            #endregion

            #region 验证权限
            //是否验证权限
            if (Setting.Current.Permission && Permission != PermissionEnum.None)
            {
                String url = filterContext.HttpContext.Request.AppRelativeCurrentExecutionFilePath.ToLower();
                if (url.IndexOf('~') == 0) url = url.Remove(0, 1); //去掉‘~符号’
                PermissionManager pm = PermissionManager.Current;
                //判断是否授权
                if (pm != null && pm.IsGranted(Permission)) return;
                else
                {
                    //如果是ajax请求，则输出403状态码表示请求拒绝
                    if (request.IsAjaxRequest())
                        filterContext.Result = new HttpStatusCodeResult(HttpStatusCode.Forbidden, url);
                    else
                        filterContext.Result = new RedirectResult(String.Format("/Home/Error?statusCode={0}&statusText={1}", 403, String.Format("无权限访问{0}！", url)));
                }
            }
            #endregion
        }
        #endregion
    }
}