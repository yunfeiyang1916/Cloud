using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using XCode;
using XCode.Configuration;
using XCode.DataAccessLayer;

namespace Cloud.Domain
{
    /// <summary>角色与菜单映射表</summary>
    [Serializable]
    [DataObject]
    [Description("角色与菜单映射表")]
    [BindIndex("IX_RoleMenu_MenuID", false, "MenuID")]
    [BindIndex("IX_RoleMenu_RoleID", false, "RoleID")]
    [BindIndex("PK_RoleMenu", true, "ID")]
    [BindRelation("MenuID", false, "Menu", "ID")]
    [BindRelation("RoleID", false, "Role", "ID")]
    [BindTable("RoleMenu", Description = "角色与菜单映射表", ConnName = "Cloud", DbType = DatabaseType.SqlServer)]
    public partial class RoleMenu : IRoleMenu
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

        private Int32 _RoleID;
        /// <summary>角色</summary>
        [DisplayName("角色")]
        [Description("角色")]
        [DataObjectField(false, false, true, 10)]
        [BindColumn(2, "RoleID", "角色", null, "int", 10, 0, false)]
        public virtual Int32 RoleID
        {
            get { return _RoleID; }
            set { if (OnPropertyChanging(__.RoleID, value)) { _RoleID = value; OnPropertyChanged(__.RoleID); } }
        }

        private Int32 _MenuID;
        /// <summary>菜单</summary>
        [DisplayName("菜单")]
        [Description("菜单")]
        [DataObjectField(false, false, true, 10)]
        [BindColumn(3, "MenuID", "菜单", null, "int", 10, 0, false)]
        public virtual Int32 MenuID
        {
            get { return _MenuID; }
            set { if (OnPropertyChanging(__.MenuID, value)) { _MenuID = value; OnPropertyChanged(__.MenuID); } }
        }

        private String _FieldNames;
        /// <summary>字段名称集合，以逗号分隔</summary>
        [DisplayName("字段名称集合，以逗号分隔")]
        [Description("字段名称集合，以逗号分隔")]
        [DataObjectField(false, false, true, 200)]
        [BindColumn(4, "FieldNames", "字段名称集合，以逗号分隔", null, "nvarchar(200)", 0, 0, true)]
        public virtual String FieldNames
        {
            get { return _FieldNames; }
            set { if (OnPropertyChanging(__.FieldNames, value)) { _FieldNames = value; OnPropertyChanged(__.FieldNames); } }
        }

        private Boolean _IsAllow;
        /// <summary>字段权限类型：1 允许 0 拒绝</summary>
        [DisplayName("字段权限类型：1允许0拒绝")]
        [Description("字段权限类型：1 允许 0 拒绝")]
        [DataObjectField(false, false, true, 1)]
        [BindColumn(5, "IsAllow", "字段权限类型：1 允许 0 拒绝", null, "bit", 0, 0, false)]
        public virtual Boolean IsAllow
        {
            get { return _IsAllow; }
            set { if (OnPropertyChanging(__.IsAllow, value)) { _IsAllow = value; OnPropertyChanged(__.IsAllow); } }
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
                    case __.RoleID : return _RoleID;
                    case __.MenuID : return _MenuID;
                    case __.FieldNames : return _FieldNames;
                    case __.IsAllow : return _IsAllow;
                    default: return base[name];
                }
            }
            set
            {
                switch (name)
                {
                    case __.ID : _ID = Convert.ToInt32(value); break;
                    case __.RoleID : _RoleID = Convert.ToInt32(value); break;
                    case __.MenuID : _MenuID = Convert.ToInt32(value); break;
                    case __.FieldNames : _FieldNames = Convert.ToString(value); break;
                    case __.IsAllow : _IsAllow = Convert.ToBoolean(value); break;
                    default: base[name] = value; break;
                }
            }
        }
        #endregion

        #region 字段名
        /// <summary>取得角色与菜单映射表字段信息的快捷方式</summary>
        public partial class _
        {
            ///<summary>主键ID</summary>
            public static readonly Field ID = FindByName(__.ID);

            ///<summary>角色</summary>
            public static readonly Field RoleID = FindByName(__.RoleID);

            ///<summary>菜单</summary>
            public static readonly Field MenuID = FindByName(__.MenuID);

            ///<summary>字段名称集合，以逗号分隔</summary>
            public static readonly Field FieldNames = FindByName(__.FieldNames);

            ///<summary>字段权限类型：1 允许 0 拒绝</summary>
            public static readonly Field IsAllow = FindByName(__.IsAllow);

            static Field FindByName(String name) { return Meta.Table.FindByName(name); }
        }

        /// <summary>取得角色与菜单映射表字段名称的快捷方式</summary>
        partial class __
        {
            ///<summary>主键ID</summary>
            public const String ID = "ID";

            ///<summary>角色</summary>
            public const String RoleID = "RoleID";

            ///<summary>菜单</summary>
            public const String MenuID = "MenuID";

            ///<summary>字段名称集合，以逗号分隔</summary>
            public const String FieldNames = "FieldNames";

            ///<summary>字段权限类型：1 允许 0 拒绝</summary>
            public const String IsAllow = "IsAllow";

        }
        #endregion
    }

    /// <summary>角色与菜单映射表接口</summary>
    public partial interface IRoleMenu
    {
        #region 属性
        /// <summary>主键ID</summary>
        Int32 ID { get; set; }

        /// <summary>角色</summary>
        Int32 RoleID { get; set; }

        /// <summary>菜单</summary>
        Int32 MenuID { get; set; }

        /// <summary>字段名称集合，以逗号分隔</summary>
        String FieldNames { get; set; }

        /// <summary>字段权限类型：1 允许 0 拒绝</summary>
        Boolean IsAllow { get; set; }
        #endregion

        #region 获取/设置 字段值
        /// <summary>获取/设置 字段值。</summary>
        /// <param name="name">字段名</param>
        /// <returns></returns>
        Object this[String name] { get; set; }
        #endregion
    }
}