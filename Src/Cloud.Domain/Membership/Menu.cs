using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using XCode;
using XCode.Configuration;
using XCode.DataAccessLayer;

namespace Cloud.Domain
{
    /// <summary>菜单</summary>
    [Serializable]
    [DataObject]
    [Description("菜单")]
    [BindIndex("IU_Menu_ParentID_Name", true, "ParentID,Name")]
    [BindIndex("IX_Menu_Name", false, "Name")]
    [BindIndex("PK__Menu__3214EC277F60ED59", true, "ID")]
    [BindRelation("ID", true, "MenuButton", "MenuID")]
    [BindRelation("ID", true, "RoleMenu", "MenuID")]
    [BindRelation("ID", true, "RoleMenuButton", "MenuID")]
    [BindTable("Menu", Description = "菜单", ConnName = "Cloud", DbType = DatabaseType.SqlServer)]
    public partial class Menu : IMenu
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

        private String _DisplayName;
        /// <summary>显示名</summary>
        [DisplayName("显示名")]
        [Description("显示名")]
        [DataObjectField(false, false, true, 50)]
        [BindColumn(3, "DisplayName", "显示名", null, "nvarchar(50)", 0, 0, true)]
        public virtual String DisplayName
        {
            get { return _DisplayName; }
            set { if (OnPropertyChanging(__.DisplayName, value)) { _DisplayName = value; OnPropertyChanged(__.DisplayName); } }
        }

        private Int32 _ParentID;
        /// <summary>父编号</summary>
        [DisplayName("父编号")]
        [Description("父编号")]
        [DataObjectField(false, false, true, 10)]
        [BindColumn(4, "ParentID", "父编号", null, "int", 10, 0, false)]
        public virtual Int32 ParentID
        {
            get { return _ParentID; }
            set { if (OnPropertyChanging(__.ParentID, value)) { _ParentID = value; OnPropertyChanged(__.ParentID); } }
        }

        private String _Url;
        /// <summary>链接</summary>
        [DisplayName("链接")]
        [Description("链接")]
        [DataObjectField(false, false, true, 200)]
        [BindColumn(5, "Url", "链接", null, "nvarchar(200)", 0, 0, true)]
        public virtual String Url
        {
            get { return _Url; }
            set { if (OnPropertyChanging(__.Url, value)) { _Url = value; OnPropertyChanged(__.Url); } }
        }

        private String _Target;
        /// <summary>目标，取值：expand、iframe、open、blank</summary>
        [DisplayName("目标，取值：expand、iframe、open、blank")]
        [Description("目标，取值：expand、iframe、open、blank")]
        [DataObjectField(false, false, true, 50)]
        [BindColumn(6, "Target", "目标，取值：expand、iframe、open、blank", null, "nvarchar(50)", 0, 0, true)]
        public virtual String Target
        {
            get { return _Target; }
            set { if (OnPropertyChanging(__.Target, value)) { _Target = value; OnPropertyChanged(__.Target); } }
        }

        private String _Icon;
        /// <summary>图标样式</summary>
        [DisplayName("图标样式")]
        [Description("图标样式")]
        [DataObjectField(false, false, true, 50)]
        [BindColumn(7, "Icon", "图标样式", null, "nvarchar(50)", 0, 0, true)]
        public virtual String Icon
        {
            get { return _Icon; }
            set { if (OnPropertyChanging(__.Icon, value)) { _Icon = value; OnPropertyChanged(__.Icon); } }
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

        private Boolean _Visible;
        /// <summary>是否可见</summary>
        [DisplayName("是否可见")]
        [Description("是否可见")]
        [DataObjectField(false, false, true, 1)]
        [BindColumn(9, "Visible", "是否可见", null, "bit", 0, 0, false)]
        public virtual Boolean Visible
        {
            get { return _Visible; }
            set { if (OnPropertyChanging(__.Visible, value)) { _Visible = value; OnPropertyChanged(__.Visible); } }
        }

        private Boolean _Necessary;
        /// <summary>必要的菜单。必须至少有角色拥有这些权限，如果没有则自动授权给系统角色</summary>
        [DisplayName("必要的菜单")]
        [Description("必要的菜单。必须至少有角色拥有这些权限，如果没有则自动授权给系统角色")]
        [DataObjectField(false, false, true, 1)]
        [BindColumn(10, "Necessary", "必要的菜单。必须至少有角色拥有这些权限，如果没有则自动授权给系统角色", null, "bit", 0, 0, false)]
        public virtual Boolean Necessary
        {
            get { return _Necessary; }
            set { if (OnPropertyChanging(__.Necessary, value)) { _Necessary = value; OnPropertyChanged(__.Necessary); } }
        }

        private String _Remark;
        /// <summary></summary>
        [DisplayName("Remark")]
        [Description("")]
        [DataObjectField(false, false, true, 500)]
        [BindColumn(11, "Remark", "", null, "nvarchar(500)", 0, 0, true)]
        public virtual String Remark
        {
            get { return _Remark; }
            set { if (OnPropertyChanging(__.Remark, value)) { _Remark = value; OnPropertyChanged(__.Remark); } }
        }

        private Int32 _CreateUserID;
        /// <summary>创建人id</summary>
        [DisplayName("创建人id")]
        [Description("创建人id")]
        [DataObjectField(false, false, true, 10)]
        [BindColumn(12, "CreateUserID", "创建人id", null, "int", 10, 0, false)]
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
        [BindColumn(13, "CreateDate", "创建日期", null, "datetime", 3, 0, false)]
        public virtual DateTime CreateDate
        {
            get { return _CreateDate; }
            set { if (OnPropertyChanging(__.CreateDate, value)) { _CreateDate = value; OnPropertyChanged(__.CreateDate); } }
        }

        private Int32 _UpdateUserID;
        /// <summary>修改人id</summary>
        [DisplayName("修改人id")]
        [Description("修改人id")]
        [DataObjectField(false, false, true, 10)]
        [BindColumn(14, "UpdateUserID", "修改人id", null, "int", 10, 0, false)]
        public virtual Int32 UpdateUserID
        {
            get { return _UpdateUserID; }
            set { if (OnPropertyChanging(__.UpdateUserID, value)) { _UpdateUserID = value; OnPropertyChanged(__.UpdateUserID); } }
        }

        private DateTime _UpdateDate;
        /// <summary>修改日期</summary>
        [DisplayName("修改日期")]
        [Description("修改日期")]
        [DataObjectField(false, false, true, 3)]
        [BindColumn(15, "UpdateDate", "修改日期", null, "datetime", 3, 0, false)]
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
                    case __.DisplayName : return _DisplayName;
                    case __.ParentID : return _ParentID;
                    case __.Url : return _Url;
                    case __.Target : return _Target;
                    case __.Icon : return _Icon;
                    case __.Sort : return _Sort;
                    case __.Visible : return _Visible;
                    case __.Necessary : return _Necessary;
                    case __.Remark : return _Remark;
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
                    case __.DisplayName : _DisplayName = Convert.ToString(value); break;
                    case __.ParentID : _ParentID = Convert.ToInt32(value); break;
                    case __.Url : _Url = Convert.ToString(value); break;
                    case __.Target : _Target = Convert.ToString(value); break;
                    case __.Icon : _Icon = Convert.ToString(value); break;
                    case __.Sort : _Sort = Convert.ToInt32(value); break;
                    case __.Visible : _Visible = Convert.ToBoolean(value); break;
                    case __.Necessary : _Necessary = Convert.ToBoolean(value); break;
                    case __.Remark : _Remark = Convert.ToString(value); break;
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
        /// <summary>取得菜单字段信息的快捷方式</summary>
        public partial class _
        {
            ///<summary>编号</summary>
            public static readonly Field ID = FindByName(__.ID);

            ///<summary>名称</summary>
            public static readonly Field Name = FindByName(__.Name);

            ///<summary>显示名</summary>
            public static readonly Field DisplayName = FindByName(__.DisplayName);

            ///<summary>父编号</summary>
            public static readonly Field ParentID = FindByName(__.ParentID);

            ///<summary>链接</summary>
            public static readonly Field Url = FindByName(__.Url);

            ///<summary>目标，取值：expand、iframe、open、blank</summary>
            public static readonly Field Target = FindByName(__.Target);

            ///<summary>图标样式</summary>
            public static readonly Field Icon = FindByName(__.Icon);

            ///<summary>排序</summary>
            public static readonly Field Sort = FindByName(__.Sort);

            ///<summary>是否可见</summary>
            public static readonly Field Visible = FindByName(__.Visible);

            ///<summary>必要的菜单。必须至少有角色拥有这些权限，如果没有则自动授权给系统角色</summary>
            public static readonly Field Necessary = FindByName(__.Necessary);

            ///<summary></summary>
            public static readonly Field Remark = FindByName(__.Remark);

            ///<summary>创建人id</summary>
            public static readonly Field CreateUserID = FindByName(__.CreateUserID);

            ///<summary>创建日期</summary>
            public static readonly Field CreateDate = FindByName(__.CreateDate);

            ///<summary>修改人id</summary>
            public static readonly Field UpdateUserID = FindByName(__.UpdateUserID);

            ///<summary>修改日期</summary>
            public static readonly Field UpdateDate = FindByName(__.UpdateDate);

            static Field FindByName(String name) { return Meta.Table.FindByName(name); }
        }

        /// <summary>取得菜单字段名称的快捷方式</summary>
        partial class __
        {
            ///<summary>编号</summary>
            public const String ID = "ID";

            ///<summary>名称</summary>
            public const String Name = "Name";

            ///<summary>显示名</summary>
            public const String DisplayName = "DisplayName";

            ///<summary>父编号</summary>
            public const String ParentID = "ParentID";

            ///<summary>链接</summary>
            public const String Url = "Url";

            ///<summary>目标，取值：expand、iframe、open、blank</summary>
            public const String Target = "Target";

            ///<summary>图标样式</summary>
            public const String Icon = "Icon";

            ///<summary>排序</summary>
            public const String Sort = "Sort";

            ///<summary>是否可见</summary>
            public const String Visible = "Visible";

            ///<summary>必要的菜单。必须至少有角色拥有这些权限，如果没有则自动授权给系统角色</summary>
            public const String Necessary = "Necessary";

            ///<summary></summary>
            public const String Remark = "Remark";

            ///<summary>创建人id</summary>
            public const String CreateUserID = "CreateUserID";

            ///<summary>创建日期</summary>
            public const String CreateDate = "CreateDate";

            ///<summary>修改人id</summary>
            public const String UpdateUserID = "UpdateUserID";

            ///<summary>修改日期</summary>
            public const String UpdateDate = "UpdateDate";

        }
        #endregion
    }

    /// <summary>菜单接口</summary>
    public partial interface IMenu
    {
        #region 属性
        /// <summary>编号</summary>
        Int32 ID { get; set; }

        /// <summary>名称</summary>
        String Name { get; set; }

        /// <summary>显示名</summary>
        String DisplayName { get; set; }

        /// <summary>父编号</summary>
        Int32 ParentID { get; set; }

        /// <summary>链接</summary>
        String Url { get; set; }

        /// <summary>目标，取值：expand、iframe、open、blank</summary>
        String Target { get; set; }

        /// <summary>图标样式</summary>
        String Icon { get; set; }

        /// <summary>排序</summary>
        Int32 Sort { get; set; }

        /// <summary>是否可见</summary>
        Boolean Visible { get; set; }

        /// <summary>必要的菜单。必须至少有角色拥有这些权限，如果没有则自动授权给系统角色</summary>
        Boolean Necessary { get; set; }

        /// <summary></summary>
        String Remark { get; set; }

        /// <summary>创建人id</summary>
        Int32 CreateUserID { get; set; }

        /// <summary>创建日期</summary>
        DateTime CreateDate { get; set; }

        /// <summary>修改人id</summary>
        Int32 UpdateUserID { get; set; }

        /// <summary>修改日期</summary>
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