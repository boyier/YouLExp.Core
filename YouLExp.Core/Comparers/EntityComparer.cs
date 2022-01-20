using System;
using System.Collections.Generic;
using System.Text;

namespace YouLExp.Core.Comparers
{
    /// <summary>
    /// 通用的实体类比较器
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class EntityComparer<T> : IEqualityComparer<T>
    {
        private readonly Func<T, object> _func;
        private readonly Func<T, T, bool> _funcComp;

        /// <summary>
        /// 通用的实体类比较器
        /// </summary>
        /// <param name="predicate">多条件筛选</param>
        public EntityComparer(Func<T, T, bool> predicate)
        {
            this._funcComp = predicate ?? throw new Exception("Func<T, T, bool> predicate 不能为Null。");
        }

        /// <summary>
        /// 通用的实体类比较器
        /// </summary>
        /// <param name="predicate">筛选条件</param>
        public EntityComparer(Func<T, object> predicate)
        {
            this._func = predicate ?? throw new Exception("Func<T, object> predicate 不能为Null。");
        }

        /// <inheritdoc/>
        public bool Equals(T x, T y)
        {
            if (this._funcComp != null)
                return this._funcComp.Invoke(x, y);
            else
                return this._func.Invoke(x).Equals(this._func.Invoke(y));
        }

        /// <inheritdoc/>
        public int GetHashCode(T obj)
        {
            //obj.ToString().GetHashCode() 这里的tostring方法返回内容相同，那么就会使用bool Equals(TSource x, TSource y)进行比较
            //obj.GetHashCode()这种会因为引用地址不同导致获取的哈希值不同
            if (obj.Equals(null))
                return 0;
            else
                return obj.ToString().GetHashCode();
            //return obj.GetHashCode();
        }
    }
}
