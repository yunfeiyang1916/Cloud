using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XCode.Membership;

namespace Cloud.Domain
{
    /// <summary>平台管理提供者</summary>
    /// <typeparam name="TUser"></typeparam>
    public class CloudManageProvider<TUser> : ManageProvider where TUser : Admin, new()
    {
        /// <summary>用户类型</summary>
        public override Type UserType
        {
            get { return typeof(TUser); }
        }
        /// <summary>当前用户</summary>
        public override IManageUser Current
        {
            get
            {
                return Admin.Current;
            }
            set
            {
                Admin.Current = (Admin)value;
            }
        }
        /// <summary>根据用户编号查找</summary>
        /// <param name="userid"></param>
        /// <returns></returns>
        public override IManageUser FindByID(Object userid)
        {
            return Admin.FindByID((Int32)userid);
        }
        /// <summary>根据用户帐号查找</summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public override IManageUser FindByName(String name)
        {
            return Admin.FindByName(name);
        }
        /// <summary>登录</summary>
        /// <param name="name"></param>
        /// <param name="password"></param>
        /// <param name="rememberme">是否记住密码</param>
        /// <returns></returns>
        public override IManageUser Login(String name, String password, Boolean rememberme)
        {
            return Admin.Login(name, password, rememberme);
        }
        /// <summary>注册用户</summary>
        /// <param name="name">用户名</param>
        /// <param name="password">密码</param>
        /// <param name="rolename">角色名称</param>
        /// <param name="enable">是否启用。某些系统可能需要验证审核</param>
        /// <returns></returns>
        public override IManageUser Register(String name, String password, String rolename, Boolean enable)
        {
            throw new NotImplementedException();
        }
    }


    /// <summary>平台管理提供者默认实现</summary>
    /// <remarks>
    /// 该实现会自动注册到容器中并替换掉默认的自动注册实现
    /// 因为自动注册的外部实现（非排除项）的默认优先级高于自动注册的实现
    /// </remarks>
    public class CloudManageProvider : CloudManageProvider<Admin>
    {

    }
}
