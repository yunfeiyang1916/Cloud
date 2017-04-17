using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using XCode;
using XCode.Configuration;
using XCode.DataAccessLayer;

namespace Cloud.Domain
{
    /// <summary>数据权限</summary>
    [Serializable]
    [DataObject]
    [Description("数据权限")]
    [BindIndex("PK_DataPermission", true, "ID")]
    [BindRelation("ID", true, "RoleDataPermission", "DataPermissionID")]
    [BindTable("DataPermission", Description = "数据权限", ConnName = "Cloud", DbType = DatabaseType.SqlServer)]
    public partial class DataPermission : IDataPermission
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

        private String _Name;
        /// <summary>名称</summary>
        [DisplayName("名称")]
        [Description("名称")]
        [DataObjectField(false, false, true, 50)]
        [BindColumn(2, "Name", "名称", null, "nvarchar(50)", 0, 0, true, Master=true)]
        public virtual String Name
        {
            get { return _Name; }
            set { if (OnPropertyChanging(__.Name, value)) { _Name = value; OnPropertyChanged(__.Name); } }
        }

        private Int32 _ParentID;
        /// <summary>上级</summary>
        [DisplayName("上级")]
        [Description("上级")]
        [DataObjectField(false, false, true, 10)]
        [BindColumn(3, "ParentID", "上级", null, "int", 10, 0, false)]
        public virtual Int32 ParentID
        {
            get { return _ParentID; }
            set { if (OnPropertyChanging(__.ParentID, value)) { _ParentID = value; OnPropertyChanged(__.ParentID); } }
        }

        private Int32 _Sort;
        /// <summary>排序</summary>
        [DisplayName("排序")]
        [Description("排序")]
        [DataObjectField(false, false, true, 10)]
        [BindColumn(4, "Sort", "排序", null, "int", 10, 0, false)]
        public virtual Int32 Sort
        {
            get { return _Sort; }
            set { if (OnPropertyChanging(__.Sort, value)) { _Sort = value; OnPropertyChanged(__.Sort); } }
        }

        private String _Remark;
        /// <summary>备注</summary>
        [DisplayName("备注")]
        [Description("备注")]
        [DataObjectField(false, false, true, 200)]
        [BindColumn(5, "Remark", "备注", null, "nvarchar(200)", 0, 0, true)]
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
        [BindColumn(6, "CreateUserID", "创建人id", null, "int", 10, 0, false)]
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
        [BindColumn(7, "CreateDate", "创建日期", null, "datetime", 3, 0, false)]
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
        [BindColumn(8, "UpdateUserID", "修改人id", null, "int", 10, 0, false)]
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
        [BindColumn(9, "UpdateDate", "修改日期", null, "datetime", 3, 0, false)]
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
                    case __.ParentID : return _ParentID;
                    case __.Sort : return _Sort;
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
                    case __.ParentID : _ParentID = Convert.ToInt32(value); break;
                    case __.Sort : _Sort = Convert.ToInt32(value); break;
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
        /// <summary>取得数据权限字段信息的快捷方式</summary>
        public partial class _
        {
            ///<summary>主键ID</summary>
            public static readonly Field ID = FindByName(__.ID);

            ///<summary>名称</summary>
            public static readonly Field Name = FindByName(__.Name);

            ///<summary>上级</summary>
            public static readonly Field ParentID = FindByName(__.ParentID);

            ///<summary>排序</summary>
            public static readonly Field Sort = FindByName(__.Sort);

            ///<summary>备注</summary>
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

        /// <summary>取得数据权限字段名称的快捷方式</summary>
        partial class __
        {
            ///<summary>主键ID</summary>
            public const String ID = "ID";

            ///<summary>名称</summary>
            public const String Name = "Name";

            ///<summary>上级</summary>
            public const String ParentID = "ParentID";

            ///<summary>排序</summary>
            public const String Sort = "Sort";

            ///<summary>备注</summary>
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

    /// <summary>数据权限接口</summary>
    public partial interface IDataPermission
    {
        #region 属性
        /// <summary>主键ID</summary>
        Int32 ID { get; set; }

        /// <summary>名称</summary>
        String Name { get; set; }

        /// <summary>上级</summary>
        Int32 ParentID { get; set; }

        /// <summary>排序</summary>
        Int32 Sort { get; set; }

        /// <summary>备注</summary>
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