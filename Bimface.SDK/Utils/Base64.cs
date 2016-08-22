using System;
using System.Text;

namespace Bimface.SDK.Utils
{
    /// <summary>
    ///     Base64工具
    ///     @author bimface, 2016-06-01.
    /// </summary>
    public class Base64
    {
        public static string Encode(byte[] buff)
        {
            lock (typeof (Base64))
            {
                if (null == buff)
                {
                    return null;
                }
                return Convert.ToBase64String(buff);
            }
        }

        public static string Encode(string @string, string encoding)
        {
            lock (typeof (Base64))
            {
                if (null == @string || null == encoding)
                {
                    return null;
                }
                var stringArray = Encoding.GetEncoding(encoding).GetBytes(@string);
                return Encode(stringArray);
            }
        }

        public static string Decode(string @string, string encoding)
        {
            lock (typeof (Base64))
            {
                if (null == @string || null == encoding)
                {
                    return null;
                }
                var buffer = Convert.FromBase64String(@string);
                return Encoding.GetEncoding(encoding).GetString(buffer);
            }
        }
    }
}