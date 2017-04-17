using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cloud.Domain;

namespace Cloud.Domain.Dto
{
    /// <summary>客户端数据传输对象</summary>
    public class ClientDataDto
    {
        private PermissionManager _PermissionManager;
        /// <summary>权限管理器</summary>
        public PermissionManager PermissionManager { get { return _PermissionManager; } set { _PermissionManager = value; } }

        private Admin _Admin;
        /// <summary>管理员</summary>
        public Admin Admin { get { return _Admin; } set { _Admin = value; } }
    }
}
