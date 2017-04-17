using Cloud.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using XCode;

namespace Cloud.Web.Areas.Admin.Controllers
{
    /// <summary>按钮控制器</summary>
    public class ButtonController : BaseController<Button>
    {
        /// <summary>按钮筛选视图</summary>
        public ActionResult Select()
        {
            return View();
        }
        /// <summary>列表数据</summary>
        /// <param name="p">分页器</param>
        public override ActionResult List(CloudPager p = null)
        {
            if (p == null) p = new CloudPager();
            String key = p["key"];
            Int32 menuID = p["menuID"].ToInt();
            var list = Button.Search(key, p);
            var result = PageResult.FromPager(p);
            result.Data = list;
            if (list==null||list.Count==0)
            {
                return Json(result,JsonRequestBehavior.AllowGet);
            }
            //是否有menuID参数，有的话需要设置该菜单是否已经拥有该按钮
            if (menuID != 0)
            {
                EntityList<MenuButton> menuButtons = MenuButton.FindAllByMenuID(menuID);
                if (menuButtons!=null&&menuButtons.Count>0)
                {
                    foreach (Button button in list)
                    {
                        foreach (MenuButton m in menuButtons)
                        {
                            if (button.ID==m.ButtonID)
                            {
                                button.Selected = true;
                                break;
                            }
                        }
                    }
                }
            }
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        /// <summary>更新菜单与按钮之间的映射</summary>
        /// <param name="ids"></param>
        /// <param name="menuID"></param>
        /// <returns></returns>
        public ActionResult UpdateMenuButton(String[] ids, String menuID)
        {
            Int32 intMenuID = menuID.ToInt();
            if (ids == null || ids.Length == 0 || intMenuID == 0)
            {
                return Error("参数为空！");
            }
            //先删除，在添加
            MenuButton.DeleteByMenuID(intMenuID);
            EntityList<MenuButton> list = new EntityList<MenuButton>();
            foreach (var id in ids)
            {
                MenuButton entity = new MenuButton();
                entity.ButtonID = id.ToInt();
                entity.MenuID = intMenuID;
                list.Add(entity);
            }
            Int32 result = list.Insert(true);
            return Success("操作成功！", result);
        }
    }
}