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
    /// <summary>按钮</summary>
    public partial class Button : Entity<Button>
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
            if (XTrace.Debug) XTrace.WriteLine("开始初始化{0}[{1}]数据……", typeof(Button).Name, Meta.Table.DataTable.DisplayName);

            var add = new Button();
            add.Code = "add";
            add.Name = "添加";
            add.Icon = "fa-plus";
            add.Location = 1;
            add.JsEvent = "viewModel.onDataAdding();";
            add.AllowUpdate = true;
            add.AllowDelete = true;
            add.Remark = "添加";
            add.Sort = 9999;
            add.CreateUserID = 1;
            add.CreateDate = DateTime.Now;
            add.UpdateUserID = 1;
            add.UpdateDate = DateTime.Now;
            add.Insert();

            var edit = new Button();
            edit.Code = "edit";
            edit.Name = "编辑";
            edit.Icon = "fa-pencil-square-o";
            edit.Location = 2;
            edit.JsEvent = "viewModel.onDataUpdating(id);";
            edit.AllowUpdate = true;
            edit.AllowDelete = true;
            edit.Remark = "编辑";
            edit.Sort = 9997;
            edit.CreateUserID = 1;
            edit.CreateDate = DateTime.Now;
            edit.UpdateUserID = 1;
            edit.UpdateDate = DateTime.Now;
            edit.Insert();

            var delete = new Button();
            delete.Code = "delete";
            delete.Name = "删除";
            delete.Icon = "fa-trash-o";
            delete.Location = 2;
            delete.JsEvent = "viewModel.onDataDeleting(id);";
            delete.AllowUpdate = true;
            delete.AllowDelete = true;
            delete.Remark = "删除";
            delete.Sort = 9996;
            delete.CreateUserID = 1;
            delete.CreateDate = DateTime.Now;
            delete.UpdateUserID = 1;
            delete.UpdateDate = DateTime.Now;
            delete.Insert();

            var detail = new Button();
            detail.Code = "detail";
            detail.Name = "查看";
            detail.Icon = "fa-search-plus";
            detail.Location = 2;
            detail.JsEvent = "viewModel.onDataDetailing(id);";
            detail.AllowUpdate = true;
            detail.AllowDelete = true;
            detail.Remark = "查看详情";
            detail.Sort = 9998;
            detail.CreateUserID = 1;
            detail.CreateDate = DateTime.Now;
            detail.UpdateUserID = 1;
            detail.UpdateDate = DateTime.Now;
            detail.Insert();

            if (XTrace.Debug) XTrace.WriteLine("完成初始化{0}[{1}]数据！", typeof(Button).Name, Meta.Table.DataTable.DisplayName);
        }

        /// <summary>已重载。删除关联数据</summary>
        /// <returns></returns>
        protected override int OnDelete()
        {
            if (MenuButtons != null) MenuButtons.Delete();

            return base.OnDelete();
        }

        ///// <summary>已重载。基类先调用Valid(true)验证数据，然后在事务保护内调用OnInsert</summary>
        ///// <returns></returns>
        //public override Int32 Insert()
        //{
        //    return base.Insert();
        //}

        ///// <summary>已重载。在事务保护范围内处理业务，位于Valid之后</summary>
        ///// <returns></returns>
        //protected override Int32 OnInsert()
        //{
        //    return base.OnInsert();
        //}

        #endregion

        #region 扩展属性

        private Boolean _Selected;
        /// <summary>是否选中</summary>
        public Boolean Selected { get { return _Selected; } set { _Selected = value; } }
        [NonSerialized]
        private EntityList<MenuButton> _MenuButtons;
        /// <summary>该按钮所拥有的菜单与按钮映射表集合</summary>
        [XmlIgnore, ScriptIgnore]
        public EntityList<MenuButton> MenuButtons
        {
            get
            {
                if (_MenuButtons == null && ID > 0 && !Dirtys.ContainsKey("MenuButtons"))
                {
                    _MenuButtons = MenuButton.FindAllByButtonID(ID);
                    Dirtys["MenuButtons"] = true;
                }
                return _MenuButtons;
            }
            set { _MenuButtons = value; }
        }

        [NonSerialized]
        private EntityList<RoleMenuButton> _RoleMenuButtons;
        /// <summary>该角色所拥有的角色与菜单映射表集合</summary>
        [XmlIgnore, ScriptIgnore]
        public EntityList<RoleMenuButton> RoleMenuButtons
        {
            get
            {
                if (_RoleMenuButtons == null && ID > 0 && !Dirtys.ContainsKey("RoleMenuButtons"))
                {
                    _RoleMenuButtons = RoleMenuButton.FindAllByButtonID(ID);
                    Dirtys["RoleMenuButtons"] = true;
                }
                return _RoleMenuButtons;
            }
            set { _RoleMenuButtons = value; }
        }

        #endregion

        #region 扩展查询

        /// <summary>根据主键ID查找</summary>
        /// <param name="id">主键ID</param>
        /// <returns></returns>
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public static Button FindByID(Int32 id)
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
        public static EntityList<Button> Search(Int32 userid, DateTime start, DateTime end, String key, PageParameter param)
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