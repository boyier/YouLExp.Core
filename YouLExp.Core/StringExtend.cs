using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace YouLExp.Core
{
    /// <summary>
    /// 字符串扩展类
    /// </summary>
    public static class StringExtend
    {
        /// <summary>
        /// 通过指定分隔符连接集合中每个成员。
        /// </summary>
        /// <param name="values">值</param>
        /// <param name="separator">分隔符</param>
        /// <returns>由分隔符字符串分隔的值的元素组成的字符串。如果值是空数组，则该方法返回<see cref="string.Empty"/> </returns>
        public static string ToStringJoin(this IEnumerable<string> values, string separator)
        {
            return string.Join(separator, values);
        }

        /// <summary>
        /// 通过指定分隔符连接集合中每个成员。
        /// </summary>
        /// <param name="values">值</param>
        /// <param name="separator">分隔符</param>
        /// <returns>由分隔符字符串分隔的值的元素组成的字符串。如果值是空数组，则该方法返回<see cref="string.Empty"/> </returns>
        public static string ToStringJoin(this IEnumerable<object> values, string separator)
        {
            return string.Join(separator, values);
        }

        /// <summary>
        /// 通过指定分隔符连接集合中每个成员。
        /// </summary>
        /// <param name="values">值</param>
        /// <param name="separator">分隔符</param>
        /// <returns>由分隔符字符串分隔的值的元素组成的字符串。如果值是空数组，则该方法返回<see cref="string.Empty"/> </returns>
        public static string ToStringJoin(this object[] values, string separator)
        {
            return string.Join(separator, values);
        }

        /// <summary>
        /// 通过指定分隔符连接集合中每个成员。
        /// </summary>
        /// <param name="values">值</param>
        /// <param name="separator">分隔符</param>
        /// <returns>由分隔符字符串分隔的值的元素组成的字符串。如果值是空数组，则该方法返回<see cref="string.Empty"/> </returns>
        public static string ToStringJoin<T>(this IEnumerable<T> values, string separator)
        {
            return string.Join(separator, values);
        }

    }
}
