using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Xml.Serialization;
using NewLife.Log;
using NewLife.Web;
using NewLife.Data;
using XCode;
using XCode.Configuration;
using XCode.Membership;

namespace Cloud.Domain
{
    /// <summary>日志</summary>
    public partial class Log : XCode.Membership.Log<Log>
    {
        #region 扩展属性
        /// <summary>创建人名称</summary>
        public new  String CreateUserName { get { return base.CreateUserName; } }

        #endregion
    }
}