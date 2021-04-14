using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using YouLExp.Core.Comparers;

namespace YouLExp.Core
{
    /// <summary>
    /// 集合列表扩展类
    /// </summary>
    public static class ListExtend
    {
        /// <summary>
        /// 对<see cref="IEnumerable{T}"/>实体类集合按条件去重处理
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list"></param>
        /// <param name="predicate">过滤条件</param>
        /// <returns></returns>
        public static IEnumerable<T> Distinct<T>(this IEnumerable<T> list, Func<T, object> predicate)
        {
            return list.Distinct(new EntityComparer<T>(predicate));
        }

        /// <summary>
        /// 对<see cref="IEnumerable{T}"/>实体类集合按条件去重处理
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list"></param>
        /// <param name="multipPredicate">多条件过滤</param>
        /// <returns></returns>
        public static IEnumerable<T> Distinct<T>(this IEnumerable<T> list, Func<T, T, bool> multipPredicate)
        {
            return list.Distinct(new EntityComparer<T>(multipPredicate));
        }

    }
}
