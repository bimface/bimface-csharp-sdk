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


        public static void CheckUrl(string url) {
            AssertStringNotNullOrEmpty(url, "url");

            if (!url.StartsWith("http://") && !url.StartsWith("https://")) { 
                throw new ArgumentException("Url must starts with http(s)://.");
            }
        }

        public static void CheckFileLength(long maxLength, long length) {
            if (length <= 0)
            {
                throw new ArgumentException("file length is illeagal:" + length);
            }

            if (length > maxLength)
            {
                throw new ArgumentException(
                        "file length is larger:" + length + "than supported length :" + maxLength);
            }
        
        }
        
    }
}