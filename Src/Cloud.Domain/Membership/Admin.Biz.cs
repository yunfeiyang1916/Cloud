using Cloud.Common;
using NewLife.Data;
using NewLife.Web;
using System;
using System.ComponentModel;
using System.Web;
using System.Xml.Serialization;
using XCode;
using XCode.Membership;
using Cloud.Security;
using System.Web.Script.Serialization;
using System.Data.Common;
using NewLife.Log;
using System.Collections.Generic;
using System.Linq;

namespace Cloud.Domain
{
    /// <summary>管理员</summary>
    /// <remarks>继承日志实体基类，这样在插入、更新、删除时都自动写日志到数据库</remarks>
    public partial class Admin : LogEntity<Admin>, IUser, IManageUser
    {
        #region IUser成员

        /// <summary>友好名字</summary>
        public virtual String FriendName { get { return String.IsNullOrEmpty(DisplayName) ? Name : DisplayName; } }

        /// <summary>性别</summary>
        [DisplayName("性别")]
        [Map(__.Sex)]
        public SexKinds SexKind { get { return (SexKinds)Sex; } set { Sex = (Int32)value; } }

        /// <summary>物理地址</summary>
        [DisplayName("物理地址")]
        //[BindRelation(__.LastLoginIP)]
        public String LastLoginAddress { get { return LastLoginIP.IPToAddress(); } }

        /// <summary>角色</summary>
        [XmlIgnore, ScriptIgnore]
        XCode.Membership.IRole IUser.Role
        {
            get
            {
                return null; //throw new NotImplementedException();
            }
        }

        /// <summary>角色ID</summary>
        [XmlIgnore, ScriptIgnore]
        public int RoleID
        {
            get
            {
                return 0;
            }

            set
            {
                //throw new NotImplementedException();
            }
        }
        /// <summary>角色名</summary>
        [XmlIgnore, ScriptIgnore]
        public string RoleName
        {
            get
            {
                return null;
            }
        }

        #endregion

        #region IManageUser 成员
        /// <summary>编号</summary>
        [XmlIgnore, ScriptIgnore]
        object IManageUser.Uid { get { return ID; } }


        /// <summary>是否管理员</summary>
        [XmlIgnore, ScriptIgnore]
        Boolean IManageUser.IsAdmin { get { return IsAdmin; } set { } }
        #endregion

        #region 对象操作
        /// <summary>验证数据，通过抛出异常的方式提示验证失败。</summary>
        /// <param name="isNew"></param>
        public override void Valid(Boolean isNew)
        {
            // 如果没有脏数据，则不需要进行任何处理
            if (!HasDirty) return;

            // 这里验证参数范围，建议抛出参数异常，指定参数名，前端用户界面可以捕获参数异常并聚焦到对应的参数输入框
            //if (String.IsNullOrEmpty(Name)) throw new ArgumentNullException(_.Name, _.Name.DisplayName + "无效！");
            //if (!isNew && ID < 1) throw new ArgumentOutOfRangeException(_.ID, _.ID.DisplayName + "必须大于0！");

            // 建议先调用基类方法，基类方法会对唯一索引的数据进行验证
            base.Valid(isNew);

            // 在新插入数据或者修改了指定字段时进行唯一性验证，CheckExist内部抛出参数异常
            //if (isNew || Dirtys[__.Name]) CheckExist(__.Name);

            //当前登录用户id
            var userID = ManageProvider.Provider.Current != null ? ManageProvider.Provider.Current.ID : 0;
            //是不是添加
            if (isNew)
            {
                CreateUserID = UpdateUserID = userID;
                CreateDate = UpdateDate = RegisterTime = LastLogin = DateTime.Now;
            }
            else
            {
                if (!Dirtys[__.UpdateUserID] && ManageProvider.Provider.Current != null) UpdateUserID = userID;
                if (!Dirtys[__.UpdateDate]) UpdateDate = DateTime.Now;
            }
            if (!Dirtys[__.LastLoginIP]) LastLoginIP = WebHelper.UserHost;
            //如果修改了密码，则需要加密
            if (Dirtys[__.Password])
            {
                Salt = RandomHelper.GetDateTimeCode().MD5_16().ToLower();
                Password = DESEncrypt.Encrypt(Password, Salt).MD5().ToLower();
            }
        }

        /// <summary>首次连接数据库时初始化数据，仅用于实体类重载，用户不应该调用该方法</summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected override void InitData()
        {
            base.InitData();

            // InitData一般用于当数据表没有数据时添加一些默认数据，该实体类的任何第一次数据库操作都会触发该方法，默认异步调用
            // Meta.Count是快速取得表记录数
            if (Meta.Count > 0) return;

            // 需要注意的是，如果该方法调用了其它实体类的首次数据库操作，目标实体类的数据初始化将会在同一个线程完成
            if (XTrace.Debug) XTrace.WriteLine("开始初始化{0}[{1}]数据……", typeof(Admin).Name, Meta.Table.DataTable.DisplayName);

            var entity = new Admin();
            entity.Name = "admin";
            entity.DisplayName = "管理员";
            entity.IsAdmin = false;
            entity.RoleIDs = "1";
            entity.Sex = 0;
            entity.Sort = 9999;
            entity.Logins = 0;
            entity.LastLogin = DateTime.Now;
            entity.Enable = true;
            entity.IsMulti = true;
            entity.StartTime = DateTime.Now;
            entity.RegisterTime = DateTime.Now;
            entity.CreateDate = DateTime.Now;
            entity.UpdateDate = DateTime.Now;
            entity.Insert();

            if (XTrace.Debug) XTrace.WriteLine("完成初始化{0}[{1}]数据！", typeof(Admin).Name, Meta.Table.DataTable.DisplayName);
        }
        ///// <summary>已重载。基类先调用Valid(true)验证数据，然后在事务保护内调用OnInsert</summary>
        ///// <returns></returns>
        //public override Int32 Insert()
        //{
        //    return base.Insert();
        //}

        /// <summary>已重载。在事务保护范围内处理业务，位于Valid之后</summary>
        /// <returns></returns>
        protected override Int32 OnInsert()
        {
            var result = base.OnInsert();
            InsertAdminRole();
            return result;
        }
        /// <summary>已重载。在事务保护范围内处理业务，位于Valid之后</summary>
        /// <returns></returns>
        protected override int OnUpdate()
        {
            //是否修改了角色ID串
            if (Dirtys[__.RoleIDs])
            {
                //先删除关联
                if (AdminRoles != null) AdminRoles.Delete();
                //再插入关联
                InsertAdminRole();
            }
            return base.OnUpdate();
        }

        /// <summary>插入管理员与角色表映射</summary>
        protected Int32 InsertAdminRole()
        {
            var result = 0;
            if (!String.IsNullOrEmpty(RoleIDs))
            {
                Int32[] ss = RoleIDs.SplitAsInt(",");
                if (ss != null && ss.Length > 0)
                {
                    EntityList<AdminRole> list = new EntityList<AdminRole>();
                    foreach (Int32 item in ss)
                    {
                        AdminRole entity = new AdminRole();
                        entity.AdminID = ID;
                        entity.RoleID = item;
                        list.Add(entity);
                    }
                    result += list.Insert(true);
                }
            }
            return result;
        }

        #endregion

        #region 扩展属性

        private String _RawPassword;
        /// <summary>登陆输入的原始密码(经md5加密后的)，主要用途是将密码存储与cookie中</summary>
        [XmlIgnore, ScriptIgnore]
        public String RawPassword { get { return _RawPassword; } set { _RawPassword = value; } }

        /// <summary>当前登陆用户</summary>
        public static Admin Current
        {
            get
            {
                if (HttpContext.Current == null || HttpContext.Current.Session == null)
                {
                    return null;
                }
                var session = HttpContext.Current.Session;
                var key = Consts.SessionAdmin;
                //先从session中获取
                var admin = session[key] as Admin;
                if (admin != null)
                {
                    return admin;
                }
                //从cookie中获取
                //设置一个陷阱，避免重复计算cookie
                if (session[key] != null) return null;
                admin = GetCookie(Consts.CookieAdmin);
                if (admin != null)
                {
                    session[key] = admin;
                }
                else
                {
                    //设置值为1，表示已经从cookie计算过了
                    session[key] = "1";
                }
                return admin;
            }
            set
            {
                var session = HttpContext.Current.Session;
                //特殊处理注销
                if (value == null)
                {
                    var entity = Current;
                    if (entity != null) WriteLog("注销", entity.Name);
                    //修改session
                    if (session != null)
                    {
                        session.Clear();
                    }
                }
                else
                {
                    //修改session
                    if (session != null)
                    {
                        session[Consts.SessionAdmin] = value;
                        //存储当前用户的权限信息
                        session[Consts.SessionPermissionManager] = PermissionManager.GetInstance();
                    }
                }

                //在写入cookie
                SetCookie(Consts.CookieAdmin, value);
            }
        }

        [NonSerialized]
        private EntityList<AdminRole> _AdminRoles;
        /// <summary>该管理员所拥有的管理员与角色映射表集合</summary>
        [XmlIgnore, ScriptIgnore]
        public EntityList<AdminRole> AdminRoles
        {
            get
            {
                if (_AdminRoles == null && ID > 0 && !Dirtys.ContainsKey("AdminRoles"))
                {
                    _AdminRoles = AdminRole.FindAllByAdminID(ID);
                    Dirtys["AdminRoles"] = true;
                }
                return _AdminRoles;
            }
            set { _AdminRoles = value; }
        }

        #endregion

        #region 扩展查询

        /// <summary>根据名称。登录用户名查找</summary>
        /// <param name="name">名称。登录用户名</param>
        /// <returns></returns>
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public static Admin FindByName(String name)
        {
            if (Meta.Count >= 1000)
                return Find(__.Name, name);
            else // 实体缓存
                return Meta.Cache.Entities.Find(__.Name, name);
            // 单对象缓存
            //return Meta.SingleCache[name];
        }

        /// <summary>根据编号查找</summary>
        /// <param name="id">编号</param>
        /// <returns></returns>
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public static Admin FindByID(Int32 id)
        {
            if (Meta.Count >= 1000)
                return Find(__.ID, id);
            else // 实体缓存
                return Meta.Cache.Entities.Find(__.ID, id);
            // 单对象缓存
            //return Meta.SingleCache[id];
        }

        #endregion

        #region 高级查询
        // 以下为自定义高级查询的例子

        /// <summary>查询满足条件的记录集，分页、排序</summary>
        /// <param name="userid">用户编号</param>
        /// <param name="start">开始时间</param>
        /// <param name="end">结束时间</param>
        /// <param name="key">关键字</param>
        /// <param name="param">分页排序参数，同时返回满足条件的总记录数</param>
        /// <returns>实体集</returns>
        public static EntityList<Admin> Search(Int32 userid, DateTime start, DateTime end, String key, PageParameter param)
        {
            // WhereExpression重载&和|运算符，作为And和Or的替代
            // SearchWhereByKeys系列方法用于构建针对字符串字段的模糊搜索，第二个参数可指定要搜索的字段
            var exp = SearchWhereByKeys(key, null, null);

            // 以下仅为演示，Field（继承自FieldItem）重载了==、!=、>、<、>=、<=等运算符
            //if (userid > 0) exp &= _.OperatorID == userid;
            //if (isSign != null) exp &= _.IsSign == isSign.Value;
            //exp &= _.OccurTime.Between(start, end); // 大于等于start，小于end，当start/end大于MinValue时有效

            return FindAll(exp, param);
        }
        #endregion

        #region 扩展操作
        #endregion

        #region 业务
        /// <summary>登陆</summary>
        /// <param name="userName">用户名</param>
        /// <param name="password">密码</param>
        /// <param name="rememberme">是否记住密码</param>
        /// <returns></returns>
        public static Admin Login(String userName, String password, Boolean rememberme = false)
        {
            if (String.IsNullOrEmpty(userName))
            {
                throw new ArgumentNullException("userName", "用户名不能为空！");
            }
            if (String.IsNullOrEmpty(password))
            {
                throw new ArgumentNullException("password", "密码不能为空！");
            }
            var admin = Find(__.Name, userName);
            if (admin == null)
            {
                throw new EntityException("账户{0}不存在！", userName);
            }

            if (!admin.Enable)
            {
                throw new EntityException("账户{0}被禁用！", userName);
            }
            //赋值原始密码
            admin.RawPassword = password;
            //如果数据库的密码为空，则设置输入的密码为默认密码
            if (String.IsNullOrEmpty(admin.Password))
            {
                //加密在Valid方法中
                //admin.Salt = RandomHelper.GetDateTimeCode().MD5_16().ToLower();
                //admin.Password = DESEncrypt.Encrypt(password, admin.Salt).MD5().ToLower();
                admin.Password =password;
                WriteLog("初次登陆", userName);
            }
            else
            {
                admin.Salt = !String.IsNullOrEmpty(admin.Salt) ? admin.Salt : RandomHelper.GetDateTimeCode().MD5_16().ToLower();
                //加密密码
                String encryptPassword = DESEncrypt.Encrypt(password, admin.Salt).MD5().ToLower();
                if (encryptPassword != admin.Password)
                {
                    throw new EntityException("密码不正确！");
                }
            }
            //这个静态属性并没有静态字段，赋值只是将登陆信息存储到session与cookie中
            Current = admin;
            //保存登陆信息
            admin.SaveLoginInfo();
            WriteLog("登陆", userName);
            //是否记住密码
            if (rememberme && admin != null)
            {
                var cookie = HttpContext.Current.Response.Cookies[Consts.CookieAdmin];
                //在上面的赋值中是否将管理员信息写入cookie
                if (cookie != null)
                {
                    cookie.Expires = DateTime.Now.AddYears(1);
                }
            }
            return admin;
        }
        /// <summary>保存登陆信息</summary>
        /// <returns></returns>
        protected virtual Int32 SaveLoginInfo()
        {
            Logins++;
            LastLogin = DateTime.Now;
            var ip = WebHelper.UserHost;
            if (!String.IsNullOrEmpty(ip)) LastLoginIP = ip;

            return Update();
        }
        /// <summary>注销</summary>
        public void Logout()
        {
            Current = null;
        }
        /// <summary>从cookie中读取管理员信息</summary>
        /// <param name="key"></param>
        /// <returns></returns>
        static Admin GetCookie(String key)
        {
            var cookie = HttpContext.Current.Request.Cookies[key];
            if (cookie == null) return null;
            String userName = cookie["u"];
            String password = cookie["p"];
            if (String.IsNullOrEmpty(userName) || String.IsNullOrEmpty(password)) return null;
            try
            {
                var admin = Login(userName, password);
                WriteLog("自动登陆", userName);
                return admin;
            }
            catch (DbException ex)
            {
                XTrace.WriteLine("{0}登录失败！{1}", userName, ex);
                return null;
            }
            catch (Exception ex)
            {
                XTrace.WriteLine("自动登陆", userName + "登陆失败！" + ex.Message);
                //这里有时候会陷入死循环，WriteLog会访问ManageProvider.Provider.Current，如果Cookie中的值无效，异常会执行到这，然后再去循环访问
                //WriteLog("自动登陆", userName + "登陆失败！" + ex.Message);
                return null;
            }
        }

        /// <summary>将管理员信息保存到cookie中，管理员信息为null，则表示注销</summary>
        /// <param name="key"></param>
        /// <param name="admin"></param>
        static void SetCookie(String key, Admin admin)
        {
            var context = HttpContext.Current;
            var response = context.Response;
            //请求中的cookie
            var cookie = context.Request.Cookies[key];
            if (admin != null)
            {
                String userName = HttpUtility.UrlEncode(admin.Name);
                String password = admin.RawPassword;
                if (cookie == null || userName != cookie["u"] || password != cookie["p"])
                {
                    // 只有需要写入Cookie时才设置，否则会清空原来的非会话Cookie
                    var resCookie = response.Cookies[key];
                    resCookie["u"] = userName;
                    resCookie["p"] = password;
                }
            }
            else
            {
                //清除管理员cookie信息
                var resCookie = response.Cookies[key];
                resCookie.Value = null;
                resCookie.Expires = DateTime.Now.AddYears(-1);
            }
        }


        #endregion
    }

}