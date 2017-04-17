using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Cloud.Web.Areas.Admin.Controllers
{
    /// <summary>统计报表控制器</summary>
    public class ReportController : Controller
    {
        /// <summary>折线（直线）图</summary>
        public ActionResult Line()
        {
            return View();
        }

        /// <summary>曲线图</summary>
        public ActionResult Spline()
        {
            return View();
        }
        /// <summary>面积图</summary>
        public ActionResult Area()
        {
            return View();
        }

        /// <summary>条形图</summary>
        public ActionResult Bar()
        {
            return View();
        }

        /// <summary>柱状图</summary>
        public ActionResult Column()
        {
            return View();
        }

        /// <summary>饼图</summary>
        public ActionResult Pie()
        {
            return View();
        }

        /// <summary>散点图</summary>
        public ActionResult Scatter()
        {
            return View();
        }

        /// <summary>气泡图</summary>
        public ActionResult Bubble()
        {
            return View();
        }
        /// <summary>仪表盘</summary>
        public ActionResult Gauge()
        {
            return View();
        }
        /// <summary>模拟时钟</summary>
        public ActionResult GaugeClock()
        {
            return View();
        }

        /// <summary>雷达团</summary>
        public ActionResult Polar()
        {
            return View();
        }

        /// <summary>蛛网图</summary>
        public ActionResult PolarSpider()
        {
            return View();
        }

        /// <summary>玫瑰图</summary>
        public ActionResult PolarRose()
        {
            return View();
        }
        /// <summary>漏斗图</summary>
        public ActionResult Funnel()
        {
            return View();
        }
        /// <summary>蜡烛图</summary>
        public ActionResult Boxplot()
        {
            return View();
        }
        /// <summary>流程图</summary>
        public ActionResult Flow()
        {
            return View();
        }
    }
}