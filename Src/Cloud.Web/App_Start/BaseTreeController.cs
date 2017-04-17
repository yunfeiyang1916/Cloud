using Cloud.Domain;
using NewLife.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using XCode;

namespace Cloud.Web
{
    /// <summary>控制器树机构基类</summary>
    /// <typeparam name="TEntity"></typeparam>
    [CloudAuthorize]
    public class BaseTreeController<TEntity> : BaseController<TEntity> where TEntity : EntityTree<TEntity>, new()
    {
        /// <summary>列表数据</summary>
        /// <param name="p">分页器</param>
        [CloudAuthorize(PermissionEnum.Access)]
        public override ActionResult List(CloudPager p = null)
        {
            String key = p != null ? p["key"] : null;
            var list = EntityTree<TEntity>.Root.AllChilds;

            p.TotalCount = list != null ? list.Count : 0;
            var result = PageResult.FromPager(p);
            result.Data = list;
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        /// <summary>获取树列表</summary>
        /// <returns></returns>
        [CloudAuthorize(PermissionEnum.Access)]
        public ActionResult GetTreeList()
        {
            var list = EntityTree<TEntity>.FindAllChildsByParent(0);
            return Success("获取成功。", list);
        }
    }
}