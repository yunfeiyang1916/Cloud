using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NewLife.Web;

namespace Cloud.Web
{
    /// <summary>带分页的Ajax返回结果</summary>
    /// <typeparam name="T"></typeparam>
    public class PageResult<T> : AjaxResult<T>
    {
        #region 属性

        private Int32 _PageIndex = 1;
        /// <summary>页面索引</summary>
        public virtual Int32 PageIndex { get { return _PageIndex; } set { _PageIndex = value > 1 ? value : 1; } }

        private Int32 _PageSize = 20;
        /// <summary>页面大小</summary>
        public virtual Int32 PageSize { get { return _PageSize; } set { _PageSize = value > 1 ? value : 20; } }

        private Int32 _TotalCount;
        /// <summary>总记录数</summary>
        public Int32 TotalCount { get { return _TotalCount; } set { _TotalCount = value; } }

        private Int32 _PageCount;
        /// <summary>页数</summary>
        public Int32 PageCount { get { return _PageCount; } set { _PageCount = value; } }

        #endregion

        #region 方法
        /// <summary>从后端分页器转换</summary>
        /// <param name="p"></param>
        /// <returns></returns>
        public static PageResult<T> FromPager(Pager p)
        {
            return new PageResult<T> { _PageIndex = p.PageIndex, _PageSize = p.PageSize, _TotalCount = p.TotalCount, _PageCount = p.PageCount };
        }

        #endregion
    }
    /// <summary>带分页的Ajax返回结果</summary>
    public class PageResult : PageResult<Object> { }
}
