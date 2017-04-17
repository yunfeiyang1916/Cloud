using NewLife.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using XCode;
using Cloud.Domain;

namespace Cloud.Web
{
    /// <summary>控制器基类</summary>
    /// <typeparam name="TEntity"></typeparam>
    [CloudAuthorize]
    public class BaseController<TEntity> : Controller where TEntity : Entity<TEntity>, new()
    {
        #region 默认Action
        /// <summary>首页</summary>
        [CloudAuthorize(PermissionEnum.Access)]
        public virtual ActionResult Index()
        {
            return View();
        }
        /// <summary>列表数据</summary>
        /// <param name="p">分页器</param>
        [CloudAuthorize(PermissionEnum.Access)]
        public virtual ActionResult List(CloudPager p = null)
        {
            if (p == null) p = new CloudPager();
            String key = p["key"];
            var list = Entity<TEntity>.Search(key, p);
            var result = PageResult.FromPager(p);
            result.Data = list;
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        /// <summary>添加视图</summary>
        /// <returns></returns>
        [HttpGet]
        [CloudAuthorize(PermissionEnum.Add)]
        public virtual ActionResult Add()
        {
            return Form();
        }
        /// <summary>添加操作</summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        [HttpPost]
        [CloudAuthorize(PermissionEnum.Add)]
        [ValidateAntiForgeryToken]
        public virtual ActionResult Add(TEntity entity)
        {
            entity.Insert();
            return Success("添加成功！");
        }

        /// <summary>编辑视图</summary>
        /// <returns></returns>
        [HttpGet]
        [CloudAuthorize(PermissionEnum.Edit)]
        public virtual ActionResult Edit(String id)
        {
            return Form();
        }
        /// <summary>编辑操作</summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        [HttpPost]
        [CloudAuthorize(PermissionEnum.Edit)]
        [ValidateAntiForgeryToken]
        public virtual ActionResult Edit(TEntity entity)
        {
            entity.Update();
            return Success("修改成功！");
        }
        /// <summary>详情</summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [CloudAuthorize(PermissionEnum.Detail)]
        public virtual ActionResult Detail(String id)
        {
            return Form();
        }
        /// <summary>删除操作</summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost]
        [CloudAuthorize(PermissionEnum.Delete)]
        public virtual ActionResult Delete(String id)
        {
            var entity = Entity<TEntity>.FindByKey(id);
            if (entity != null)
            {
                entity.Delete();
                return Success("删除成功！");
            }
            return Error("要删除的对象不存在！");
        }

        /// <summary>获取单个实体对象</summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost]
        public virtual ActionResult GetOne(String id)
        {
            var entity = Entity<TEntity>.FindByKey(id);
            return Success("获取成功", entity);
        }

        /// <summary>表单视图</summary>
        public virtual ActionResult Form()
        {
            return View("Form");
        }

        #endregion

        #region 操作成功或失败
        /// <summary>操作成功</summary>
        /// <param name="msg">消息</param>
        /// <param name="data">数据</param>
        /// <returns></returns>
        public virtual ActionResult Success(String msg = "操作成功！", Object data = null)
        {
            return Json(new AjaxResult() { Status = 1, Msg = msg, Data = data }, JsonRequestBehavior.AllowGet);
        }
        /// <summary>操作失败</summary>
        /// <param name="msg">消息</param>
        /// <returns></returns>
        public virtual ActionResult Error(String msg = "操作失败！")
        {
            return Json(new AjaxResult() { Status = 0, Msg = msg }, JsonRequestBehavior.AllowGet);
        }

        #endregion

        #region 辅助
        /// <summary>使用字段权限过滤数据集合，并返回结果</summary>
        /// <param name="list">要被处理的数据集合</param>
        /// <returns></returns>
        [NonAction]
        public List<Dictionary<String, Object>> UseFieldPermissionFilter(List<TEntity> list)
        {
            var pm = PermissionManager.Current;
            //处理字段权限
            if (pm != null && list != null && list.Count > 0)
            {
                var fieldNames = Entity<TEntity>.Meta.FieldNames;
                //获取允许看的字段集合
                List<String> allowFieldNames = pm.GetAllowFieldNames(fieldNames);
                if (allowFieldNames != null && allowFieldNames.Count > 0)
                {
                    List<Dictionary<String, Object>> dics = new List<Dictionary<String, Object>>();
                    foreach (var item in list)
                    {
                        Dictionary<String, Object> dic = new Dictionary<String, Object>();
                        foreach (String reject in allowFieldNames)
                        {
                            dic.Add(reject, item[reject]);
                        }
                        dics.Add(dic);
                    }
                    return dics;
                }
            }
            return null;
        }

        /// <summary>使用数据权限过滤，返回用户ID集合</summary>
        /// <remarks>
        /// 这里的获取当前登录用户所能管理的下属用户ID集合应该放到登陆的时候处理，之所以仍到这是因为其用到的场景比较小
        /// 如果有大量的数据权限过滤，则需要移到登陆处理，将结果存储到session中
        /// </remarks>
        /// <returns></returns>
        [NonAction]
        public List<Int32> UseDataPermissionFilter()
        {
            var pm = PermissionManager.Current;
            if (pm != null && pm.DataPermissions != null && pm.DataPermissions.Count > 0)
            {
                List<Int32> dataPermissionIDs = new List<Int32>();
                //遍历组装数据权限ID集合
                pm.DataPermissions.ForEach(e => dataPermissionIDs.Add(e.ID));
                //根据数据权限ID集合获取角色与数据权限映射
                var rdps = RoleDataPermission.FindAllByDataPermissionIDs(dataPermissionIDs);
                if (rdps != null && rdps.Count > 0)
                {
                    List<Int32> roleIDs = new List<Int32>();
                    //遍历组装角色ID集合
                    rdps.ForEach(e =>
                    {
                        if (!roleIDs.Contains(e.RoleID)) roleIDs.Add(e.RoleID);
                    });
                    //根据角色ID集合查找用户与角色映射
                    var adminRoles = AdminRole.FindAllByRoleIDs(roleIDs);
                    if (adminRoles != null && adminRoles.Count > 0)
                    {
                        List<Int32> adminIDs = new List<Int32>();
                        adminRoles.ForEach(e => adminIDs.Add(e.AdminID));
                        return adminIDs;
                    }
                }
            }
            return null;
        }

        #endregion
    }
}