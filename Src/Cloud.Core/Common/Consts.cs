using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cloud.Common
{
    /// <summary>一些常量值</summary>
    public class Consts
    {
        #region Session中的键

        /// <summary>session中验证码的键</summary>
        public const String SessionVerifyCode = "SessionVerifyCode";

        /// <summary>session中登陆用户的键</summary>
        public const String SessionAdmin = "SessionAdmin";

        /// <summary>session中权限管理器的键</summary>
        public const String SessionPermissionManager = "SessionPermissionManager";

        #endregion

        #region Cookie中的键

        /// <summary>Cookie中登陆错误的键</summary>
        public const String CookieLoginError = "CookieLoginError";

        /// <summary>Cookie中管理员的键</summary>
        public const String CookieAdmin = "CookieAdmin";

        #endregion

    }
}
