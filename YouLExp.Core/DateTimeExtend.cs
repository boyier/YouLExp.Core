using System;
using System.Collections.Generic;
using System.Globalization;
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
        public static DateTime ToConvetDateTime(this object dateTime, string format = "yyyy-MM-dd HH:mm:ss")
        {
            if (dateTime != null && DateTime.TryParseExact(dateTime.ToString(), format, null, System.Globalization.DateTimeStyles.None, out DateTime newTime))
                return newTime;
            else
                return DateTime.MaxValue;
        }

        /// <summary>
        /// 返回当前月的第一天（01）
        /// </summary>
        /// <param name="dateTime"></param>
        /// <returns></returns>
        public static DateTime ToMonthOfFirst(this DateTime dateTime)
        {
            return dateTime.AddDays(1 - dateTime.Day);
        }

        /// <summary>
        /// 返回当前月的最后一天（28、29、30、31）
        /// </summary>
        /// <param name="dateTime"></param>
        /// <returns></returns>
        public static DateTime ToMonthOfFast(this DateTime dateTime)
        {
            return dateTime.AddDays(1 - dateTime.Day).AddMonths(1).AddDays(-1);
        }

        /// <summary>
        /// 返回本周的第一天（星期一）
        /// </summary>
        /// <param name="dateTime"></param>
        /// <returns></returns>
        public static DateTime ToWeekOfFirst(this DateTime dateTime)
        {
            DateTime firstDate = DateTime.Now;
            switch (dateTime.DayOfWeek)
            {
                case DayOfWeek.Monday:
                    firstDate = dateTime;
                    break;
                case DayOfWeek.Tuesday:
                    firstDate = dateTime.AddDays(-1);
                    break;
                case DayOfWeek.Wednesday:
                    firstDate = dateTime.AddDays(-2);
                    break;
                case DayOfWeek.Thursday:
                    firstDate = dateTime.AddDays(-3);
                    break;
                case DayOfWeek.Friday:
                    firstDate = dateTime.AddDays(-4);
                    break;
                case DayOfWeek.Saturday:
                    firstDate = dateTime.AddDays(-5);
                    break;
                case DayOfWeek.Sunday:
                    firstDate = dateTime.AddDays(-6);
                    break;
            }
            return firstDate;
        }

        /// <summary>
        /// 返回本周的最后一天（星期日）
        /// </summary>
        /// <param name="dateTime"></param>
        /// <returns></returns>
        public static DateTime ToWeekOfFast(this DateTime dateTime)
        {
            return dateTime.AddDays(7 - (int)dateTime.DayOfWeek);
        }

        /// <summary>
        /// 获取本季度的第一天
        /// </summary>
        /// <param name="dateTime"></param>
        /// <returns></returns>
        public static DateTime ToSeasonOfFirst(this DateTime dateTime)
        {
            return dateTime.AddMonths(0 - (dateTime.Month - 1) % 3).AddDays(1 - dateTime.Day);
        }

        /// <summary>
        /// 获取本季度的最后一天
        /// </summary>
        /// <param name="dateTime"></param>
        /// <returns></returns>
        public static DateTime ToSeasonOfFast(this DateTime dateTime)
        {
            return dateTime.AddMonths(0 - (dateTime.Month - 1) % 3).AddDays(1 - dateTime.Day).AddMonths(3).AddDays(-1);
        }

        /// <summary>
        /// 获取本年年初（1月1号）
        /// </summary>
        /// <param name="dateTime"></param>
        /// <returns>本年年初</returns>
        public static DateTime ToYearOfFirst(this DateTime dateTime)
        {
            return dateTime.AddMonths(1 - dateTime.Month).AddDays(1 - dateTime.Day);
        }

        /// <summary>
        /// 获取本年年末（12月31日）
        /// </summary>
        /// <param name="dateTime"></param>
        /// <returns>本年年末</returns>
        public static DateTime ToYearOfFast(this DateTime dateTime)
        {
            return dateTime.AddMonths(1 - dateTime.Month).AddDays(1 - dateTime.Day).AddYears(1).AddDays(-1);
        }

        /// <summary>
        /// 获取当天的凌晨（00:00:00.000）
        /// </summary>
        /// <param name="dateTime"></param>
        /// <returns>返回当天的凌晨</returns>
        public static DateTime ToDayOfFirst(this DateTime dateTime)
        {
            return dateTime.Date;
        }

        /// <summary>
        /// 获取当天最后时间（23:59:59.999）
        /// </summary>
        /// <param name="dateTime"></param>
        /// <returns>返回当天最后时间</returns>
        public static DateTime ToDayOfFast(this DateTime dateTime)
        {
            return dateTime.Date.AddDays(1).AddMilliseconds(-1);
        }

        /// <summary>
        /// 获取当前是第几个周(从0周开始)
        /// </summary>
        /// <param name="dateTime"></param>
        /// <param name="culture"></param>
        /// <returns>返回周数</returns>
        public static int ToWeekOfYear(this DateTime dateTime, CultureInfo culture)
        {
            return culture.Calendar.GetWeekOfYear(dateTime, culture.DateTimeFormat.CalendarWeekRule, culture.DateTimeFormat.FirstDayOfWeek) - 1;
        }

        /// <summary>
        /// 获取当前是第几个周(从0周开始)
        /// </summary>
        /// <param name="dateTime"></param>
        /// <returns>返回周数</returns>
        public static int ToWeekOfYear(this DateTime dateTime)
        {
            return ToWeekOfYear(dateTime, new CultureInfo("zh-CN"));
        }

        #region 时间戳

        /// <summary>
        /// 获取当前时间的时间戳（13位）
        /// </summary>
        /// <param name="dateTime"></param>
        /// <returns></returns>
        public static long ToTimeStamp(this DateTime dateTime)
        {
            DateTime startTime = TimeZoneInfo.ConvertTime(new DateTime(1970, 1, 1, 0, 0, 0, 0), TimeZoneInfo.Local);
            return (dateTime.Ticks - startTime.Ticks) / 10000;   //除10000调整为13位      
        }

        /// <summary>        
        /// 将<see cref="long"/>类型的时间戳转为<see cref="DateTime"/>     
        /// </summary>        
        /// <param name="timeStamp">时间戳</param>        
        /// <returns></returns>        
        public static DateTime ToTimeStampOfDateTime(long timeStamp)
        {
            DateTime dtStart = TimeZoneInfo.ConvertTime(new DateTime(1970, 1, 1, 0, 0, 0, 0), TimeZoneInfo.Local);
            long lTime = timeStamp * 10000;
            TimeSpan toNow = new TimeSpan(lTime);
            return dtStart.Add(toNow);
        }

        #endregion

        #region DateTimeOffset

        /// <summary>
        /// 将<see cref=" DateTime"/>转换为<see cref="DateTimeOffset"/>
        /// </summary>
        /// <param name="dateTime"></param>
        /// <param name="kind">Specifies whether a <see cref="DateTime"/> object represents a local time, a Coordinated Universal Time (UTC), or is not specified as either local time or UTC.</param>
        /// <returns></returns>
        public static DateTimeOffset ToDateTimeOffset(this DateTime dateTime, DateTimeKind kind = DateTimeKind.Utc)
        {
            return DateTime.SpecifyKind(dateTime, kind);
        }

        /// <summary>
        /// 将<see cref="DateTimeOffset"/>转换为UTC时间<see cref="DateTime"/>
        /// </summary>
        /// <param name="dateTimeOffset"></param>
        /// <returns></returns>
        public static DateTime ToUtcDateTime(this DateTimeOffset dateTimeOffset)
        {
            return dateTimeOffset.UtcDateTime;
        }

        /// <summary>
        /// 将<see cref="DateTimeOffset"/>转换为<see cref="DateTime"/>
        /// </summary>
        /// <param name="dateTimeOffset"></param>
        /// <returns></returns>
        public static DateTime ToDateTime(this DateTimeOffset dateTimeOffset)
        {
            return dateTimeOffset.DateTime;
        }
        #endregion

    }
}
