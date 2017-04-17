using Cloud.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using XCode;
using XCode.Membership;

namespace Cloud.Domain
{
    /// <summary>权限管理器</summary>
    [Serializable]
    public class PermissionManager
    {
        #region 静态实例
        /// <summary>当前登录用户的权限管理器</summary>
        public static PermissionManager Current
        {
            get
            {
                if (HttpContext.Current == null || HttpContext.Current.Session == null)
                {
                    return null;
                }
                var session = HttpContext.Current.Session;
                var key = Consts.SessionPermissionManager;
                //先从session中获取
                var pm = session[key] as PermissionManager;
                return pm;
            }
        }

        #endregion

        #region 属性

        private List<Permission> _Permissions;
        /// <summary>菜单权限集合</summary>
        public List<Permission> Permissions { get { return _Permissions; } set { _Permissions = value; } }

        private List<DataPermission> _DataPermissions;
        /// <summary>数据权限集合</summary>
        public List<DataPermission> DataPermissions { get { return _DataPermissions; } set { _DataPermissions = value; } }

        #endregion

        #region 方法

        /// <summary>获取权限管理器实例</summary>
        public static PermissionManager GetInstance()
        {
            var user = ManageProvider.User as Admin;
            if (user == null) return null;
            //是否是超级管理员
            if (user.IsAdmin)
            {
                EntityList<Menu> menus = Menu.Root.AllChilds;
                if (menus == null || menus.Count == 0) return null;
                //将菜单集合转成菜单权限集合，只有管理员是超管的时候使用
                List<Permission> pers = PermissionManager.FromMenus(menus);

                #region 创建菜单权限树结构
                PermissionManager pm1 = new PermissionManager();
                pm1.CreatePermissionTree(pers);
                #endregion
                return pm1;
            }

            var adminRoles = user.AdminRoles;
            if (adminRoles == null || adminRoles.Count == 0) return null;
            PermissionManager pm = new PermissionManager();
            //以菜单id为键，权限为值的字典
            Dictionary<Int32, Permission> dic = new Dictionary<Int32, Permission>();
            //数据权限
            List<DataPermission> dpList = new List<DataPermission>();
            foreach (var item in adminRoles)
            {
                Role r = item.Role;
                //不合理的数据，跳过
                if (r == null) continue;

                #region 计算数据权限
                //先计算数据权限
                if (r.RoleDataPermissions != null && r.RoleDataPermissions.Count > 0)
                {
                    foreach (RoleDataPermission rdp in r.RoleDataPermissions)
                    {
                        DataPermission dp = rdp.DataPermission;
                        //不合理的数据
                        if (dp == null) continue;
                        //是否已经存在列表中
                        if (!dpList.Exists(p => p.ID == dp.ID)) dpList.Add(dp);
                    }
                }
                #endregion

                #region 计算菜单权限
                var roleMenus = r.RoleMenus;
                //该角色没有菜单权限
                if (roleMenus == null || roleMenus.Count == 0) continue;
                foreach (RoleMenu rm in roleMenus)
                {
                    Menu m = rm.Menu;
                    //不合理的数据，跳过
                    if (m == null) continue;
                    Permission per = null;
                    //是否已经添加过相同的菜单
                    if (dic.ContainsKey(m.ID))
                    {
                        per = dic[m.ID];
                        //计算字段权限并集
                        //计算字段个数
                        Int32 oldLen = String.IsNullOrEmpty(per.RoleMenu.FieldNames) ? 0 : per.RoleMenu.FieldNames.Split(new Char[] { ',' }, StringSplitOptions.RemoveEmptyEntries).Length;
                        Int32 newLen = String.IsNullOrEmpty(rm.FieldNames) ? 0 : rm.FieldNames.Split(new Char[] { ',' }, StringSplitOptions.RemoveEmptyEntries).Length;
                        //谁的字段数量多，以谁为主
                        per.RoleMenu = oldLen >= newLen ? per.RoleMenu : rm;
                    }
                    else
                    {
                        per = new Permission();
                        per.Role = r;
                        per.Menu = m;
                        //因为会修改角色菜单，为了不影响缓存中的实体，这里使用克隆
                        per.RoleMenu = rm.CloneEntity();
                        dic.Add(m.ID, per);
                    }

                    //该角色所拥有的菜单角色按钮
                    EntityList<RoleMenuButton> rmbs = RoleMenuButton.FindAllByRoleIDAndMenuID(r.ID, m.ID);
                    if (rmbs == null || rmbs.Count == 0) continue;
                    //计算按钮权限并集
                    foreach (RoleMenuButton rmb in rmbs)
                    {
                        Button b = rmb.Button;
                        //无效的数据
                        if (b == null) continue;
                        //按钮列表是否已经包含该按钮
                        if (per.Buttons.Exists(p => p.ID == b.ID)) continue;

                        per.Buttons.Add(b);
                    }
                }
                #endregion
            }

            pm.DataPermissions = dpList;
            #region 创建菜单权限树结构

            if (dic.Count > 0)
            {
                var values = dic.Values;
                pm.CreatePermissionTree(values);
            }

            #endregion

            return pm;
        }

        /// <summary>根据给定权限列表创建菜单权限树</summary>
        /// <param name="values"></param>
        public void CreatePermissionTree(ICollection<Permission> values)
        {
            if (values != null && values.Count > 0)
            {
                _Permissions = new List<Permission>();
                //第一次遍历，添加根节点数据
                foreach (var item in values)
                {
                    //先将根节点数据添加
                    if (item.Menu.ParentID == 0)
                    {
                        _Permissions.Add(item);
                    }
                    //对按钮列表排序
                    item.Buttons = item.Buttons.OrderByDescending(b => b.Sort).ToList();
                }
                //以菜单排序字段倒序排序，一个元素不需要排序
                if (_Permissions.Count > 1) _Permissions = _Permissions.OrderByDescending(p => p.Menu.Sort).ToList();
                //第二次遍历，添加非根节点数据
                foreach (var item in values)
                {
                    //处理非根节点
                    if (item.Menu.ParentID != 0)
                    {
                        //父级是否存在，如果父级不存在，这也是无意义的数据
                        var parent = _Permissions.Find(p => p.Menu.ID == item.Menu.ParentID);
                        if (parent != null)
                        {
                            if (parent.Childs == null)
                            {
                                parent.Childs = new List<Menu>();
                            }
                            parent.Childs.Add(item.Menu);
                            _Permissions.Add(item);
                        }
                    }
                }
                //第三次遍历，给生成的树的子节点进行排序
                foreach (var item in _Permissions)
                {
                    //以菜单排序字段倒序排序，一个元素不需要排序
                    if (item.Childs != null && item.Childs.Count > 1) item.Childs = item.Childs.OrderByDescending(p => p.Sort).ToList();
                }
            }

        }
        /// <summary>将菜单集合转成菜单权限集合，只有管理员是超管的时候使用</summary>
        /// <param name="menus"></param>
        /// <returns></returns>
        public static List<Permission> FromMenus(ICollection<Menu> menus)
        {
            if (menus != null && menus.Count > 0)
            {
                List<Permission> list = new List<Permission>();
                foreach (Menu menu in menus)
                {
                    Permission p = new Permission();
                    p.Menu = menu;
                    if (p.Menu.MenuButtons != null && p.Menu.MenuButtons.Count > 0)
                    {
                        p.Buttons = new List<Button>();
                        foreach (MenuButton mb in p.Menu.MenuButtons)
                        {
                            p.Buttons.Add(mb.Button);
                        }
                    }
                    list.Add(p);
                }
                return list;
            }
            return null;
        }
        /// <summary>获取当前请求所在菜单及其权限</summary>
        public Permission GetCurrentMenu()
        {
            var context = HttpContext.Current;
            if (context == null) return null;
            if (Permissions == null || Permissions.Count == 0) return null;
            //请求url
            String url = context.Request.AppRelativeCurrentExecutionFilePath.ToLower();
            String[] ss = url.Split('/');
            // 默认路由包括区域、控制器、动作，Url有时候会省略动作，再往后的就是参数了，动作和参数不参与菜单匹配
            Int32 max = ss.Length <= 3 ? ss.Length : 3;
            url = ss.Take(max).Join("/");
            //去掉‘~符号’
            if (url.IndexOf('~') == 0) url = url.Remove(0, 1);

            foreach (Permission p in Permissions)
            {
                //找到授权菜单
                if (!String.IsNullOrEmpty(p.Menu.Url) && p.Menu.Url.ToLower() == url)
                {
                    return p;
                }
            }
            return null;
        }
        /// <summary>校验当前用户是否授予指定权限</summary>
        /// <param name="permission">要验证的权限</param>
        /// <returns></returns>
        public Boolean IsGranted(PermissionEnum permission)
        {
            //当前请求所在菜单及其权限
            var p = GetCurrentMenu();
            if (p != null)
            {
                //只是菜单访问权限
                if (permission == PermissionEnum.Access) return true;
                else
                {
                    if (p.Buttons != null && p.Buttons.Count > 0)
                    {
                        String per = permission.ToString().ToLower();
                        foreach (Button b in p.Buttons)
                        {
                            //判断是否有授权按钮
                            if (!String.IsNullOrEmpty(b.Code) && b.Code.ToLower() == per) return true;
                        }
                    }
                }
            }
            return false;
        }

        /// <summary>从给定的字段集合中返回允许看的字段集合</summary>
        /// <param name="fieldNames">给定的字段集合</param>
        /// <returns></returns>
        public List<String> GetAllowFieldNames(ICollection<String> fieldNames)
        {
            //当前请求所在菜单及其权限
            Permission current = GetCurrentMenu();
            if (current == null || current.RoleMenu == null || String.IsNullOrEmpty(current.RoleMenu.FieldNames)) return null;
            RoleMenu rm = current.RoleMenu;
            String[] ss = rm.FieldNames.Split(new Char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
            if (ss.Length == 0) return null;
            //字段权限类型：1允许0拒绝
            Boolean isAllow = rm.IsAllow;
            //需要置空的字段集合
            List<String> allowFieldNames = new List<String>();
            //如果是仅仅允许看某些个字段
            if (isAllow)
            {
                foreach (String s in ss)
                {
                    if (fieldNames.Contains(s))
                    {
                        allowFieldNames.Add(s);
                    }
                }
            }
            else
            {
                foreach (String item in fieldNames)
                {
                    if (!ss.Contains(item)) allowFieldNames.Add(item);
                }
            }
            return allowFieldNames;
        }

        /// <summary>从给定的字段集合中返回不允许看的字段集合</summary>
        /// <param name="fieldNames">给定的字段集合</param>
        /// <returns></returns>
        public List<String> GetRejectFieldNames(ICollection<String> fieldNames)
        {
            //当前请求所在菜单及其权限
            Permission current = GetCurrentMenu();
            if (current == null || current.RoleMenu == null || String.IsNullOrEmpty(current.RoleMenu.FieldNames)) return null;
            RoleMenu rm = current.RoleMenu;
            String[] ss = rm.FieldNames.Split(new Char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
            if (ss.Length == 0) return null;
            //字段权限类型：1允许0拒绝
            Boolean isAllow = rm.IsAllow;
            //需要置空的字段集合
            List<String> rejectFieldNames = new List<String>();
            //如果是仅仅允许看某些个字段
            if (isAllow)
            {
                foreach (String item in fieldNames)
                {
                    if (!ss.Contains(item)) rejectFieldNames.Add(item);
                }
            }
            else
            {
                foreach (String s in ss)
                {
                    if (fieldNames.Contains(s))
                    {
                        rejectFieldNames.Add(s);
                    }
                }
            }
            return rejectFieldNames;
        }

        #endregion

    }

    /// <summary>权限</summary>
    [Serializable]
    public class Permission
    {
        #region 属性

        private Role _Role;
        /// <summary>角色</summary>
        public Role Role { get { return _Role; } set { _Role = value; } }

        private Menu _Menu;
        /// <summary>菜单</summary>
        public Menu Menu { get { return _Menu; } set { _Menu = value; } }

        private List<Menu> _Childs;
        /// <summary>菜单子节点</summary>
        public List<Menu> Childs { get { return _Childs; } set { _Childs = value; } }

        private RoleMenu _RoleMenu;
        /// <summary>角色菜单映射</summary>
        public RoleMenu RoleMenu { get { return _RoleMenu; } set { _RoleMenu = value; } }

        private List<Button> _Buttons = new List<Button>();
        /// <summary>按钮集合</summary>
        public List<Button> Buttons { get { return _Buttons; } set { _Buttons = value; } }

        #endregion

        #region 方法


        #endregion
    }
}
