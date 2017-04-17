using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using XCode;
using XCode.Configuration;
using XCode.DataAccessLayer;

namespace Cloud.Domain
{
    /// <summary>日志</summary>
    [Serializable]
    [DataObject]
    [Description("日志")]
    [BindIndex("IX_Log_Action", false, "Action")]
    [BindIndex("IX_Log_Category", false, "Category")]
    [BindIndex("IX_Log_CreateTime", false, "CreateTime")]
    [BindIndex("IX_Log_CreateUserID", false, "CreateUserID")]
    [BindIndex("PK__Log__3214EC2703317E3D", true, "ID")]
    [BindTable("Log", Description = "日志", ConnName = "Cloud", DbType = DatabaseType.SqlServer)]
    public partial class Log : ILog
    {
        #region 属性

        private String _CreateIPName;
        /// <summary>IP名称</summary>
        [DisplayName("IP名称")]
        [Description("IP名称")]
        [DataObjectField(false, false, true, 50)]
        [BindColumn(7, "CreateIPName", "IP名称", null, "nvarchar(50)", 0, 0, true)]
        public virtual String CreateIPName
        {
            get { return _CreateIPName; }
            set { if (OnPropertyChanging(__.CreateIPName, value)) { _CreateIPName = value; OnPropertyChanged(__.CreateIPName); } }
        }

        #endregion

        #region 获取/设置 字段值
        /// <summary>
        /// 获取/设置 字段值。
        /// 一个索引，基类使用反射实现。
        /// 派生实体类可重写该索引，以避免反射带来的性能损耗
        /// </summary>
        /// <param name="name">字段名</param>
        /// <returns></returns>
        public override Object this[String name]
        {
            get
            {
                switch (name)
                {
                    case __.CreateIPName: return _CreateIPName;
                    default: return base[name];
                }
            }
            set
            {
                switch (name)
                {
                    case __.CreateIPName: _CreateIPName = Convert.ToString(value); break;
                    default: base[name] = value; break;
                }
            }
        }
        #endregion

        #region 字段名
        /// <summary>取得日志字段信息的快捷方式</summary>
        public partial class _
        {
            ///<summary>编号</summary>
            public static readonly Field ID = FindByName(__.ID);

            ///<summary>类别</summary>
            public static readonly Field Category = FindByName(__.Category);

            ///<summary>操作</summary>
            public static readonly Field Action = FindByName(__.Action);

            ///<summary>链接</summary>
            public static readonly Field LinkID = FindByName(__.LinkID);

            ///<summary>用户编号</summary>
            public static readonly Field CreateUserID = FindByName(__.CreateUserID);

            ///<summary>IP地址</summary>
            public static readonly Field CreateIP = FindByName(__.CreateIP);

            ///<summary>IP名称</summary>
            public static readonly Field CreateIPName = FindByName(__.CreateIPName);

            ///<summary>时间</summary>
            public static readonly Field CreateTime = FindByName(__.CreateTime);

            ///<summary>详细信息</summary>
            public static readonly Field Remark = FindByName(__.Remark);

            static Field FindByName(String name) { return Meta.Table.FindByName(name); }
        }

        /// <summary>取得日志字段名称的快捷方式</summary>
        partial class __
        {
            ///<summary>编号</summary>
            public const String ID = "ID";

            ///<summary>类别</summary>
            public const String Category = "Category";

            ///<summary>操作</summary>
            public const String Action = "Action";

            ///<summary>链接</summary>
            public const String LinkID = "LinkID";

            ///<summary>用户编号</summary>
            public const String CreateUserID = "CreateUserID";

            ///<summary>IP地址</summary>
            public const String CreateIP = "CreateIP";

            ///<summary>IP名称</summary>
            public const String CreateIPName = "CreateIPName";

            ///<summary>时间</summary>
            public const String CreateTime = "CreateTime";

            ///<summary>详细信息</summary>
            public const String Remark = "Remark";

        }
        #endregion
    }

    /// <summary>日志接口</summary>
    public partial interface ILog
    {
        #region 属性
        /// <summary>编号</summary>
        Int32 ID { get; set; }

        /// <summary>类别</summary>
        String Category { get; set; }

        /// <summary>操作</summary>
        String Action { get; set; }

        /// <summary>链接</summary>
        Int32 LinkID { get; set; }

        /// <summary>用户编号</summary>
        Int32 CreateUserID { get; set; }

        /// <summary>IP地址</summary>
        String CreateIP { get; set; }

        /// <summary>IP名称</summary>
        String CreateIPName { get; set; }

        /// <summary>时间</summary>
        DateTime CreateTime { get; set; }

        /// <summary>详细信息</summary>
        String Remark { get; set; }
        #endregion

        #region 获取/设置 字段值
        /// <summary>获取/设置 字段值。</summary>
        /// <param name="name">字段名</param>
        /// <returns></returns>
        Object this[String name] { get; set; }
        #endregion
    }
}