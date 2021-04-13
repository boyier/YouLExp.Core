using System;
using System.Collections.Generic;
using System.Text;

namespace YouLExp.Core
{
    /// <summary>
    /// <see cref="DateTime"/>扩展类
    /// </summary>
    public static class DateTimeExtend
    {
        /// <summary>
        /// 转换为<see cref="DateTime"/>类型
        /// </summary>
        /// <param name="dateTime">原格式</param>
        /// <param name="format"></param>
        /// <returns></returns>
        internal static DateTime ToConvetDateTime(this object dateTime, string format = "yyyy-MM-dd HH:mm:ss")
        {
            DateTime newTime;
            if (dateTime != null && DateTime.TryParseExact(dateTime.ToString(), format, null, System.Globalization.DateTimeStyles.None, out newTime))
                return newTime;
            else
                return DateTime.MaxValue;
        }

    }
}
