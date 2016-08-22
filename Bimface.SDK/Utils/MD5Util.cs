using System.Security.Cryptography;
using System.Text;

namespace Bimface.SDK.Utils
{
    /// <summary>
    ///     MD5工具
    ///     @author bimface, 2016-06-01.
    /// </summary>
    public class MD5Util
    {
        /// <summary>
        ///     MD5加密
        /// </summary>
        /// <param name="string">待加密字符串</param>
        /// <returns>加密后字符串</returns>
        public static string MD5(string @string)
        {
            MD5 md5 = new MD5CryptoServiceProvider();
            var t = md5.ComputeHash(Encoding.Default.GetBytes(@string));
            var sb = new StringBuilder(32);
            for (var i = 0; i < t.Length; i++)
                sb.Append(t[i].ToString("x"));
            return sb.ToString();
        }
    }
}