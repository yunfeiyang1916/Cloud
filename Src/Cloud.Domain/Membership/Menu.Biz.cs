using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Xml.Serialization;
using NewLife.Log;
using NewLife.Web;
using NewLife.Data;
using XCode;
using XCode.Configuration;
using XCode.Membership;
using System.Web.Script.Serialization;

namespace Cloud.Domain
{
    /// <summary>菜单</summary>
    public partial class Menu : EntityTreeExtend<Menu>
    {
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

            if (isNew && !Dirtys[__.CreateUserID] && ManageProvider.Provider.Current != null) CreateUserID = (Int32)ManageProvider.Provider.Current.ID;
            if (isNew && !Dirtys[__.CreateDate]) CreateDate = DateTime.Now;
            if (!Dirtys[__.UpdateUserID] && ManageProvider.Provider.Current != null) UpdateUserID = (Int32)ManageProvider.Provider.Current.ID;
            if (!Dirtys[__.UpdateDate]) UpdateDate = DateTime.Now;
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
            if (XTrace.Debug) XTrace.WriteLine("开始初始化{0}[{1}]数据……", typeof(Menu).Name, Meta.Table.DataTable.DisplayName);
            //初始化数据
            Object[][] ss = new Object[][] {
                //顺序依次是 Name ParentID Url Target Icon Sort
                new Object[] { "系统管理",0,null, "expand", "fa-gears", 9999 },
                new Object[] { "用户管理",1, "/Admin/Admin", "iframe", "fa-user", 9998 },
                new Object[] { "角色管理",1, "/Admin/Role", "iframe", "fa-group", 9997 },
                new Object[] { "系统菜单",1, "/Admin/Menu", "iframe", "fa-sitemap", 9996 },
                new Object[] { "按钮管理",1, "/Admin/Button", "iframe", "fa-th-list", 9995 },
                new Object[] { "数据权限",1, "/Admin/DataPermission", "iframe", "fa-lock", 9994 },
                new Object[] { "图标管理",1, "/Admin/Icon", "iframe", "fa-lock", 9993 },
                new Object[] { "服务器监控",1, "/Admin/ServerMonitoring", "iframe", "fa-video-camera", 9992 },
                new Object[] { "操作日志",1, "/Admin/Log", "iframe", "fa-exclamation", 9991 },
                new Object[] { "测试示例",0, null, "expand", "fa-tags", 9990 },
                new Object[] { "内容测试",10, "/Admin/ContentTest", "iframe", "fa-file-text-o", 9989 }
            };
            foreach (Object[] objs in ss)
            {
                var entity = new Menu();
                entity.Name = objs[0].ToString();
                entity.ParentID = objs[1].ToInt();
                entity.Url = objs[2] + "";
                entity.Target = objs[3].ToString();
                entity.Icon = objs[4].ToString();
                entity.Sort = objs[5].ToInt();
                entity.Visible = true;
                entity.CreateUserID = 1;
                entity.CreateDate = DateTime.Now;
                entity.UpdateUserID = 1;
                entity.UpdateDate = DateTime.Now;
                entity.Insert();
            }

            if (XTrace.Debug) XTrace.WriteLine("完成初始化{0}[{1}]数据！", typeof(Menu).Name, Meta.Table.DataTable.DisplayName);
        }

        /// <summary>已重载。删除关联数据</summary>
        /// <returns></returns>
        protected override int OnDelete()
        {
            if (MenuButtons != null) MenuButtons.Delete();
            if (RoleMenus != null) RoleMenus.Delete();
            if (RoleMenuButtons != null) RoleMenuButtons.Delete();

            return base.OnDelete();
        }

        ///// <summary>已重载。基类先调用Valid(true)验证数据，然后在事务保护内调用OnInsert</summary>
        ///// <returns></returns>
        //public override Int32 Insert()
        //{
        //    Int32 result = base.Insert();
        //    if (!String.IsNullOrEmpty(ButtonIDs))
        //    {
        //        Int32[] ss = ButtonIDs.SplitAsInt(",");
        //        if (ss != null && ss.Length > 0)
        //        {
        //            EntityList<MenuButton> list = new EntityList<MenuButton>();
        //            foreach (Int32 buttonID in ss)
        //            {
        //                MenuButton m = new MenuButton();
        //                m.MenuID = ID;
        //                m.ButtonID = buttonID;
        //                list.Add(m);
        //            }
        //            throw new Exception("插入异常！");
        //            list.Insert(true);
        //        }
        //    }
        //    return result;
        //}

        /// <summary>已重载。在事务保护范围内处理业务，位于Valid之后</summary>
        /// <returns></returns>
        protected override Int32 OnInsert()
        {
            Int32 result = base.OnInsert();
            if (!String.IsNullOrEmpty(ButtonIDs))
            {
                Int32[] ss = ButtonIDs.SplitAsInt(",");
                if (ss != null && ss.Length > 0)
                {
                    EntityList<MenuButton> list = new EntityList<MenuButton>();
                    foreach (Int32 buttonID in ss)
                    {
                        MenuButton m = new MenuButton();
                        m.MenuID = ID;
                        m.ButtonID = buttonID;
                        list.Add(m);
                    }
                    list.Insert(true);
                }
            }
            return result;
        }
        /// <summary>已重载。在事务保护范围内处理业务，位于Valid之后</summary>
        /// <returns></returns>
        protected override int OnUpdate()
        {
            Int32 result = base.OnUpdate();
            String haveButtonIDs = "";
            if (MenuButtons != null && MenuButtons.Count > 0)
            {
                foreach (var item in MenuButtons)
                {
                    haveButtonIDs += item.ButtonID + ",";
                }
                //去除最后的逗号
                haveButtonIDs = haveButtonIDs.TrimEnd(',');
            }
            //如果不相等说明按钮被修改了
            if (haveButtonIDs != ButtonIDs)
            {
                //先删除后添加
                if (MenuButtons != null && MenuButtons.Count > 0) MenuButtons.Delete();
                if (!String.IsNullOrEmpty(ButtonIDs))
                {
                    Int32[] ss = ButtonIDs.SplitAsInt(",");
                    if (ss != null && ss.Length > 0)
                    {
                        EntityList<MenuButton> list = new EntityList<MenuButton>();
                        foreach (Int32 buttonID in ss)
                        {
                            var m = new MenuButton();
                            m.ButtonID = buttonID;
                            m.MenuID = ID;
                            list.Add(m);
                        }
                        list.Insert(true);
                    }
                }
                //如果只是更改了按钮菜单根不会重新设置，需要手动设置为null，否则扩展属性的缓存不会更新
                Menu.Root = null;
                //这里还需要清空菜单的缓存，否则从缓存中重新读取数据时扩展属性还是旧的
                Menu.Meta.Cache.Clear(String.Format("菜单{0}更新了菜单按钮", Name));
                //Menu.Meta.Cache.Entities.Clear();
                //MenuButton.Meta.Cache.Entities.Clear();
                //Menu.Meta.Cache.Clear(String.Format("菜单{0}更新了菜单按钮",Name));
            }
            return result;
        }

        #endregion

        #region 扩展属性

        private String _ButtonIDs;
        /// <summary>该菜单所拥有的按钮ID串，前端传输过来的</summary>
        public String ButtonIDs { get { return _ButtonIDs; } set { _ButtonIDs = value; } }

        [NonSerialized]
        private EntityList<MenuButton> _MenuButtons;
        /// <summary>该菜单所拥有的菜单与按钮映射表集合</summary>
        [XmlIgnore]
        public EntityList<MenuButton> MenuButtons
        {
            get
            {
                if (_MenuButtons == null && ID > 0 && !Dirtys.ContainsKey("MenuButtons"))
                {
                    _MenuButtons = MenuButton.FindAllByMenuID(ID);
                    Dirtys["MenuButtons"] = true;
                }
                return _MenuButtons;
            }
            set { _MenuButtons = value; }
        }

        [NonSerialized]
        private EntityList<RoleMenu> _RoleMenus;
        /// <summary>该菜单所拥有的角色与菜单映射表集合</summary>
        [XmlIgnore, ScriptIgnore]
        public EntityList<RoleMenu> RoleMenus
        {
            get
            {
                if (_RoleMenus == null && ID > 0 && !Dirtys.ContainsKey("RoleMenus"))
                {
                    _RoleMenus = RoleMenu.FindAllByMenuID(ID);
                    Dirtys["RoleMenus"] = true;
                }
                return _RoleMenus;
            }
            set { _RoleMenus = value; }
        }

        [NonSerialized]
        private EntityList<RoleMenuButton> _RoleMenuButtons;
        /// <summary>该菜单所拥有的角色与菜单按钮映射表集合</summary>
        [XmlIgnore, ScriptIgnore]
        public EntityList<RoleMenuButton> RoleMenuButtons
        {
            get
            {
                if (_RoleMenuButtons == null && ID > 0 && !Dirtys.ContainsKey("RoleMenuButtons"))
                {
                    _RoleMenuButtons = RoleMenuButton.FindAllByMenuID(ID);
                    Dirtys["RoleMenuButtons"] = true;
                }
                return _RoleMenuButtons;
            }
            set { _RoleMenuButtons = value; }
        }

        #endregion

        #region 扩展查询

        /// <summary>根据名称、父编号查找</summary>
        /// <param name="name">名称</param>
        /// <param name="parentid">父编号</param>
        /// <returns></returns>
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public static Menu FindByNameAndParentID(String name, Int32 parentid)
        {
            if (Meta.Count >= 1000)
                return Find(new String[] { __.Name, __.ParentID }, new Object[] { name, parentid });
            else // 实体缓存
                return Meta.Cache.Entities.Find(e => e.Name == name && e.ParentID == parentid);
        }

        /// <summary>根据名称查找</summary>
        /// <param name="name">名称</param>
        /// <returns></returns>
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public static EntityList<Menu> FindAllByName(String name)
        {
            if (Meta.Count >= 1000)
                return FindAll(__.Name, name);
            else // 实体缓存
                return Meta.Cache.Entities.FindAll(__.Name, name);
        }

        /// <summary>根据编号查找</summary>
        /// <param name="id">编号</param>
        /// <returns></returns>
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public static Menu FindByID(Int32 id)
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
        public static EntityList<Menu> Search(Int32 userid, DateTime start, DateTime end, String key, PageParameter param)
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



        #endregion
    }
}