using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Cloud.Web
{
    /// <summary>Ajax返回结果</summary>
    /// <typeparam name="T"></typeparam>
    public class AjaxResult<T>
    {
        private Int32 _Status = 1;
        /// <summary>状态 1表示成功 0表示失败</summary>
        public Int32 Status { get { return _Status; } set { _Status = value; } }

        private T _Data;
        /// <summary>数据</summary>
        public T Data { get { return _Data; } set { _Data = value; } }

        private String _Msg = "Success";
        /// <summary>信息</summary>
        public String Msg { get { return _Msg; } set { _Msg = value; } }
    }
    /// <summary>Ajax返回结果</summary>
    public class AjaxResult : AjaxResult<Object> { }
}