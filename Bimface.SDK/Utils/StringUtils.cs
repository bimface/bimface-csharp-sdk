using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bimface.SDK.Utils
{
    /// <summary>
    ///     字符串工具
    ///     @author bimface, 2016-06-01.
    /// </summary>
    public class StringUtils
    {
        private StringUtils()
        {
        }

        /// <seealso cref= # Join( Object[] array, String sep, String prefix
        /// )
        /// </seealso>
        /// <param name="array"> 需要连接的对象数组 </param>
        /// <param name="sep"> 元素连接之间的分隔符 </param>
        /// <returns> 连接好的新字符串 </returns>
        public static string Join(object[] array, string sep)
        {
            return Join(array, sep, null);
        }

        /// <seealso cref= # Join( Object[] array, String sep, String prefix
        /// )
        /// </seealso>
        /// <param name="list"> 需要连接的对象数组 </param>
        /// <param name="sep"> 元素连接之间的分隔符 </param>
        /// <returns> 连接好的新字符串 </returns>
        public static string Join<T1>(ICollection<T1> list, string sep)
        {
            return Join(list, sep, null);
        }

        /// <seealso cref= # Join( Object[] array, String sep, String prefix
        /// )
        /// </seealso>
        /// <param name="list"> 需要连接的对象数组 </param>
        /// <param name="sep"> 元素连接之间的分隔符 </param>
        /// <param name="prefix"> 前缀字符串 </param>
        /// <returns> 连接好的新字符串 </returns>
        public static string Join<T1>(ICollection<T1> list, string sep, string prefix)
        {
            var array = list == null ? null : list.Select(item => item as object).ToArray();
            return Join(array, sep, prefix);
        }

        /// <summary>
        ///     以指定的分隔符来进行字符串元素连接
        ///     <para>
        ///         例如有字符串数组array和连接符为逗号(,)
        ///         <code>
        /// String[] array = new String[] { "hello", "world", "bimface", "cloud","storage" };
        /// </code>
        ///         那么得到的结果是:
        ///         <code>
        /// hello,world,bimface,cloud,storage
        /// </code>
        ///     </para>
        /// </summary>
        /// <param name="array"> 需要连接的对象数组 </param>
        /// <param name="sep"> 元素连接之间的分隔符 </param>
        /// <param name="prefix"> 前缀字符串 </param>
        /// <returns> 连接好的新字符串 </returns>
        public static string Join(object[] array, string sep, string prefix)
        {
            if (array == null)
            {
                return "";
            }

            var arraySize = array.Length;

            if (arraySize == 0)
            {
                return "";
            }

            if (sep == null)
            {
                sep = "";
            }

            if (prefix == null)
            {
                prefix = "";
            }

            var buf = new StringBuilder(prefix);
            for (var i = 0; i < arraySize; i++)
            {
                if (i > 0)
                {
                    buf.Append(sep);
                }
                buf.Append(array[i] == null ? "" : array[i]);
            }
            return buf.ToString();
        }

        /// <summary>
        ///     以json元素的方式连接字符串中元素
        ///     <para>
        ///         例如有字符串数组array
        ///         <code>
        /// String[] array = new String[] { "hello", "world", "bimface", "cloud","storage" };
        /// </code>
        ///         那么得到的结果是:
        ///         <code>
        /// "hello","world","bimface","cloud","storage"
        /// </code>
        ///     </para>
        /// </summary>
        /// <param name="array"> 需要连接的字符串数组 </param>
        /// <returns> 以json元素方式连接好的新字符串 </returns>
        public static string JsonJoin(string[] array)
        {
            var arraySize = array.Length;
            var bufSize = arraySize*(array[0].Length + 3);
            var buf = new StringBuilder(bufSize);
            for (var i = 0; i < arraySize; i++)
            {
                if (i > 0)
                {
                    buf.Append(',');
                }

                buf.Append('"');
                buf.Append(array[i]);
                buf.Append('"');
            }
            return buf.ToString();
        }

        public static bool ContainsStringArray(string s, string[] array)
        {
            foreach (var x in array)
            {
                if (s.Contains(x))
                {
                    return true;
                }
            }
            return false;
        }

        public static byte[] UTF8Bytes(string data)
        {
            return Encoding.UTF8.GetBytes(data);
        }

        public static string UTF8String(byte[] data)
        {
            return Encoding.UTF8.GetString(data);
        }
    }
}