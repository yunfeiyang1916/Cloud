using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using XCode;
using XCode.Configuration;
using XCode.DataAccessLayer;

namespace Cloud.Domain
{
    /// <summary>角色</summary>
    [Serializable]
    [DataObject]
    [Description("角色")]
    [BindIndex("IU_Role_Name", true, "Name")]
    [BindIndex("PK__Role__3214EC2707020F21", true, "ID")]
    [BindRelation("ID", true, "AdminRole", "RoleID")]
    [BindRelation("ID", true, "RoleDataPermission", "RoleID")]
    [BindRelation("ID", true, "RoleMenu", "RoleID")]
    [BindRelation("ID", true, "RoleMenuButton", "RoleID")]
    [BindTable("Role", Description = "角色", ConnName = "Cloud", DbType = DatabaseType.SqlServer)]
    public partial class Role : IRole
    {
        #region 属性
        private Int32 _ID;
        /// <summary>编号</summary>
        [DisplayName("编号")]
        [Description("编号")]
        [DataObjectField(true, true, false, 10)]
        [BindColumn(1, "ID", "编号", null, "int", 10, 0, false)]
        public virtual Int32 ID
        {
            get { return _ID; }
            set { if (OnPropertyChanging(__.ID, value)) { _ID = value; OnPropertyChanged(__.ID); } }
        }

        private String _Name;
        /// <summary>名称</summary>
        [DisplayName("名称")]
        [Description("名称")]
        [DataObjectField(false, false, false, 50)]
        [BindColumn(2, "Name", "名称", null, "nvarchar(50)", 0, 0, true, Master=true)]
        public virtual String Name
        {
            get { return _Name; }
            set { if (OnPropertyChanging(__.Name, value)) { _Name = value; OnPropertyChanged(__.Name); } }
        }

        private Boolean _AllowUpdate;
        /// <summary>是否允许编辑</summary>
        [DisplayName("是否允许编辑")]
        [Description("是否允许编辑")]
        [DataObjectField(false, false, true, 1)]
        [BindColumn(3, "AllowUpdate", "是否允许编辑", null, "bit", 0, 0, false)]
        public virtual Boolean AllowUpdate
        {
            get { return _AllowUpdate; }
            set { if (OnPropertyChanging(__.AllowUpdate, value)) { _AllowUpdate = value; OnPropertyChanged(__.AllowUpdate); } }
        }

        private Boolean _AllowDelete;
        /// <summary>是否允许删除</summary>
        [DisplayName("是否允许删除")]
        [Description("是否允许删除")]
        [DataObjectField(false, false, true, 1)]
        [BindColumn(4, "AllowDelete", "是否允许删除", null, "bit", 0, 0, false)]
        public virtual Boolean AllowDelete
        {
            get { return _AllowDelete; }
            set { if (OnPropertyChanging(__.AllowDelete, value)) { _AllowDelete = value; OnPropertyChanged(__.AllowDelete); } }
        }

        private String _Permission;
        /// <summary>菜单权限json格式存储</summary>
        [DisplayName("菜单权限json格式存储")]
        [Description("菜单权限json格式存储")]
        [DataObjectField(false, false, true, 2147483647)]
        [BindColumn(5, "Permission", "菜单权限json格式存储", null, "text", 0, 0, false)]
        public virtual String Permission
        {
            get { return _Permission; }
            set { if (OnPropertyChanging(__.Permission, value)) { _Permission = value; OnPropertyChanged(__.Permission); } }
        }

        private String _DataPermission;
        /// <summary>数据权限存储</summary>
        [DisplayName("数据权限存储")]
        [Description("数据权限存储")]
        [DataObjectField(false, false, true, 500)]
        [BindColumn(6, "DataPermission", "数据权限存储", null, "nvarchar(500)", 0, 0, true)]
        public virtual String DataPermission
        {
            get { return _DataPermission; }
            set { if (OnPropertyChanging(__.DataPermission, value)) { _DataPermission = value; OnPropertyChanged(__.DataPermission); } }
        }

        private String _Remark;
        /// <summary>备注</summary>
        [DisplayName("备注")]
        [Description("备注")]
        [DataObjectField(false, false, true, 500)]
        [BindColumn(7, "Remark", "备注", null, "nvarchar(500)", 0, 0, true)]
        public virtual String Remark
        {
            get { return _Remark; }
            set { if (OnPropertyChanging(__.Remark, value)) { _Remark = value; OnPropertyChanged(__.Remark); } }
        }

        private Int32 _Sort;
        /// <summary>排序</summary>
        [DisplayName("排序")]
        [Description("排序")]
        [DataObjectField(false, false, true, 10)]
        [BindColumn(8, "Sort", "排序", null, "int", 10, 0, false)]
        public virtual Int32 Sort
        {
            get { return _Sort; }
            set { if (OnPropertyChanging(__.Sort, value)) { _Sort = value; OnPropertyChanged(__.Sort); } }
        }

        private Int32 _CreateUserID;
        /// <summary>创建人ID</summary>
        [DisplayName("创建人ID")]
        [Description("创建人ID")]
        [DataObjectField(false, false, true, 10)]
        [BindColumn(9, "CreateUserID", "创建人ID", null, "int", 10, 0, false)]
        public virtual Int32 CreateUserID
        {
            get { return _CreateUserID; }
            set { if (OnPropertyChanging(__.CreateUserID, value)) { _CreateUserID = value; OnPropertyChanged(__.CreateUserID); } }
        }

        private DateTime _CreateDate;
        /// <summary>创建日期</summary>
        [DisplayName("创建日期")]
        [Description("创建日期")]
        [DataObjectField(false, false, true, 3)]
        [BindColumn(10, "CreateDate", "创建日期", null, "datetime", 3, 0, false)]
        public virtual DateTime CreateDate
        {
            get { return _CreateDate; }
            set { if (OnPropertyChanging(__.CreateDate, value)) { _CreateDate = value; OnPropertyChanged(__.CreateDate); } }
        }

        private Int32 _UpdateUserID;
        /// <summary>修改人ID</summary>
        [DisplayName("修改人ID")]
        [Description("修改人ID")]
        [DataObjectField(false, false, true, 10)]
        [BindColumn(11, "UpdateUserID", "修改人ID", null, "int", 10, 0, false)]
        public virtual Int32 UpdateUserID
        {
            get { return _UpdateUserID; }
            set { if (OnPropertyChanging(__.UpdateUserID, value)) { _UpdateUserID = value; OnPropertyChanged(__.UpdateUserID); } }
        }

        private DateTime _UpdateDate;
        /// <summary>创建日期</summary>
        [DisplayName("创建日期")]
        [Description("创建日期")]
        [DataObjectField(false, false, true, 3)]
        [BindColumn(12, "UpdateDate", "创建日期", null, "datetime", 3, 0, false)]
        public virtual DateTime UpdateDate
        {
            get { return _UpdateDate; }
            set { if (OnPropertyChanging(__.UpdateDate, value)) { _UpdateDate = value; OnPropertyChanged(__.UpdateDate); } }
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
                    case __.Name : return _Name;
                    case __.AllowUpdate : return _AllowUpdate;
                    case __.AllowDelete : return _AllowDelete;
                    case __.Permission : return _Permission;
                    case __.DataPermission : return _DataPermission;
                    case __.Remark : return _Remark;
                    case __.Sort : return _Sort;
                    case __.CreateUserID : return _CreateUserID;
                    case __.CreateDate : return _CreateDate;
                    case __.UpdateUserID : return _UpdateUserID;
                    case __.UpdateDate : return _UpdateDate;
                    default: return base[name];
                }
            }
            set
            {
                switch (name)
                {
                    case __.ID : _ID = Convert.ToInt32(value); break;
                    case __.Name : _Name = Convert.ToString(value); break;
                    case __.AllowUpdate : _AllowUpdate = Convert.ToBoolean(value); break;
                    case __.AllowDelete : _AllowDelete = Convert.ToBoolean(value); break;
                    case __.Permission : _Permission = Convert.ToString(value); break;
                    case __.DataPermission : _DataPermission = Convert.ToString(value); break;
                    case __.Remark : _Remark = Convert.ToString(value); break;
                    case __.Sort : _Sort = Convert.ToInt32(value); break;
                    case __.CreateUserID : _CreateUserID = Convert.ToInt32(value); break;
                    case __.CreateDate : _CreateDate = Convert.ToDateTime(value); break;
                    case __.UpdateUserID : _UpdateUserID = Convert.ToInt32(value); break;
                    case __.UpdateDate : _UpdateDate = Convert.ToDateTime(value); break;
                    default: base[name] = value; break;
                }
            }
        }
        #endregion

        #region 字段名
        /// <summary>取得角色字段信息的快捷方式</summary>
        public partial class _
        {
            ///<summary>编号</summary>
            public static readonly Field ID = FindByName(__.ID);

            ///<summary>名称</summary>
            public static readonly Field Name = FindByName(__.Name);

            ///<summary>是否允许编辑</summary>
            public static readonly Field AllowUpdate = FindByName(__.AllowUpdate);

            ///<summary>是否允许删除</summary>
            public static readonly Field AllowDelete = FindByName(__.AllowDelete);

            ///<summary>菜单权限json格式存储</summary>
            public static readonly Field Permission = FindByName(__.Permission);

            ///<summary>数据权限存储</summary>
            public static readonly Field DataPermission = FindByName(__.DataPermission);

            ///<summary>备注</summary>
            public static readonly Field Remark = FindByName(__.Remark);

            ///<summary>排序</summary>
            public static readonly Field Sort = FindByName(__.Sort);

            ///<summary>创建人ID</summary>
            public static readonly Field CreateUserID = FindByName(__.CreateUserID);

            ///<summary>创建日期</summary>
            public static readonly Field CreateDate = FindByName(__.CreateDate);

            ///<summary>修改人ID</summary>
            public static readonly Field UpdateUserID = FindByName(__.UpdateUserID);

            ///<summary>创建日期</summary>
            public static readonly Field UpdateDate = FindByName(__.UpdateDate);

            static Field FindByName(String name) { return Meta.Table.FindByName(name); }
        }

        /// <summary>取得角色字段名称的快捷方式</summary>
        partial class __
        {
            ///<summary>编号</summary>
            public const String ID = "ID";

            ///<summary>名称</summary>
            public const String Name = "Name";

            ///<summary>是否允许编辑</summary>
            public const String AllowUpdate = "AllowUpdate";

            ///<summary>是否允许删除</summary>
            public const String AllowDelete = "AllowDelete";

            ///<summary>菜单权限json格式存储</summary>
            public const String Permission = "Permission";

            ///<summary>数据权限存储</summary>
            public const String DataPermission = "DataPermission";

            ///<summary>备注</summary>
            public const String Remark = "Remark";

            ///<summary>排序</summary>
            public const String Sort = "Sort";

            ///<summary>创建人ID</summary>
            public const String CreateUserID = "CreateUserID";

            ///<summary>创建日期</summary>
            public const String CreateDate = "CreateDate";

            ///<summary>修改人ID</summary>
            public const String UpdateUserID = "UpdateUserID";

            ///<summary>创建日期</summary>
            public const String UpdateDate = "UpdateDate";

        }
        #endregion
    }

    /// <summary>角色接口</summary>
    public partial interface IRole
    {
        #region 属性
        /// <summary>编号</summary>
        Int32 ID { get; set; }

        /// <summary>名称</summary>
        String Name { get; set; }

        /// <summary>是否允许编辑</summary>
        Boolean AllowUpdate { get; set; }

        /// <summary>是否允许删除</summary>
        Boolean AllowDelete { get; set; }

        /// <summary>菜单权限json格式存储</summary>
        String Permission { get; set; }

        /// <summary>数据权限存储</summary>
        String DataPermission { get; set; }

        /// <summary>备注</summary>
        String Remark { get; set; }

        /// <summary>排序</summary>
        Int32 Sort { get; set; }

        /// <summary>创建人ID</summary>
        Int32 CreateUserID { get; set; }

        /// <summary>创建日期</summary>
        DateTime CreateDate { get; set; }

        /// <summary>修改人ID</summary>
        Int32 UpdateUserID { get; set; }

        /// <summary>创建日期</summary>
        DateTime UpdateDate { get; set; }
        #endregion

        #region 获取/设置 字段值
        /// <summary>获取/设置 字段值。</summary>
        /// <param name="name">字段名</param>
        /// <returns></returns>
        Object this[String name] { get; set; }
        #endregion
    }
}