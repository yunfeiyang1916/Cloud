using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Cloud.Domain.Membership
{
    /// <summary>云平台日志提供者</summary>
    /// <remarks>
    /// 该实现会自动注册到容器中并替换掉默认的自动注册实现
    /// 因为自动注册的外部实现（非排除项）的默认优先级高于自动注册的实现
    /// </remarks>
    public class CloudLogProvider : XCode.Membership.LogProvider<Log>
    {
    }
}
