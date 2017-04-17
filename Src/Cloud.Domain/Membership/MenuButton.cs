using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using XCode;
using XCode.Configuration;
using XCode.DataAccessLayer;

namespace Cloud.Domain
{
    /// <summary>菜单与按钮映射表</summary>
    [Serializable]
    [DataObject]
    [Description("菜单与按钮映射表")]
    [BindIndex("PK_MenuButton", true, "ID")]
    [BindIndex("IX_MenuButton_ButtonID", false, "ButtonID")]
    [BindIndex("IX_MenuButton_MenuID", false, "MenuID")]
    [BindRelation("ButtonID", false, "Button", "ID")]
    [BindRelation("MenuID", false, "Menu", "ID")]
    [BindRelation("ID", true, "RoleMenuButton", "MenuButtonID")]
    [BindTable("MenuButton", Description = "菜单与按钮映射表", ConnName = "Cloud", DbType = DatabaseType.SqlServer)]
    public partial class MenuButton : IMenuButton
    {
        #region 属性
        private Int32 _ID;
        /// <summary>主键ID</summary>
        [DisplayName("主键ID")]
        [Description("主键ID")]
        [DataObjectField(true, true, false, 10)]
        [BindColumn(1, "ID", "主键ID", null, "int", 10, 0, false)]
        public virtual Int32 ID
        {
            get { return _ID; }
            set { if (OnPropertyChanging(__.ID, value)) { _ID = value; OnPropertyChanged(__.ID); } }
        }

        private Int32 _MenuID;
        /// <summary>菜单</summary>
        [DisplayName("菜单")]
        [Description("菜单")]
        [DataObjectField(false, false, true, 10)]
        [BindColumn(2, "MenuID", "菜单", null, "int", 10, 0, false)]
        public virtual Int32 MenuID
        {
            get { return _MenuID; }
            set { if (OnPropertyChanging(__.MenuID, value)) { _MenuID = value; OnPropertyChanged(__.MenuID); } }
        }

        private Int32 _ButtonID;
        /// <summary>按钮</summary>
        [DisplayName("按钮")]
        [Description("按钮")]
        [DataObjectField(false, false, true, 10)]
        [BindColumn(3, "ButtonID", "按钮", null, "int", 10, 0, false)]
        public virtual Int32 ButtonID
        {
            get { return _ButtonID; }
            set { if (OnPropertyChanging(__.ButtonID, value)) { _ButtonID = value; OnPropertyChanged(__.ButtonID); } }
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
                    case __.ID : return _ID;
                    case __.MenuID : return _MenuID;
                    case __.ButtonID : return _ButtonID;
                    default: return base[name];
                }
            }
            set
            {
                switch (name)
                {
                    case __.ID : _ID = Convert.ToInt32(value); break;
                    case __.MenuID : _MenuID = Convert.ToInt32(value); break;
                    case __.ButtonID : _ButtonID = Convert.ToInt32(value); break;
                    default: base[name] = value; break;
                }
            }
        }
        #endregion

        #region 字段名
        /// <summary>取得菜单与按钮映射表字段信息的快捷方式</summary>
        public partial class _
        {
            ///<summary>主键ID</summary>
            public static readonly Field ID = FindByName(__.ID);

            ///<summary>菜单</summary>
            public static readonly Field MenuID = FindByName(__.MenuID);

            ///<summary>按钮</summary>
            public static readonly Field ButtonID = FindByName(__.ButtonID);

            static Field FindByName(String name) { return Meta.Table.FindByName(name); }
        }

        /// <summary>取得菜单与按钮映射表字段名称的快捷方式</summary>
        partial class __
        {
            ///<summary>主键ID</summary>
            public const String ID = "ID";

            ///<summary>菜单</summary>
            public const String MenuID = "MenuID";

            ///<summary>按钮</summary>
            public const String ButtonID = "ButtonID";

        }
        #endregion
    }

    /// <summary>菜单与按钮映射表接口</summary>
    public partial interface IMenuButton
    {
        #region 属性
        /// <summary>主键ID</summary>
        Int32 ID { get; set; }

        /// <summary>菜单</summary>
        Int32 MenuID { get; set; }

        /// <summary>按钮</summary>
        Int32 ButtonID { get; set; }
        #endregion

        #region 获取/设置 字段值
        /// <summary>获取/设置 字段值。</summary>
        /// <param name="name">字段名</param>
        /// <returns></returns>
        Object this[String name] { get; set; }
        #endregion
    }
}