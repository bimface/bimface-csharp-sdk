using System;
using System.Collections.Generic;

namespace Bimface.SDK.Utils
{
    /// <summary>
    ///     参数校验
    ///     @author bimface, 2016-06-01.
    /// </summary>
    public class AssertUtils
    {
        public static void AssertParameterNotNull(object param, string paramName)
        {
            if (param == null)
            {
                throw new NullReferenceException("ParameterIsNull " + paramName);
            }
        }

        public static void AssertParameterInRange(long param, long lower, long upper)
        {
            if (!CheckParamRange(param, lower, true, upper, true))
            {
                throw new ArgumentException(string.Format("{0:D} not in valid range [{1:D}, {2:D}]", param, lower, upper));
            }
        }

        public static void AssertStringNotNullOrEmpty(string param, string paramName)
        {
            AssertParameterNotNull(param, paramName);
            if (param.Trim().Length == 0)
            {
                throw new ArgumentException("ParameterStringIsEmpty " + paramName);
            }
        }

        public static void AssertListNotNullOrEmpty<T1>(IList<T1> param, string paramName)
        {
            AssertParameterNotNull(param, paramName);
            if (param.Count == 0)
            {
                throw new ArgumentException("ParameterListIsEmpty" + paramName);
            }
        }

        public static bool IsNullOrEmpty(string value)
        {
            return value == null || value.Length == 0;
        }

        public static void AssertTrue(bool condition, string message)
        {
            if (!condition)
            {
                throw new ArgumentException(message);
            }
        }

        public static bool CheckParamRange(long param, long from, bool leftInclusive, long to, bool rightInclusive)
        {
            if (leftInclusive && rightInclusive) // [from, to]
            {
                if (from <= param && param <= to)
                {
                    return true;
                }
                return false;
            } // [from, to)
            if (leftInclusive && !rightInclusive)
            {
                if (@from <= param && param < to)
                {
                    return true;
                }
                return false;
            } // (from, to)
            if (!leftInclusive && !rightInclusive)
            {
                if (@from < param && param < to)
                {
                    return true;
                }
                return false;
            } // (from, to]
            if (@from < param && param <= to)
            {
                return true;
            }
            return false;
        }

        /// <summary>
        ///     检查文件名
        /// </summary>
        /// <param name="name"> 文件名 </param>
        public static void CheckFileName(string name)
        {
            AssertStringNotNullOrEmpty(name, "file name must not be empty");

            if (name.Length > 256)
            {
                throw new ArgumentException("file name too long, no more than 256 characters");
            }

            string[] @string = {"/", "\n", "*", "\\", "<", ">", "|", "\"", ":", "?"};

            if (StringUtils.ContainsStringArray(name, @string))
            {
                throw new ArgumentException(
                    "file name contains illegal character, '/', '\n', '*', '\\', '<', '>', '|', '\"', ':', '?'");
            }
        }

        /// <summary>
        ///     检查文件上传后缀
        /// </summary>
        /// <param name="allSupportedType"> 支持的所有文件后缀 </param>
        /// <param name="suffix"> 文件后缀 </param>
        public static void CheckFileSuffix(IList<string> allSupportedType, string suffix)
        {
            AssertStringNotNullOrEmpty(suffix, "suffix must not be empty");

            if (!FileFormatsSupported(allSupportedType, suffix))
            {
                throw new ArgumentException("file type not supported (supported types:" +
                                            StringUtils.Join(allSupportedType, ",") + ")");
            }
        }

        /// <summary>
        ///     文件格式匹配
        /// </summary>
        /// <param name="allSupportedType"> bimface支持的所有文件后缀 </param>
        /// <param name="suffix"> 文件后缀 </param>
        /// <returns> true：支持上传，false：不支持上传 </returns>
        public static bool FileFormatsSupported(IList<string> allSupportedType, string suffix)
        {
            foreach (var s in allSupportedType)
            {
                if (s.Equals(suffix, StringComparison.CurrentCultureIgnoreCase))
                {
                    return true;
                }
            }
            return false;
        }
    }
}