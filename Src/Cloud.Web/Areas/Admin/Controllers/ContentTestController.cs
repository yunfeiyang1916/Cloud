using Cloud.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using XCode;

namespace Cloud.Web.Areas.Admin.Controllers
{
    /// <summary>内容测试控制器</summary>
    public class ContentTestController : BaseController<ContentTest>
    {
        /// <summary>列表数据，使用字段权限过滤</summary>
        /// <param name="p">分页器</param>
        [CloudAuthorize(PermissionEnum.Access)]
        public override ActionResult List(CloudPager p = null)
        {
            if (p == null) p = new CloudPager();
            String key = p["key"];
            //使用数据权限过滤
            List<Int32> userIDs = UseDataPermissionFilter();
            var list = ContentTest.Search(key, userIDs, p);
            var result = PageResult.FromPager(p);
            //获取被字段权限过滤后的数据集合
            List<Dictionary<String, Object>> dics = UseFieldPermissionFilter(list);
            if (dics != null)
            {
                result.Data = dics;
            }
            else
            {
                result.Data = list;
            }
            return Json(result, JsonRequestBehavior.AllowGet);
        }
    }
}