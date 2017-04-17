using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using XCode;
using XCode.Configuration;
using XCode.DataAccessLayer;

namespace Cloud.Domain
{
    /// <summary>管理员</summary>
    [Serializable]
    [DataObject]
    [Description("管理员")]
    [BindIndex("IA_Admin_Name", true, "Name")]
    [BindIndex("PK__Admin__3214EC270AD2A005", true, "ID")]
    [BindRelation("ID", true, "AdminRole", "AdminID")]
    [BindTable("Admin", Description = "管理员", ConnName = "Cloud", DbType = DatabaseType.SqlServer)]
    public partial class Admin : IAdmin
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
        /// <summary>名称。登录用户名</summary>
        [DisplayName("名称")]
        [Description("名称。登录用户名")]
        [DataObjectField(false, false, false, 50)]
        [BindColumn(2, "Name", "名称。登录用户名", null, "nvarchar(50)", 0, 0, true, Master=true)]
        public virtual String Name
        {
            get { return _Name; }
            set { if (OnPropertyChanging(__.Name, value)) { _Name = value; OnPropertyChanged(__.Name); } }
        }

        private String _Password;
        /// <summary>密码</summary>
        [DisplayName("密码")]
        [Description("密码")]
        [DataObjectField(false, false, true, 50)]
        [BindColumn(3, "Password", "密码", null, "nvarchar(50)", 0, 0, true)]
        public virtual String Password
        {
            get { return _Password; }
            set { if (OnPropertyChanging(__.Password, value)) { _Password = value; OnPropertyChanged(__.Password); } }
        }

        private String _Salt;
        /// <summary>加密密钥</summary>
        [DisplayName("加密密钥")]
        [Description("加密密钥")]
        [DataObjectField(false, false, true, 50)]
        [BindColumn(4, "Salt", "加密密钥", null, "nvarchar(50)", 0, 0, true)]
        public virtual String Salt
        {
            get { return _Salt; }
            set { if (OnPropertyChanging(__.Salt, value)) { _Salt = value; OnPropertyChanged(__.Salt); } }
        }

        private Int32 _SecurityLevel;
        /// <summary>安全级别</summary>
        [DisplayName("安全级别")]
        [Description("安全级别")]
        [DataObjectField(false, false, true, 10)]
        [BindColumn(5, "SecurityLevel", "安全级别", null, "int", 10, 0, false)]
        public virtual Int32 SecurityLevel
        {
            get { return _SecurityLevel; }
            set { if (OnPropertyChanging(__.SecurityLevel, value)) { _SecurityLevel = value; OnPropertyChanged(__.SecurityLevel); } }
        }

        private String _DisplayName;
        /// <summary>显示名。昵称、中文名等</summary>
        [DisplayName("显示名")]
        [Description("显示名。昵称、中文名等")]
        [DataObjectField(false, false, true, 50)]
        [BindColumn(6, "DisplayName", "显示名。昵称、中文名等", null, "nvarchar(50)", 0, 0, true)]
        public virtual String DisplayName
        {
            get { return _DisplayName; }
            set { if (OnPropertyChanging(__.DisplayName, value)) { _DisplayName = value; OnPropertyChanged(__.DisplayName); } }
        }

        private String _RoleIDs;
        /// <summary>以逗号分隔的角色ID串，主要用于编辑时与前端传值比较</summary>
        [DisplayName("以逗号分隔的角色ID串，主要用于编辑时与前端传值比较")]
        [Description("以逗号分隔的角色ID串，主要用于编辑时与前端传值比较")]
        [DataObjectField(false, false, true, 50)]
        [BindColumn(7, "RoleIDs", "以逗号分隔的角色ID串，主要用于编辑时与前端传值比较", null, "nvarchar(50)", 0, 0, true)]
        public virtual String RoleIDs
        {
            get { return _RoleIDs; }
            set { if (OnPropertyChanging(__.RoleIDs, value)) { _RoleIDs = value; OnPropertyChanged(__.RoleIDs); } }
        }

        private String _HeadIcon;
        /// <summary>头像</summary>
        [DisplayName("头像")]
        [Description("头像")]
        [DataObjectField(false, false, true, 50)]
        [BindColumn(8, "HeadIcon", "头像", null, "nvarchar(50)", 0, 0, true)]
        public virtual String HeadIcon
        {
            get { return _HeadIcon; }
            set { if (OnPropertyChanging(__.HeadIcon, value)) { _HeadIcon = value; OnPropertyChanged(__.HeadIcon); } }
        }

        private Int32 _Sex;
        /// <summary>性别。未知、男、女</summary>
        [DisplayName("性别")]
        [Description("性别。未知、男、女")]
        [DataObjectField(false, false, true, 10)]
        [BindColumn(9, "Sex", "性别。未知、男、女", null, "int", 10, 0, false)]
        public virtual Int32 Sex
        {
            get { return _Sex; }
            set { if (OnPropertyChanging(__.Sex, value)) { _Sex = value; OnPropertyChanged(__.Sex); } }
        }

        private String _Mail;
        /// <summary>邮件</summary>
        [DisplayName("邮件")]
        [Description("邮件")]
        [DataObjectField(false, false, true, 50)]
        [BindColumn(10, "Mail", "邮件", null, "nvarchar(50)", 0, 0, true)]
        public virtual String Mail
        {
            get { return _Mail; }
            set { if (OnPropertyChanging(__.Mail, value)) { _Mail = value; OnPropertyChanged(__.Mail); } }
        }

        private String _Phone;
        /// <summary>电话</summary>
        [DisplayName("电话")]
        [Description("电话")]
        [DataObjectField(false, false, true, 50)]
        [BindColumn(11, "Phone", "电话", null, "nvarchar(50)", 0, 0, true)]
        public virtual String Phone
        {
            get { return _Phone; }
            set { if (OnPropertyChanging(__.Phone, value)) { _Phone = value; OnPropertyChanged(__.Phone); } }
        }

        private String _WeChat;
        /// <summary>微信</summary>
        [DisplayName("微信")]
        [Description("微信")]
        [DataObjectField(false, false, true, 50)]
        [BindColumn(12, "WeChat", "微信", null, "nvarchar(50)", 0, 0, true)]
        public virtual String WeChat
        {
            get { return _WeChat; }
            set { if (OnPropertyChanging(__.WeChat, value)) { _WeChat = value; OnPropertyChanged(__.WeChat); } }
        }

        private String _Remark;
        /// <summary>描述</summary>
        [DisplayName("描述")]
        [Description("描述")]
        [DataObjectField(false, false, true, 500)]
        [BindColumn(13, "Remark", "描述", null, "nvarchar(500)", 0, 0, true)]
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
        [BindColumn(14, "Sort", "排序", null, "int", 10, 0, false)]
        public virtual Int32 Sort
        {
            get { return _Sort; }
            set { if (OnPropertyChanging(__.Sort, value)) { _Sort = value; OnPropertyChanged(__.Sort); } }
        }

        private String _Code;
        /// <summary>代码。身份证、员工编号等</summary>
        [DisplayName("代码")]
        [Description("代码。身份证、员工编号等")]
        [DataObjectField(false, false, true, 50)]
        [BindColumn(15, "Code", "代码。身份证、员工编号等", null, "nvarchar(50)", 0, 0, true)]
        public virtual String Code
        {
            get { return _Code; }
            set { if (OnPropertyChanging(__.Code, value)) { _Code = value; OnPropertyChanged(__.Code); } }
        }

        private String _Question;
        /// <summary>问题</summary>
        [DisplayName("问题")]
        [Description("问题")]
        [DataObjectField(false, false, true, 50)]
        [BindColumn(16, "Question", "问题", null, "nvarchar(50)", 0, 0, true)]
        public virtual String Question
        {
            get { return _Question; }
            set { if (OnPropertyChanging(__.Question, value)) { _Question = value; OnPropertyChanged(__.Question); } }
        }

        private String _Answer;
        /// <summary>答案</summary>
        [DisplayName("答案")]
        [Description("答案")]
        [DataObjectField(false, false, true, 50)]
        [BindColumn(17, "Answer", "答案", null, "nvarchar(50)", 0, 0, true)]
        public virtual String Answer
        {
            get { return _Answer; }
            set { if (OnPropertyChanging(__.Answer, value)) { _Answer = value; OnPropertyChanged(__.Answer); } }
        }

        private Int32 _Logins;
        /// <summary>登录次数</summary>
        [DisplayName("登录次数")]
        [Description("登录次数")]
        [DataObjectField(false, false, true, 10)]
        [BindColumn(18, "Logins", "登录次数", null, "int", 10, 0, false)]
        public virtual Int32 Logins
        {
            get { return _Logins; }
            set { if (OnPropertyChanging(__.Logins, value)) { _Logins = value; OnPropertyChanged(__.Logins); } }
        }

        private DateTime _LastLogin;
        /// <summary>最后登录</summary>
        [DisplayName("最后登录")]
        [Description("最后登录")]
        [DataObjectField(false, false, true, 3)]
        [BindColumn(19, "LastLogin", "最后登录", null, "datetime", 3, 0, false)]
        public virtual DateTime LastLogin
        {
            get { return _LastLogin; }
            set { if (OnPropertyChanging(__.LastLogin, value)) { _LastLogin = value; OnPropertyChanged(__.LastLogin); } }
        }

        private String _LastLoginIP;
        /// <summary>最后登录IP</summary>
        [DisplayName("最后登录IP")]
        [Description("最后登录IP")]
        [DataObjectField(false, false, true, 50)]
        [BindColumn(20, "LastLoginIP", "最后登录IP", null, "nvarchar(50)", 0, 0, true)]
        public virtual String LastLoginIP
        {
            get { return _LastLoginIP; }
            set { if (OnPropertyChanging(__.LastLoginIP, value)) { _LastLoginIP = value; OnPropertyChanged(__.LastLoginIP); } }
        }

        private Boolean _IsAdmin;
        /// <summary>是否是超级管理员</summary>
        [DisplayName("是否是超级管理员")]
        [Description("是否是超级管理员")]
        [DataObjectField(false, false, true, 1)]
        [BindColumn(21, "IsAdmin", "是否是超级管理员", null, "bit", 0, 0, false)]
        public virtual Boolean IsAdmin
        {
            get { return _IsAdmin; }
            set { if (OnPropertyChanging(__.IsAdmin, value)) { _IsAdmin = value; OnPropertyChanged(__.IsAdmin); } }
        }

        private Boolean _Enable;
        /// <summary>是否启用</summary>
        [DisplayName("是否启用")]
        [Description("是否启用")]
        [DataObjectField(false, false, true, 1)]
        [BindColumn(22, "Enable", "是否启用", null, "bit", 0, 0, false)]
        public virtual Boolean Enable
        {
            get { return _Enable; }
            set { if (OnPropertyChanging(__.Enable, value)) { _Enable = value; OnPropertyChanged(__.Enable); } }
        }

        private Boolean _IsMulti;
        /// <summary>是否允许多出登陆</summary>
        [DisplayName("是否允许多出登陆")]
        [Description("是否允许多出登陆")]
        [DataObjectField(false, false, true, 1)]
        [BindColumn(23, "IsMulti", "是否允许多出登陆", null, "bit", 0, 0, false)]
        public virtual Boolean IsMulti
        {
            get { return _IsMulti; }
            set { if (OnPropertyChanging(__.IsMulti, value)) { _IsMulti = value; OnPropertyChanged(__.IsMulti); } }
        }

        private String _Profile;
        /// <summary>配置信息</summary>
        [DisplayName("配置信息")]
        [Description("配置信息")]
        [DataObjectField(false, false, true, 500)]
        [BindColumn(24, "Profile", "配置信息", null, "nvarchar(500)", 0, 0, true)]
        public virtual String Profile
        {
            get { return _Profile; }
            set { if (OnPropertyChanging(__.Profile, value)) { _Profile = value; OnPropertyChanged(__.Profile); } }
        }

        private DateTime _StartTime;
        /// <summary>允许登陆开始时间</summary>
        [DisplayName("允许登陆开始时间")]
        [Description("允许登陆开始时间")]
        [DataObjectField(false, false, true, 3)]
        [BindColumn(25, "StartTime", "允许登陆开始时间", null, "datetime", 3, 0, false)]
        public virtual DateTime StartTime
        {
            get { return _StartTime; }
            set { if (OnPropertyChanging(__.StartTime, value)) { _StartTime = value; OnPropertyChanged(__.StartTime); } }
        }

        private DateTime _EndTime;
        /// <summary>允许登陆结束时间</summary>
        [DisplayName("允许登陆结束时间")]
        [Description("允许登陆结束时间")]
        [DataObjectField(false, false, true, 3)]
        [BindColumn(26, "EndTime", "允许登陆结束时间", null, "datetime", 3, 0, false)]
        public virtual DateTime EndTime
        {
            get { return _EndTime; }
            set { if (OnPropertyChanging(__.EndTime, value)) { _EndTime = value; OnPropertyChanged(__.EndTime); } }
        }

        private DateTime _LockStartTime;
        /// <summary>锁定开始时间</summary>
        [DisplayName("锁定开始时间")]
        [Description("锁定开始时间")]
        [DataObjectField(false, false, true, 3)]
        [BindColumn(27, "LockStartTime", "锁定开始时间", null, "datetime", 3, 0, false)]
        public virtual DateTime LockStartTime
        {
            get { return _LockStartTime; }
            set { if (OnPropertyChanging(__.LockStartTime, value)) { _LockStartTime = value; OnPropertyChanged(__.LockStartTime); } }
        }

        private DateTime _LockEndTime;
        /// <summary>锁定结束时间</summary>
        [DisplayName("锁定结束时间")]
        [Description("锁定结束时间")]
        [DataObjectField(false, false, true, 3)]
        [BindColumn(28, "LockEndTime", "锁定结束时间", null, "datetime", 3, 0, false)]
        public virtual DateTime LockEndTime
        {
            get { return _LockEndTime; }
            set { if (OnPropertyChanging(__.LockEndTime, value)) { _LockEndTime = value; OnPropertyChanged(__.LockEndTime); } }
        }

        private DateTime _RegisterTime;
        /// <summary>注册时间</summary>
        [DisplayName("注册时间")]
        [Description("注册时间")]
        [DataObjectField(false, false, true, 3)]
        [BindColumn(29, "RegisterTime", "注册时间", null, "datetime", 3, 0, false)]
        public virtual DateTime RegisterTime
        {
            get { return _RegisterTime; }
            set { if (OnPropertyChanging(__.RegisterTime, value)) { _RegisterTime = value; OnPropertyChanged(__.RegisterTime); } }
        }

        private Int32 _CreateUserID;
        /// <summary>创建人</summary>
        [DisplayName("创建人")]
        [Description("创建人")]
        [DataObjectField(false, false, true, 10)]
        [BindColumn(30, "CreateUserID", "创建人", null, "int", 10, 0, false)]
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
        [BindColumn(31, "CreateDate", "创建日期", null, "datetime", 3, 0, false)]
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
        [BindColumn(32, "UpdateUserID", "修改人", null, "int", 10, 0, false)]
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
        [BindColumn(33, "UpdateDate", "修改日期", null, "datetime", 3, 0, false)]
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
                    case __.Password : return _Password;
                    case __.Salt : return _Salt;
                    case __.SecurityLevel : return _SecurityLevel;
                    case __.DisplayName : return _DisplayName;
                    case __.RoleIDs : return _RoleIDs;
                    case __.HeadIcon : return _HeadIcon;
                    case __.Sex : return _Sex;
                    case __.Mail : return _Mail;
                    case __.Phone : return _Phone;
                    case __.WeChat : return _WeChat;
                    case __.Remark : return _Remark;
                    case __.Sort : return _Sort;
                    case __.Code : return _Code;
                    case __.Question : return _Question;
                    case __.Answer : return _Answer;
                    case __.Logins : return _Logins;
                    case __.LastLogin : return _LastLogin;
                    case __.LastLoginIP : return _LastLoginIP;
                    case __.IsAdmin : return _IsAdmin;
                    case __.Enable : return _Enable;
                    case __.IsMulti : return _IsMulti;
                    case __.Profile : return _Profile;
                    case __.StartTime : return _StartTime;
                    case __.EndTime : return _EndTime;
                    case __.LockStartTime : return _LockStartTime;
                    case __.LockEndTime : return _LockEndTime;
                    case __.RegisterTime : return _RegisterTime;
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
                    case __.Password : _Password = Convert.ToString(value); break;
                    case __.Salt : _Salt = Convert.ToString(value); break;
                    case __.SecurityLevel : _SecurityLevel = Convert.ToInt32(value); break;
                    case __.DisplayName : _DisplayName = Convert.ToString(value); break;
                    case __.RoleIDs : _RoleIDs = Convert.ToString(value); break;
                    case __.HeadIcon : _HeadIcon = Convert.ToString(value); break;
                    case __.Sex : _Sex = Convert.ToInt32(value); break;
                    case __.Mail : _Mail = Convert.ToString(value); break;
                    case __.Phone : _Phone = Convert.ToString(value); break;
                    case __.WeChat : _WeChat = Convert.ToString(value); break;
                    case __.Remark : _Remark = Convert.ToString(value); break;
                    case __.Sort : _Sort = Convert.ToInt32(value); break;
                    case __.Code : _Code = Convert.ToString(value); break;
                    case __.Question : _Question = Convert.ToString(value); break;
                    case __.Answer : _Answer = Convert.ToString(value); break;
                    case __.Logins : _Logins = Convert.ToInt32(value); break;
                    case __.LastLogin : _LastLogin = Convert.ToDateTime(value); break;
                    case __.LastLoginIP : _LastLoginIP = Convert.ToString(value); break;
                    case __.IsAdmin : _IsAdmin = Convert.ToBoolean(value); break;
                    case __.Enable : _Enable = Convert.ToBoolean(value); break;
                    case __.IsMulti : _IsMulti = Convert.ToBoolean(value); break;
                    case __.Profile : _Profile = Convert.ToString(value); break;
                    case __.StartTime : _StartTime = Convert.ToDateTime(value); break;
                    case __.EndTime : _EndTime = Convert.ToDateTime(value); break;
                    case __.LockStartTime : _LockStartTime = Convert.ToDateTime(value); break;
                    case __.LockEndTime : _LockEndTime = Convert.ToDateTime(value); break;
                    case __.RegisterTime : _RegisterTime = Convert.ToDateTime(value); break;
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
        /// <summary>取得管理员字段信息的快捷方式</summary>
        public partial class _
        {
            ///<summary>编号</summary>
            public static readonly Field ID = FindByName(__.ID);

            ///<summary>名称。登录用户名</summary>
            public static readonly Field Name = FindByName(__.Name);

            ///<summary>密码</summary>
            public static readonly Field Password = FindByName(__.Password);

            ///<summary>加密密钥</summary>
            public static readonly Field Salt = FindByName(__.Salt);

            ///<summary>安全级别</summary>
            public static readonly Field SecurityLevel = FindByName(__.SecurityLevel);

            ///<summary>显示名。昵称、中文名等</summary>
            public static readonly Field DisplayName = FindByName(__.DisplayName);

            ///<summary>以逗号分隔的角色ID串，主要用于编辑时与前端传值比较</summary>
            public static readonly Field RoleIDs = FindByName(__.RoleIDs);

            ///<summary>头像</summary>
            public static readonly Field HeadIcon = FindByName(__.HeadIcon);

            ///<summary>性别。未知、男、女</summary>
            public static readonly Field Sex = FindByName(__.Sex);

            ///<summary>邮件</summary>
            public static readonly Field Mail = FindByName(__.Mail);

            ///<summary>电话</summary>
            public static readonly Field Phone = FindByName(__.Phone);

            ///<summary>微信</summary>
            public static readonly Field WeChat = FindByName(__.WeChat);

            ///<summary>描述</summary>
            public static readonly Field Remark = FindByName(__.Remark);

            ///<summary>排序</summary>
            public static readonly Field Sort = FindByName(__.Sort);

            ///<summary>代码。身份证、员工编号等</summary>
            public static readonly Field Code = FindByName(__.Code);

            ///<summary>问题</summary>
            public static readonly Field Question = FindByName(__.Question);

            ///<summary>答案</summary>
            public static readonly Field Answer = FindByName(__.Answer);

            ///<summary>登录次数</summary>
            public static readonly Field Logins = FindByName(__.Logins);

            ///<summary>最后登录</summary>
            public static readonly Field LastLogin = FindByName(__.LastLogin);

            ///<summary>最后登录IP</summary>
            public static readonly Field LastLoginIP = FindByName(__.LastLoginIP);

            ///<summary>是否是超级管理员</summary>
            public static readonly Field IsAdmin = FindByName(__.IsAdmin);

            ///<summary>是否启用</summary>
            public static readonly Field Enable = FindByName(__.Enable);

            ///<summary>是否允许多出登陆</summary>
            public static readonly Field IsMulti = FindByName(__.IsMulti);

            ///<summary>配置信息</summary>
            public static readonly Field Profile = FindByName(__.Profile);

            ///<summary>允许登陆开始时间</summary>
            public static readonly Field StartTime = FindByName(__.StartTime);

            ///<summary>允许登陆结束时间</summary>
            public static readonly Field EndTime = FindByName(__.EndTime);

            ///<summary>锁定开始时间</summary>
            public static readonly Field LockStartTime = FindByName(__.LockStartTime);

            ///<summary>锁定结束时间</summary>
            public static readonly Field LockEndTime = FindByName(__.LockEndTime);

            ///<summary>注册时间</summary>
            public static readonly Field RegisterTime = FindByName(__.RegisterTime);

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

        /// <summary>取得管理员字段名称的快捷方式</summary>
        partial class __
        {
            ///<summary>编号</summary>
            public const String ID = "ID";

            ///<summary>名称。登录用户名</summary>
            public const String Name = "Name";

            ///<summary>密码</summary>
            public const String Password = "Password";

            ///<summary>加密密钥</summary>
            public const String Salt = "Salt";

            ///<summary>安全级别</summary>
            public const String SecurityLevel = "SecurityLevel";

            ///<summary>显示名。昵称、中文名等</summary>
            public const String DisplayName = "DisplayName";

            ///<summary>以逗号分隔的角色ID串，主要用于编辑时与前端传值比较</summary>
            public const String RoleIDs = "RoleIDs";

            ///<summary>头像</summary>
            public const String HeadIcon = "HeadIcon";

            ///<summary>性别。未知、男、女</summary>
            public const String Sex = "Sex";

            ///<summary>邮件</summary>
            public const String Mail = "Mail";

            ///<summary>电话</summary>
            public const String Phone = "Phone";

            ///<summary>微信</summary>
            public const String WeChat = "WeChat";

            ///<summary>描述</summary>
            public const String Remark = "Remark";

            ///<summary>排序</summary>
            public const String Sort = "Sort";

            ///<summary>代码。身份证、员工编号等</summary>
            public const String Code = "Code";

            ///<summary>问题</summary>
            public const String Question = "Question";

            ///<summary>答案</summary>
            public const String Answer = "Answer";

            ///<summary>登录次数</summary>
            public const String Logins = "Logins";

            ///<summary>最后登录</summary>
            public const String LastLogin = "LastLogin";

            ///<summary>最后登录IP</summary>
            public const String LastLoginIP = "LastLoginIP";

            ///<summary>是否是超级管理员</summary>
            public const String IsAdmin = "IsAdmin";

            ///<summary>是否启用</summary>
            public const String Enable = "Enable";

            ///<summary>是否允许多出登陆</summary>
            public const String IsMulti = "IsMulti";

            ///<summary>配置信息</summary>
            public const String Profile = "Profile";

            ///<summary>允许登陆开始时间</summary>
            public const String StartTime = "StartTime";

            ///<summary>允许登陆结束时间</summary>
            public const String EndTime = "EndTime";

            ///<summary>锁定开始时间</summary>
            public const String LockStartTime = "LockStartTime";

            ///<summary>锁定结束时间</summary>
            public const String LockEndTime = "LockEndTime";

            ///<summary>注册时间</summary>
            public const String RegisterTime = "RegisterTime";

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

    /// <summary>管理员接口</summary>
    public partial interface IAdmin
    {
        #region 属性
        /// <summary>编号</summary>
        Int32 ID { get; set; }

        /// <summary>名称。登录用户名</summary>
        String Name { get; set; }

        /// <summary>密码</summary>
        String Password { get; set; }

        /// <summary>加密密钥</summary>
        String Salt { get; set; }

        /// <summary>安全级别</summary>
        Int32 SecurityLevel { get; set; }

        /// <summary>显示名。昵称、中文名等</summary>
        String DisplayName { get; set; }

        /// <summary>以逗号分隔的角色ID串，主要用于编辑时与前端传值比较</summary>
        String RoleIDs { get; set; }

        /// <summary>头像</summary>
        String HeadIcon { get; set; }

        /// <summary>性别。未知、男、女</summary>
        Int32 Sex { get; set; }

        /// <summary>邮件</summary>
        String Mail { get; set; }

        /// <summary>电话</summary>
        String Phone { get; set; }

        /// <summary>微信</summary>
        String WeChat { get; set; }

        /// <summary>描述</summary>
        String Remark { get; set; }

        /// <summary>排序</summary>
        Int32 Sort { get; set; }

        /// <summary>代码。身份证、员工编号等</summary>
        String Code { get; set; }

        /// <summary>问题</summary>
        String Question { get; set; }

        /// <summary>答案</summary>
        String Answer { get; set; }

        /// <summary>登录次数</summary>
        Int32 Logins { get; set; }

        /// <summary>最后登录</summary>
        DateTime LastLogin { get; set; }

        /// <summary>最后登录IP</summary>
        String LastLoginIP { get; set; }

        /// <summary>是否是超级管理员</summary>
        Boolean IsAdmin { get; set; }

        /// <summary>是否启用</summary>
        Boolean Enable { get; set; }

        /// <summary>是否允许多出登陆</summary>
        Boolean IsMulti { get; set; }

        /// <summary>配置信息</summary>
        String Profile { get; set; }

        /// <summary>允许登陆开始时间</summary>
        DateTime StartTime { get; set; }

        /// <summary>允许登陆结束时间</summary>
        DateTime EndTime { get; set; }

        /// <summary>锁定开始时间</summary>
        DateTime LockStartTime { get; set; }

        /// <summary>锁定结束时间</summary>
        DateTime LockEndTime { get; set; }

        /// <summary>注册时间</summary>
        DateTime RegisterTime { get; set; }

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