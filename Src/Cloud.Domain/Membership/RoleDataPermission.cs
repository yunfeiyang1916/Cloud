using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using XCode;
using XCode.Configuration;
using XCode.DataAccessLayer;

namespace Cloud.Domain
{
    /// <summary>角色与数据权限映射表</summary>
    [Serializable]
    [DataObject]
    [Description("角色与数据权限映射表")]
    [BindIndex("PK__RoleData__3214EC2725869641", true, "ID")]
    [BindIndex("IX_RoleDataPermission_DataPermissionID", false, "DataPermissionID")]
    [BindIndex("IX_RoleDataPermission_RoleID", false, "RoleID")]
    [BindRelation("DataPermissionID", false, "DataPermission", "ID")]
    [BindRelation("RoleID", false, "Role", "ID")]
    [BindTable("RoleDataPermission", Description = "角色与数据权限映射表", ConnName = "Cloud", DbType = DatabaseType.SqlServer)]
    public partial class RoleDataPermission : IRoleDataPermission
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

        private Int32 _DataPermissionID;
        /// <summary>数据权限</summary>
        [DisplayName("数据权限")]
        [Description("数据权限")]
        [DataObjectField(false, false, true, 10)]
        [BindColumn(3, "DataPermissionID", "数据权限", null, "int", 10, 0, false)]
        public virtual Int32 DataPermissionID
        {
            get { return _DataPermissionID; }
            set { if (OnPropertyChanging(__.DataPermissionID, value)) { _DataPermissionID = value; OnPropertyChanged(__.DataPermissionID); } }
        }

        private Boolean _IsDefault;
        /// <summary>是否默认</summary>
        [DisplayName("是否默认")]
        [Description("是否默认")]
        [DataObjectField(false, false, true, 1)]
        [BindColumn(4, "IsDefault", "是否默认", null, "bit", 0, 0, false)]
        public virtual Boolean IsDefault
        {
            get { return _IsDefault; }
            set { if (OnPropertyChanging(__.IsDefault, value)) { _IsDefault = value; OnPropertyChanged(__.IsDefault); } }
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
                    case __.DataPermissionID : return _DataPermissionID;
                    case __.IsDefault : return _IsDefault;
                    default: return base[name];
                }
            }
            set
            {
                switch (name)
                {
                    case __.ID : _ID = Convert.ToInt32(value); break;
                    case __.RoleID : _RoleID = Convert.ToInt32(value); break;
                    case __.DataPermissionID : _DataPermissionID = Convert.ToInt32(value); break;
                    case __.IsDefault : _IsDefault = Convert.ToBoolean(value); break;
                    default: base[name] = value; break;
                }
            }
        }
        #endregion

        #region 字段名
        /// <summary>取得角色与数据权限映射表字段信息的快捷方式</summary>
        public partial class _
        {
            ///<summary>主键ID</summary>
            public static readonly Field ID = FindByName(__.ID);

            ///<summary>角色</summary>
            public static readonly Field RoleID = FindByName(__.RoleID);

            ///<summary>数据权限</summary>
            public static readonly Field DataPermissionID = FindByName(__.DataPermissionID);

            ///<summary>是否默认</summary>
            public static readonly Field IsDefault = FindByName(__.IsDefault);

            static Field FindByName(String name) { return Meta.Table.FindByName(name); }
        }

        /// <summary>取得角色与数据权限映射表字段名称的快捷方式</summary>
        partial class __
        {
            ///<summary>主键ID</summary>
            public const String ID = "ID";

            ///<summary>角色</summary>
            public const String RoleID = "RoleID";

            ///<summary>数据权限</summary>
            public const String DataPermissionID = "DataPermissionID";

            ///<summary>是否默认</summary>
            public const String IsDefault = "IsDefault";

        }
        #endregion
    }

    /// <summary>角色与数据权限映射表接口</summary>
    public partial interface IRoleDataPermission
    {
        #region 属性
        /// <summary>主键ID</summary>
        Int32 ID { get; set; }

        /// <summary>角色</summary>
        Int32 RoleID { get; set; }

        /// <summary>数据权限</summary>
        Int32 DataPermissionID { get; set; }

        /// <summary>是否默认</summary>
        Boolean IsDefault { get; set; }
        #endregion

        #region 获取/设置 字段值
        /// <summary>获取/设置 字段值。</summary>
        /// <param name="name">字段名</param>
        /// <returns></returns>
        Object this[String name] { get; set; }
        #endregion
    }
}