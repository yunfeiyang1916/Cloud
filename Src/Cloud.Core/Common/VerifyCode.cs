using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cloud.Common
{
    /// <summary>验证码</summary>
    public class VerifyCode
    {
        /// <summary>
        /// 获取验证码，返回字节数组
        /// </summary>
        /// <param name="chkCode">验证码字符串</param>
        /// <returns></returns>
        public static Byte[] GetVerifyCode(out String chkCode)
        {
            Int32 codeW = 80;
            Int32 codeH = 30;
            Int32 fontSize = 16;
            chkCode = String.Empty;
            //颜色列表，用于验证码、噪线、噪点 
            Color[] color = { Color.Black, Color.Red, Color.Blue, Color.Green, Color.Orange, Color.Brown, Color.Brown, Color.DarkBlue };
            //字体列表，用于验证码 
            String[] font = { "Times New Roman" };
            //验证码的字符集，去掉了一些容易混淆的字符 
            Char[] character = { '1', '2', '3', '4', '5', '6', '7', '8', '9', 'a', 'b', 'd', 'e', 'f', 'h', 'k', 'm', 'n', 'r', 'x', 'y', 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'J', 'K', 'L', 'M', 'N', 'P', 'R', 'S', 'T', 'W', 'X', 'Y' };
            Random rnd = new Random();
            //生成验证码字符串 
            for (Int32 i = 0; i < 4; i++)
            {
                chkCode += character[rnd.Next(character.Length)];
            }
            //创建画布
            Bitmap bmp = new Bitmap(codeW, codeH);
            Graphics g = Graphics.FromImage(bmp);
            g.Clear(Color.White);
            //画噪线 
            for (Int32 i = 0; i < 3; i++)
            {
                Int32 x1 = rnd.Next(codeW);
                Int32 y1 = rnd.Next(codeH);
                Int32 x2 = rnd.Next(codeW);
                Int32 y2 = rnd.Next(codeH);
                Color clr = color[rnd.Next(color.Length)];
                g.DrawLine(new Pen(clr), x1, y1, x2, y2);
            }
            //画验证码字符串 
            for (Int32 i = 0; i < chkCode.Length; i++)
            {
                string fnt = font[rnd.Next(font.Length)];
                Font ft = new Font(fnt, fontSize);
                Color clr = color[rnd.Next(color.Length)];
                g.DrawString(chkCode[i].ToString(), ft, new SolidBrush(clr), (float)i * 18, (float)0);
            }
            //将验证码图片写入内存流，并将其以 "image/Png" 格式输出 
            MemoryStream ms = new MemoryStream();
            try
            {
                bmp.Save(ms, ImageFormat.Png);
                return ms.ToArray();
            }
            catch (Exception)
            {
                return null;
            }
            finally
            {
                g.Dispose();
                bmp.Dispose();
            }
        }

    }
}
