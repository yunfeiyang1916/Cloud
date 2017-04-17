using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using XCode;
using XCode.Configuration;
using XCode.DataAccessLayer;

namespace Cloud.Domain
{
    /// <summary>内容测试表</summary>
    [Serializable]
    [DataObject]
    [Description("内容测试表")]
    [BindIndex("PK__Content__3214EC2744FF419A", true, "ID")]
    [BindTable("ContentTest", Description = "内容测试表", ConnName = "Cloud", DbType = DatabaseType.SqlServer)]
    public partial class ContentTest : IContentTest
    {
        #region 属性
        private Int32 _ID;
        /// <summary>主键</summary>
        [DisplayName("主键")]
        [Description("主键")]
        [DataObjectField(true, true, false, 10)]
        [BindColumn(1, "ID", "主键", null, "int", 10, 0, false)]
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

        private String _Type;
        /// <summary>分类</summary>
        [DisplayName("分类")]
        [Description("分类")]
        [DataObjectField(false, false, true, 50)]
        [BindColumn(3, "Type", "分类", null, "nvarchar(50)", 0, 0, true)]
        public virtual String Type
        {
            get { return _Type; }
            set { if (OnPropertyChanging(__.Type, value)) { _Type = value; OnPropertyChanged(__.Type); } }
        }

        private String _Content;
        /// <summary>内容</summary>
        [DisplayName("内容")]
        [Description("内容")]
        [DataObjectField(false, false, true, 2147483647)]
        [BindColumn(4, "Content", "内容", null, "text", 0, 0, false)]
        public virtual String Content
        {
            get { return _Content; }
            set { if (OnPropertyChanging(__.Content, value)) { _Content = value; OnPropertyChanged(__.Content); } }
        }

        private String _Author;
        /// <summary>作者</summary>
        [DisplayName("作者")]
        [Description("作者")]
        [DataObjectField(false, false, true, 50)]
        [BindColumn(5, "Author", "作者", null, "nvarchar(50)", 0, 0, true)]
        public virtual String Author
        {
            get { return _Author; }
            set { if (OnPropertyChanging(__.Author, value)) { _Author = value; OnPropertyChanged(__.Author); } }
        }

        private String _ImgUrl;
        /// <summary>图片地址</summary>
        [DisplayName("图片地址")]
        [Description("图片地址")]
        [DataObjectField(false, false, true, 255)]
        [BindColumn(6, "ImgUrl", "图片地址", "", "nvarchar(255)", 0, 0, true)]
        public virtual String ImgUrl
        {
            get { return _ImgUrl; }
            set { if (OnPropertyChanging(__.ImgUrl, value)) { _ImgUrl = value; OnPropertyChanged(__.ImgUrl); } }
        }

        private String _SeoTitle;
        /// <summary>SEO标题</summary>
        [DisplayName("SEO标题")]
        [Description("SEO标题")]
        [DataObjectField(false, false, true, 255)]
        [BindColumn(7, "SeoTitle", "SEO标题", "", "nvarchar(255)", 0, 0, true)]
        public virtual String SeoTitle
        {
            get { return _SeoTitle; }
            set { if (OnPropertyChanging(__.SeoTitle, value)) { _SeoTitle = value; OnPropertyChanged(__.SeoTitle); } }
        }

        private String _SeoKeywords;
        /// <summary>SEO关健字</summary>
        [DisplayName("SEO关健字")]
        [Description("SEO关健字")]
        [DataObjectField(false, false, true, 255)]
        [BindColumn(8, "SeoKeywords", "SEO关健字", "", "nvarchar(255)", 0, 0, true)]
        public virtual String SeoKeywords
        {
            get { return _SeoKeywords; }
            set { if (OnPropertyChanging(__.SeoKeywords, value)) { _SeoKeywords = value; OnPropertyChanged(__.SeoKeywords); } }
        }

        private String _SeoDescription;
        /// <summary>SEO描述</summary>
        [DisplayName("SEO描述")]
        [Description("SEO描述")]
        [DataObjectField(false, false, true, 255)]
        [BindColumn(9, "SeoDescription", "SEO描述", "", "nvarchar(255)", 0, 0, true)]
        public virtual String SeoDescription
        {
            get { return _SeoDescription; }
            set { if (OnPropertyChanging(__.SeoDescription, value)) { _SeoDescription = value; OnPropertyChanged(__.SeoDescription); } }
        }

        private String _Tags;
        /// <summary>TAG标签逗号分隔</summary>
        [DisplayName("TAG标签逗号分隔")]
        [Description("TAG标签逗号分隔")]
        [DataObjectField(false, false, true, 500)]
        [BindColumn(10, "Tags", "TAG标签逗号分隔", null, "nvarchar(500)", 0, 0, true)]
        public virtual String Tags
        {
            get { return _Tags; }
            set { if (OnPropertyChanging(__.Tags, value)) { _Tags = value; OnPropertyChanged(__.Tags); } }
        }

        private String _ZhaiYao;
        /// <summary>内容摘要</summary>
        [DisplayName("内容摘要")]
        [Description("内容摘要")]
        [DataObjectField(false, false, true, 255)]
        [BindColumn(11, "ZhaiYao", "内容摘要", "", "nvarchar(255)", 0, 0, true)]
        public virtual String ZhaiYao
        {
            get { return _ZhaiYao; }
            set { if (OnPropertyChanging(__.ZhaiYao, value)) { _ZhaiYao = value; OnPropertyChanged(__.ZhaiYao); } }
        }

        private Int32 _Sort;
        /// <summary>排序</summary>
        [DisplayName("排序")]
        [Description("排序")]
        [DataObjectField(false, false, true, 10)]
        [BindColumn(12, "Sort", "排序", null, "int", 10, 0, false)]
        public virtual Int32 Sort
        {
            get { return _Sort; }
            set { if (OnPropertyChanging(__.Sort, value)) { _Sort = value; OnPropertyChanged(__.Sort); } }
        }

        private Int32 _Click;
        /// <summary>浏览次数</summary>
        [DisplayName("浏览次数")]
        [Description("浏览次数")]
        [DataObjectField(false, false, true, 10)]
        [BindColumn(13, "Click", "浏览次数", null, "int", 10, 0, false)]
        public virtual Int32 Click
        {
            get { return _Click; }
            set { if (OnPropertyChanging(__.Click, value)) { _Click = value; OnPropertyChanged(__.Click); } }
        }

        private SByte _Status;
        /// <summary>状态0正常1未审核2锁定</summary>
        [DisplayName("状态0正常1未审核2锁定")]
        [Description("状态0正常1未审核2锁定")]
        [DataObjectField(false, false, true, 3)]
        [BindColumn(14, "Status", "状态0正常1未审核2锁定", null, "tinyint", 3, 0, false)]
        public virtual SByte Status
        {
            get { return _Status; }
            set { if (OnPropertyChanging(__.Status, value)) { _Status = value; OnPropertyChanged(__.Status); } }
        }

        private Boolean _IsMsg;
        /// <summary>是否允许评论</summary>
        [DisplayName("是否允许评论")]
        [Description("是否允许评论")]
        [DataObjectField(false, false, true, 1)]
        [BindColumn(15, "IsMsg", "是否允许评论", null, "bit", 0, 0, false)]
        public virtual Boolean IsMsg
        {
            get { return _IsMsg; }
            set { if (OnPropertyChanging(__.IsMsg, value)) { _IsMsg = value; OnPropertyChanged(__.IsMsg); } }
        }

        private Boolean _IsTop;
        /// <summary>是否置顶</summary>
        [DisplayName("是否置顶")]
        [Description("是否置顶")]
        [DataObjectField(false, false, true, 1)]
        [BindColumn(16, "IsTop", "是否置顶", null, "bit", 0, 0, false)]
        public virtual Boolean IsTop
        {
            get { return _IsTop; }
            set { if (OnPropertyChanging(__.IsTop, value)) { _IsTop = value; OnPropertyChanged(__.IsTop); } }
        }

        private Boolean _IsRed;
        /// <summary>是否推荐</summary>
        [DisplayName("是否推荐")]
        [Description("是否推荐")]
        [DataObjectField(false, false, true, 1)]
        [BindColumn(17, "IsRed", "是否推荐", null, "bit", 0, 0, false)]
        public virtual Boolean IsRed
        {
            get { return _IsRed; }
            set { if (OnPropertyChanging(__.IsRed, value)) { _IsRed = value; OnPropertyChanged(__.IsRed); } }
        }

        private Boolean _IsHot;
        /// <summary>是否热门</summary>
        [DisplayName("是否热门")]
        [Description("是否热门")]
        [DataObjectField(false, false, true, 1)]
        [BindColumn(18, "IsHot", "是否热门", null, "bit", 0, 0, false)]
        public virtual Boolean IsHot
        {
            get { return _IsHot; }
            set { if (OnPropertyChanging(__.IsHot, value)) { _IsHot = value; OnPropertyChanged(__.IsHot); } }
        }

        private Boolean _IsSlide;
        /// <summary>是否幻灯片</summary>
        [DisplayName("是否幻灯片")]
        [Description("是否幻灯片")]
        [DataObjectField(false, false, true, 1)]
        [BindColumn(19, "IsSlide", "是否幻灯片", null, "bit", 0, 0, false)]
        public virtual Boolean IsSlide
        {
            get { return _IsSlide; }
            set { if (OnPropertyChanging(__.IsSlide, value)) { _IsSlide = value; OnPropertyChanged(__.IsSlide); } }
        }

        private Boolean _IsSys;
        /// <summary>是否管理员发布0不是1是</summary>
        [DisplayName("是否管理员发布0不是1是")]
        [Description("是否管理员发布0不是1是")]
        [DataObjectField(false, false, true, 1)]
        [BindColumn(20, "IsSys", "是否管理员发布0不是1是", null, "bit", 0, 0, false)]
        public virtual Boolean IsSys
        {
            get { return _IsSys; }
            set { if (OnPropertyChanging(__.IsSys, value)) { _IsSys = value; OnPropertyChanged(__.IsSys); } }
        }

        private String _UserName;
        /// <summary>用户名</summary>
        [DisplayName("用户名")]
        [Description("用户名")]
        [DataObjectField(false, false, true, 100)]
        [BindColumn(21, "UserName", "用户名", null, "nvarchar(100)", 0, 0, true)]
        public virtual String UserName
        {
            get { return _UserName; }
            set { if (OnPropertyChanging(__.UserName, value)) { _UserName = value; OnPropertyChanged(__.UserName); } }
        }

        private Int32 _CreateUserID;
        /// <summary></summary>
        [DisplayName("CreateUserID")]
        [Description("")]
        [DataObjectField(false, false, true, 10)]
        [BindColumn(22, "CreateUserID", "", null, "int", 10, 0, false)]
        public virtual Int32 CreateUserID
        {
            get { return _CreateUserID; }
            set { if (OnPropertyChanging(__.CreateUserID, value)) { _CreateUserID = value; OnPropertyChanged(__.CreateUserID); } }
        }

        private DateTime _CreateDate;
        /// <summary></summary>
        [DisplayName("CreateDate")]
        [Description("")]
        [DataObjectField(false, false, true, 3)]
        [BindColumn(23, "CreateDate", "", null, "datetime", 3, 0, false)]
        public virtual DateTime CreateDate
        {
            get { return _CreateDate; }
            set { if (OnPropertyChanging(__.CreateDate, value)) { _CreateDate = value; OnPropertyChanged(__.CreateDate); } }
        }

        private Int32 _UpdateUserID;
        /// <summary></summary>
        [DisplayName("UpdateUserID")]
        [Description("")]
        [DataObjectField(false, false, true, 10)]
        [BindColumn(24, "UpdateUserID", "", null, "int", 10, 0, false)]
        public virtual Int32 UpdateUserID
        {
            get { return _UpdateUserID; }
            set { if (OnPropertyChanging(__.UpdateUserID, value)) { _UpdateUserID = value; OnPropertyChanged(__.UpdateUserID); } }
        }

        private DateTime _UpdateDate;
        /// <summary></summary>
        [DisplayName("UpdateDate")]
        [Description("")]
        [DataObjectField(false, false, true, 3)]
        [BindColumn(25, "UpdateDate", "", null, "datetime", 3, 0, false)]
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
                    case __.Type : return _Type;
                    case __.Content : return _Content;
                    case __.Author : return _Author;
                    case __.ImgUrl : return _ImgUrl;
                    case __.SeoTitle : return _SeoTitle;
                    case __.SeoKeywords : return _SeoKeywords;
                    case __.SeoDescription : return _SeoDescription;
                    case __.Tags : return _Tags;
                    case __.ZhaiYao : return _ZhaiYao;
                    case __.Sort : return _Sort;
                    case __.Click : return _Click;
                    case __.Status : return _Status;
                    case __.IsMsg : return _IsMsg;
                    case __.IsTop : return _IsTop;
                    case __.IsRed : return _IsRed;
                    case __.IsHot : return _IsHot;
                    case __.IsSlide : return _IsSlide;
                    case __.IsSys : return _IsSys;
                    case __.UserName : return _UserName;
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
                    case __.Type : _Type = Convert.ToString(value); break;
                    case __.Content : _Content = Convert.ToString(value); break;
                    case __.Author : _Author = Convert.ToString(value); break;
                    case __.ImgUrl : _ImgUrl = Convert.ToString(value); break;
                    case __.SeoTitle : _SeoTitle = Convert.ToString(value); break;
                    case __.SeoKeywords : _SeoKeywords = Convert.ToString(value); break;
                    case __.SeoDescription : _SeoDescription = Convert.ToString(value); break;
                    case __.Tags : _Tags = Convert.ToString(value); break;
                    case __.ZhaiYao : _ZhaiYao = Convert.ToString(value); break;
                    case __.Sort : _Sort = Convert.ToInt32(value); break;
                    case __.Click : _Click = Convert.ToInt32(value); break;
                    case __.Status : _Status = Convert.ToSByte(value); break;
                    case __.IsMsg : _IsMsg = Convert.ToBoolean(value); break;
                    case __.IsTop : _IsTop = Convert.ToBoolean(value); break;
                    case __.IsRed : _IsRed = Convert.ToBoolean(value); break;
                    case __.IsHot : _IsHot = Convert.ToBoolean(value); break;
                    case __.IsSlide : _IsSlide = Convert.ToBoolean(value); break;
                    case __.IsSys : _IsSys = Convert.ToBoolean(value); break;
                    case __.UserName : _UserName = Convert.ToString(value); break;
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
        /// <summary>取得内容测试表字段信息的快捷方式</summary>
        public partial class _
        {
            ///<summary>主键</summary>
            public static readonly Field ID = FindByName(__.ID);

            ///<summary>名称</summary>
            public static readonly Field Name = FindByName(__.Name);

            ///<summary>分类</summary>
            public static readonly Field Type = FindByName(__.Type);

            ///<summary>内容</summary>
            public static readonly Field Content = FindByName(__.Content);

            ///<summary>作者</summary>
            public static readonly Field Author = FindByName(__.Author);

            ///<summary>图片地址</summary>
            public static readonly Field ImgUrl = FindByName(__.ImgUrl);

            ///<summary>SEO标题</summary>
            public static readonly Field SeoTitle = FindByName(__.SeoTitle);

            ///<summary>SEO关健字</summary>
            public static readonly Field SeoKeywords = FindByName(__.SeoKeywords);

            ///<summary>SEO描述</summary>
            public static readonly Field SeoDescription = FindByName(__.SeoDescription);

            ///<summary>TAG标签逗号分隔</summary>
            public static readonly Field Tags = FindByName(__.Tags);

            ///<summary>内容摘要</summary>
            public static readonly Field ZhaiYao = FindByName(__.ZhaiYao);

            ///<summary>排序</summary>
            public static readonly Field Sort = FindByName(__.Sort);

            ///<summary>浏览次数</summary>
            public static readonly Field Click = FindByName(__.Click);

            ///<summary>状态0正常1未审核2锁定</summary>
            public static readonly Field Status = FindByName(__.Status);

            ///<summary>是否允许评论</summary>
            public static readonly Field IsMsg = FindByName(__.IsMsg);

            ///<summary>是否置顶</summary>
            public static readonly Field IsTop = FindByName(__.IsTop);

            ///<summary>是否推荐</summary>
            public static readonly Field IsRed = FindByName(__.IsRed);

            ///<summary>是否热门</summary>
            public static readonly Field IsHot = FindByName(__.IsHot);

            ///<summary>是否幻灯片</summary>
            public static readonly Field IsSlide = FindByName(__.IsSlide);

            ///<summary>是否管理员发布0不是1是</summary>
            public static readonly Field IsSys = FindByName(__.IsSys);

            ///<summary>用户名</summary>
            public static readonly Field UserName = FindByName(__.UserName);

            ///<summary></summary>
            public static readonly Field CreateUserID = FindByName(__.CreateUserID);

            ///<summary></summary>
            public static readonly Field CreateDate = FindByName(__.CreateDate);

            ///<summary></summary>
            public static readonly Field UpdateUserID = FindByName(__.UpdateUserID);

            ///<summary></summary>
            public static readonly Field UpdateDate = FindByName(__.UpdateDate);

            static Field FindByName(String name) { return Meta.Table.FindByName(name); }
        }

        /// <summary>取得内容测试表字段名称的快捷方式</summary>
        partial class __
        {
            ///<summary>主键</summary>
            public const String ID = "ID";

            ///<summary>名称</summary>
            public const String Name = "Name";

            ///<summary>分类</summary>
            public const String Type = "Type";

            ///<summary>内容</summary>
            public const String Content = "Content";

            ///<summary>作者</summary>
            public const String Author = "Author";

            ///<summary>图片地址</summary>
            public const String ImgUrl = "ImgUrl";

            ///<summary>SEO标题</summary>
            public const String SeoTitle = "SeoTitle";

            ///<summary>SEO关健字</summary>
            public const String SeoKeywords = "SeoKeywords";

            ///<summary>SEO描述</summary>
            public const String SeoDescription = "SeoDescription";

            ///<summary>TAG标签逗号分隔</summary>
            public const String Tags = "Tags";

            ///<summary>内容摘要</summary>
            public const String ZhaiYao = "ZhaiYao";

            ///<summary>排序</summary>
            public const String Sort = "Sort";

            ///<summary>浏览次数</summary>
            public const String Click = "Click";

            ///<summary>状态0正常1未审核2锁定</summary>
            public const String Status = "Status";

            ///<summary>是否允许评论</summary>
            public const String IsMsg = "IsMsg";

            ///<summary>是否置顶</summary>
            public const String IsTop = "IsTop";

            ///<summary>是否推荐</summary>
            public const String IsRed = "IsRed";

            ///<summary>是否热门</summary>
            public const String IsHot = "IsHot";

            ///<summary>是否幻灯片</summary>
            public const String IsSlide = "IsSlide";

            ///<summary>是否管理员发布0不是1是</summary>
            public const String IsSys = "IsSys";

            ///<summary>用户名</summary>
            public const String UserName = "UserName";

            ///<summary></summary>
            public const String CreateUserID = "CreateUserID";

            ///<summary></summary>
            public const String CreateDate = "CreateDate";

            ///<summary></summary>
            public const String UpdateUserID = "UpdateUserID";

            ///<summary></summary>
            public const String UpdateDate = "UpdateDate";

        }
        #endregion
    }

    /// <summary>内容测试表接口</summary>
    public partial interface IContentTest
    {
        #region 属性
        /// <summary>主键</summary>
        Int32 ID { get; set; }

        /// <summary>名称</summary>
        String Name { get; set; }

        /// <summary>分类</summary>
        String Type { get; set; }

        /// <summary>内容</summary>
        String Content { get; set; }

        /// <summary>作者</summary>
        String Author { get; set; }

        /// <summary>图片地址</summary>
        String ImgUrl { get; set; }

        /// <summary>SEO标题</summary>
        String SeoTitle { get; set; }

        /// <summary>SEO关健字</summary>
        String SeoKeywords { get; set; }

        /// <summary>SEO描述</summary>
        String SeoDescription { get; set; }

        /// <summary>TAG标签逗号分隔</summary>
        String Tags { get; set; }

        /// <summary>内容摘要</summary>
        String ZhaiYao { get; set; }

        /// <summary>排序</summary>
        Int32 Sort { get; set; }

        /// <summary>浏览次数</summary>
        Int32 Click { get; set; }

        /// <summary>状态0正常1未审核2锁定</summary>
        SByte Status { get; set; }

        /// <summary>是否允许评论</summary>
        Boolean IsMsg { get; set; }

        /// <summary>是否置顶</summary>
        Boolean IsTop { get; set; }

        /// <summary>是否推荐</summary>
        Boolean IsRed { get; set; }

        /// <summary>是否热门</summary>
        Boolean IsHot { get; set; }

        /// <summary>是否幻灯片</summary>
        Boolean IsSlide { get; set; }

        /// <summary>是否管理员发布0不是1是</summary>
        Boolean IsSys { get; set; }

        /// <summary>用户名</summary>
        String UserName { get; set; }

        /// <summary></summary>
        Int32 CreateUserID { get; set; }

        /// <summary></summary>
        DateTime CreateDate { get; set; }

        /// <summary></summary>
        Int32 UpdateUserID { get; set; }

        /// <summary></summary>
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