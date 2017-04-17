using System;
using System.ComponentModel;
using NewLife.Configuration;
using NewLife.Log;
using NewLife.Xml;

namespace Cloud.Web
{
    /// <summary>Web设置</summary>
    [DisplayName("Web设置")]
    [XmlConfigFile(@"Config\Web.config", 15000)]
    public class Setting : XmlConfig<Setting>
    {
        #region 属性
        /// <summary>是否启用调试。默认为不启用</summary>
        [Description("调试")]
        public Boolean Debug { get; set; }

        /// <summary>显示运行时间</summary>
        [Description("显示运行时间")]
        public Boolean ShowRunTime { get; set; } = true;

        /// <summary>扩展插件服务器。将从该网页上根据关键字分析链接并下载插件</summary>
        [Description("扩展插件服务器。将从该网页上根据关键字分析链接并下载插件")]
        public String PluginServer { get; set; } = "http://x.newlifex.com/";

        /// <summary>是否开启权限校验，默认是</summary>
        [Description("是否开启权限校验")]
        public Boolean Permission { get; set; } = true;
        #endregion

        #region 方法
        /// <summary>实例化</summary>
        public Setting()
        {
        }

        /// <summary>新建时调用</summary>
        protected override void OnNew()
        {
        }
        #endregion
    }
}