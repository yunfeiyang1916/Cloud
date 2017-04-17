using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using XCode;
using XCode.Configuration;
using XCode.DataAccessLayer;

namespace Cloud.Domain
{
    /// <summary>按钮</summary>
    [Serializable]
    [DataObject]
    [Description("按钮")]
    [BindIndex("PK__Button__3214EC273A81B327", true, "ID")]
    [BindRelation("ID", true, "MenuButton", "ButtonID")]
    [BindRelation("ID", true, "RoleMenuButton", "ButtonID")]
    [BindTable("Button", Description = "按钮", ConnName = "Cloud", DbType = DatabaseType.SqlServer)]
    public partial class Button : IButton
    {
        #region 属性
        private Int32 _ID;
        /// <summary>ID</summary>
        [DisplayName("ID")]
        [Description("ID")]
        [DataObjectField(true, true, false, 10)]
        [BindColumn(1, "ID", "ID", null, "int", 10, 0, false)]
        public virtual Int32 ID
        {
            get { return _ID; }
            set { if (OnPropertyChanging(__.ID, value)) { _ID = value; OnPropertyChanged(__.ID); } }
        }

        private String _Code;
        /// <summary>编码</summary>
        [DisplayName("编码")]
        [Description("编码")]
        [DataObjectField(false, false, true, 50)]
        [BindColumn(2, "Code", "编码", null, "nvarchar(50)", 0, 0, true)]
        public virtual String Code
        {
            get { return _Code; }
            set { if (OnPropertyChanging(__.Code, value)) { _Code = value; OnPropertyChanged(__.Code); } }
        }

        private String _Name;
        /// <summary>名称</summary>
        [DisplayName("名称")]
        [Description("名称")]
        [DataObjectField(false, false, true, 50)]
        [BindColumn(3, "Name", "名称", null, "nvarchar(50)", 0, 0, true, Master=true)]
        public virtual String Name
        {
            get { return _Name; }
            set { if (OnPropertyChanging(__.Name, value)) { _Name = value; OnPropertyChanged(__.Name); } }
        }

        private String _Icon;
        /// <summary>图标样式</summary>
        [DisplayName("图标样式")]
        [Description("图标样式")]
        [DataObjectField(false, false, true, 50)]
        [BindColumn(4, "Icon", "图标样式", null, "nvarchar(50)", 0, 0, true)]
        public virtual String Icon
        {
            get { return _Icon; }
            set { if (OnPropertyChanging(__.Icon, value)) { _Icon = value; OnPropertyChanged(__.Icon); } }
        }

        private Int32 _Location;
        /// <summary>所处页面位置 1 初始 2 列表</summary>
        [DisplayName("所处页面位置1初始2列表")]
        [Description("所处页面位置 1 初始 2 列表")]
        [DataObjectField(false, false, true, 10)]
        [BindColumn(5, "Location", "所处页面位置 1 初始 2 列表", null, "int", 10, 0, false)]
        public virtual Int32 Location
        {
            get { return _Location; }
            set { if (OnPropertyChanging(__.Location, value)) { _Location = value; OnPropertyChanged(__.Location); } }
        }

        private String _JsEvent;
        /// <summary>js绑定脚本</summary>
        [DisplayName("js绑定脚本")]
        [Description("js绑定脚本")]
        [DataObjectField(false, false, true, 50)]
        [BindColumn(6, "JsEvent", "js绑定脚本", null, "nvarchar(50)", 0, 0, true)]
        public virtual String JsEvent
        {
            get { return _JsEvent; }
            set { if (OnPropertyChanging(__.JsEvent, value)) { _JsEvent = value; OnPropertyChanged(__.JsEvent); } }
        }

        private Boolean _AllowUpdate;
        /// <summary>是否允许更新</summary>
        [DisplayName("是否允许更新")]
        [Description("是否允许更新")]
        [DataObjectField(false, false, true, 1)]
        [BindColumn(7, "AllowUpdate", "是否允许更新", null, "bit", 0, 0, false)]
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
        [BindColumn(8, "AllowDelete", "是否允许删除", null, "bit", 0, 0, false)]
        public virtual Boolean AllowDelete
        {
            get { return _AllowDelete; }
            set { if (OnPropertyChanging(__.AllowDelete, value)) { _AllowDelete = value; OnPropertyChanged(__.AllowDelete); } }
        }

        private String _Remark;
        /// <summary>备注</summary>
        [DisplayName("备注")]
        [Description("备注")]
        [DataObjectField(false, false, true, 500)]
        [BindColumn(9, "Remark", "备注", null, "nvarchar(500)", 0, 0, true)]
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
        [BindColumn(10, "Sort", "排序", null, "int", 10, 0, false)]
        public virtual Int32 Sort
        {
            get { return _Sort; }
            set { if (OnPropertyChanging(__.Sort, value)) { _Sort = value; OnPropertyChanged(__.Sort); } }
        }

        private Int32 _CreateUserID;
        /// <summary>创建人</summary>
        [DisplayName("创建人")]
        [Description("创建人")]
        [DataObjectField(false, false, true, 10)]
        [BindColumn(11, "CreateUserID", "创建人", null, "int", 10, 0, false)]
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
        [BindColumn(12, "CreateDate", "创建日期", null, "datetime", 3, 0, false)]
        public virtual DateTime CreateDate
        {
            get { return _CreateDate; }
            set { if (OnPropertyChanging(__.CreateDate, value)) { _CreateDate = value; OnPropertyChanged(__.CreateDate); } }
        }

        private Int32 _UpdateUserID;
        /// <summary>修改人</summary>
        [DisplayName("修改人")]
        [Description("修改人")]
        [DataObjectField(false, false, true, 10)]
        [BindColumn(13, "UpdateUserID", "修改人", null, "int", 10, 0, false)]
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
        [BindColumn(14, "UpdateDate", "修改日期", null, "datetime", 3, 0, false)]
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
                    case __.Code : return _Code;
                    case __.Name : return _Name;
                    case __.Icon : return _Icon;
                    case __.Location : return _Location;
                    case __.JsEvent : return _JsEvent;
                    case __.AllowUpdate : return _AllowUpdate;
                    case __.AllowDelete : return _AllowDelete;
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
                    case __.Code : _Code = Convert.ToString(value); break;
                    case __.Name : _Name = Convert.ToString(value); break;
                    case __.Icon : _Icon = Convert.ToString(value); break;
                    case __.Location : _Location = Convert.ToInt32(value); break;
                    case __.JsEvent : _JsEvent = Convert.ToString(value); break;
                    case __.AllowUpdate : _AllowUpdate = Convert.ToBoolean(value); break;
                    case __.AllowDelete : _AllowDelete = Convert.ToBoolean(value); break;
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
        /// <summary>取得按钮字段信息的快捷方式</summary>
        public partial class _
        {
            ///<summary>ID</summary>
            public static readonly Field ID = FindByName(__.ID);

            ///<summary>编码</summary>
            public static readonly Field Code = FindByName(__.Code);

            ///<summary>名称</summary>
            public static readonly Field Name = FindByName(__.Name);

            ///<summary>图标样式</summary>
            public static readonly Field Icon = FindByName(__.Icon);

            ///<summary>所处页面位置 1 初始 2 列表</summary>
            public static readonly Field Location = FindByName(__.Location);

            ///<summary>js绑定脚本</summary>
            public static readonly Field JsEvent = FindByName(__.JsEvent);

            ///<summary>是否允许更新</summary>
            public static readonly Field AllowUpdate = FindByName(__.AllowUpdate);

            ///<summary>是否允许删除</summary>
            public static readonly Field AllowDelete = FindByName(__.AllowDelete);

            ///<summary>备注</summary>
            public static readonly Field Remark = FindByName(__.Remark);

            ///<summary>排序</summary>
            public static readonly Field Sort = FindByName(__.Sort);

            ///<summary>创建人</summary>
            public static readonly Field CreateUserID = FindByName(__.CreateUserID);

            ///<summary>创建日期</summary>
            public static readonly Field CreateDate = FindByName(__.CreateDate);

            ///<summary>修改人</summary>
            public static readonly Field UpdateUserID = FindByName(__.UpdateUserID);

            ///<summary>修改日期</summary>
            public static readonly Field UpdateDate = FindByName(__.UpdateDate);

            static Field FindByName(String name) { return Meta.Table.FindByName(name); }
        }

        /// <summary>取得按钮字段名称的快捷方式</summary>
        partial class __
        {
            ///<summary>ID</summary>
            public const String ID = "ID";

            ///<summary>编码</summary>
            public const String Code = "Code";

            ///<summary>名称</summary>
            public const String Name = "Name";

            ///<summary>图标样式</summary>
            public const String Icon = "Icon";

            ///<summary>所处页面位置 1 初始 2 列表</summary>
            public const String Location = "Location";

            ///<summary>js绑定脚本</summary>
            public const String JsEvent = "JsEvent";

            ///<summary>是否允许更新</summary>
            public const String AllowUpdate = "AllowUpdate";

            ///<summary>是否允许删除</summary>
            public const String AllowDelete = "AllowDelete";

            ///<summary>备注</summary>
            public const String Remark = "Remark";

            ///<summary>排序</summary>
            public const String Sort = "Sort";

            ///<summary>创建人</summary>
            public const String CreateUserID = "CreateUserID";

            ///<summary>创建日期</summary>
            public const String CreateDate = "CreateDate";

            ///<summary>修改人</summary>
            public const String UpdateUserID = "UpdateUserID";

            ///<summary>修改日期</summary>
            public const String UpdateDate = "UpdateDate";

        }
        #endregion
    }

    /// <summary>按钮接口</summary>
    public partial interface IButton
    {
        #region 属性
        /// <summary>ID</summary>
        Int32 ID { get; set; }

        /// <summary>编码</summary>
        String Code { get; set; }

        /// <summary>名称</summary>
        String Name { get; set; }

        /// <summary>图标样式</summary>
        String Icon { get; set; }

        /// <summary>所处页面位置 1 初始 2 列表</summary>
        Int32 Location { get; set; }

        /// <summary>js绑定脚本</summary>
        String JsEvent { get; set; }

        /// <summary>是否允许更新</summary>
        Boolean AllowUpdate { get; set; }

        /// <summary>是否允许删除</summary>
        Boolean AllowDelete { get; set; }

        /// <summary>备注</summary>
        String Remark { get; set; }

        /// <summary>排序</summary>
        Int32 Sort { get; set; }

        /// <summary>创建人</summary>
        Int32 CreateUserID { get; set; }

        /// <summary>创建日期</summary>
        DateTime CreateDate { get; set; }

        /// <summary>修改人</summary>
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