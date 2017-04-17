using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Cloud.Domain;
using NewLife.Web;

namespace Cloud.Web.Areas.Admin.Controllers
{
    /// <summary>图标控制器</summary>
    public class IconController : BaseController<Icon>
    {
        /// <summary>图标筛选视图</summary>
        public ActionResult Select()
        {
            return View();
        }
        /// <summary>重新生成图标</summary>
        public ActionResult Render()
        {
            String path = "/Content/layouts/css/font.css";
            Icon.Render(path);
            return Success("生成成功！");
        }
    }
}