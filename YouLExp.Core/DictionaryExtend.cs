using System;
using System.Collections.Generic;
using System.Text;

namespace YouLExp.Core
{
    /// <summary>
    /// 字典扩展类
    /// </summary>
    public static class DictionaryExtend
    {
        /// <summary>
        /// 根据Key从<see cref="Dictionary{TKey, TValue}"/>中获取Value值，找不到则返回默认值
        /// </summary>
        /// <typeparam name="TKey"></typeparam>
        /// <typeparam name="TValue"></typeparam>
        /// <param name="dict"></param>
        /// <param name="name"></param>
        /// <param name="defaultValue"></param>
        /// <returns></returns>
        public static TValue GetValue<TKey, TValue>(this Dictionary<TKey, TValue> dict, TKey name, TValue defaultValue = default)
        {
            return dict.ContainsKey(name) ? dict[name] : defaultValue;
        }
    }
}
