using System;
using System.Collections.Generic;
using System.Text;

namespace YouLExp.Core
{
    /// <summary>
    /// 数值扩展类
    /// </summary>
    public static class ValueExtend
    {
        #region decimal

        /// <summary>
        /// 将<see cref="System.Decimal "/>类型的值舍入到指定的小数位数。
        /// </summary>
        /// <param name="value">值</param>
        /// <param name="decimals">舍入的小数位数</param>
        /// <param name="midpoint">舍入方式</param>
        /// <returns></returns>
        public static decimal ToRound(this decimal value, int decimals, MidpointRounding midpoint)
        {
            return decimal.Round(value, decimals, midpoint);
        }

        /// <summary>
        /// 将<see cref="System.Decimal "/>类型的值舍入到指定的小数位数。
        /// </summary>
        /// <param name="value">值</param>
        /// <param name="decimals">舍入的小数位数</param>
        /// <returns></returns>
        public static decimal ToRound(this decimal value, int decimals)
        {
            return decimal.Round(value, decimals);
        }
        #endregion

        #region double

        /// <summary>
        /// 将<see cref="System.Double "/>类型的值舍入到指定的小数位数。
        /// </summary>
        /// <param name="value">值</param>
        /// <param name="decimals">舍入的小数位数</param>
        /// <param name="midpoint">舍入方式</param>
        /// <returns></returns>
        public static double ToRound(this double value, int decimals, MidpointRounding midpoint)
        {
            return Math.Round(value, decimals, midpoint);
        }

        /// <summary>
        /// 将<see cref="System.Double "/>类型的值舍入到指定的小数位数。
        /// </summary>
        /// <param name="value">值</param>
        /// <param name="decimals">舍入的小数位数</param>
        /// <returns></returns>
        public static double ToRound(this double value, int decimals)
        {
            return Math.Round(value, decimals);
        }
        #endregion

        #region 整数

        /// <summary>
        /// 转换为<see cref="Int32"/>类型
        /// </summary>
        /// <param name="value"></param>
        /// <param name="defaultValue">转换失败默认值</param>
        /// <returns></returns>
        public static int ToConvertInt32(this object value, int defaultValue = 0)
        {
            if (value != null & int.TryParse(value.ToString(), out int newvalue))
                return newvalue;
            else
                return defaultValue;
        }

        /// <summary>
        /// 转换为<see cref="Int64"/>类型
        /// </summary>
        /// <param name="value"></param>
        /// <param name="defaultValue">转换失败默认值</param>
        /// <returns></returns>
        public static long ToConvertInt64(this object value, long defaultValue = 0)
        {
            if (value != null & long.TryParse(value.ToString(), out long newvalue))
                return newvalue;
            else
                return defaultValue;
        }

        #endregion


    }
}
