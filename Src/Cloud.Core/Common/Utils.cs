using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Cloud.Common
{
    /// <summary>工具辅助类</summary>
    public class Utils
    {
        #region 文件操作
        /// <summary>
        /// 获得当前绝对路径
        /// </summary>
        /// <param name="strPath">指定的路径</param>
        /// <returns>绝对路径</returns>
        public static string GetMapPath(string strPath)
        {
            if (strPath.ToLower().StartsWith("http://"))
            {
                return strPath;
            }
            if (HttpContext.Current != null)
            {
                return HttpContext.Current.Server.MapPath(strPath);
            }
            else //非web程序引用
            {
                strPath = strPath.Replace("/", "\\");
                if (strPath.StartsWith("\\"))
                {
                    strPath = strPath.Substring(strPath.IndexOf('\\', 1)).TrimStart('\\');
                }
                return Path.Combine(AppDomain.CurrentDomain.BaseDirectory, strPath);
            }
        }


        #endregion

        #region 将UTF8编码转为iso-8859-1编码

        /// <summary>转换为ISO_8859_1</summary>
        /// <remarks>因为Http Header是用iso-8859-1编码的，但是中文实际是用uft8编码</remarks>
        /// <param name="srcText"></param>
        /// <returns></returns>
        public static string StringToISO_8859_1(string srcText)
        {
            string dst = "";
            char[] src = srcText.ToCharArray();
            for (int i = 0; i < src.Length; i++)
            {
                string str = @"&#" + (int)src[i] + ";";
                dst += str;
            }
            return dst;
        }

        /// <summary>转换为原始字符串</summary>
        /// <param name="srcText"></param>
        /// <returns></returns>
        public static string ISO_8859_1ToString(string srcText)
        {
            string dst = "";
            string[] src = srcText.Split(';');
            for (int i = 0; i < src.Length; i++)
            {
                if (src[i].Length > 0)
                {
                    string str = ((char)int.Parse(src[i].Substring(2))).ToString();
                    dst += str;
                }
            }
            return dst;
        }

        #endregion
    }
}
