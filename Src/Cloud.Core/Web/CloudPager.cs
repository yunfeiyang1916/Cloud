using System;
using NewLife.Web;

namespace Cloud.Web
{
    /// <summary>云平台分页器</summary>
    public class CloudPager : Pager
    {
        private String _Order;
        /// <summary>排序方式 Desc 倒序 Asc 正序</summary>
        public String Order
        {
            get { return _Order; }
            set
            {
                _Order = value;
                if (!String.IsNullOrEmpty(value) && value.ToLower() == "desc")
                {
                    Desc = true;
                }
            }
        }
    }
}
