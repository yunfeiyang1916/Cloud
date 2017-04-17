using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Cloud.Domain;

namespace Cloud.Web.Areas.Admin.Controllers
{
    /// <summary>管理员控制器</summary>
    public class AdminController : BaseController<Cloud.Domain.Admin>
    {
        /// <summary>添加操作</summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        [HttpPost]
        [CloudAuthorize(PermissionEnum.Add)]
        [ValidateAntiForgeryToken]
        public override ActionResult Add(Cloud.Domain.Admin entity)
        {
            //如果密码不为空，则先将密码md5加密
            if (!String.IsNullOrEmpty(entity.Password))
            {
                entity.Password = entity.Password.MD5().ToLower();
            }
            entity.Insert();
            return Success("添加成功！");
        }

        /// <summary>编辑操作</summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        [HttpPost]
        [CloudAuthorize(PermissionEnum.Edit)]
        [ValidateAntiForgeryToken]
        public override ActionResult Edit(Cloud.Domain.Admin entity)
        {
            //如果密码不为空，则先将密码md5加密
            if (!String.IsNullOrEmpty(entity.Password))
            {
                entity.Password = entity.Password.MD5().ToLower();
            }
            entity.Update();
            return Success("修改成功！");
        }
    }
}