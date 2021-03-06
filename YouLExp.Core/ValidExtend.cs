using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace YouLExp.Core
{
    /// <summary>
    /// 验证扩展类
    /// </summary>
    public static class ValidExtend
    {

        /// <summary>
        /// 验证字符串格式是否为邮箱地址
        /// </summary>
        /// <param name="text">文本值</param>
        /// <returns></returns>
        public static bool IsValidEmailAddress(this string text)
        {
            return new Regex(@"^\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$").IsMatch(text);
        }

        /// <summary>
        /// 验证字符串格式是否为车牌号（包含新能源车牌）
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public static bool IsValidCarNo(this string text)
        {
            return new Regex(@"^(([京津沪渝冀豫云辽黑湘皖鲁新苏浙赣鄂桂甘晋蒙陕吉闽贵粤青藏川宁琼使领][A-Z](([0-9]{5}[DF])|([DF]([A-HJ-NP-Z0-9])[0-9]{4})))|([京津沪渝冀豫云辽黑湘皖鲁新苏浙赣鄂桂甘晋蒙陕吉闽贵粤青藏川宁琼使领][A-Z][A-HJ-NP-Z0-9]{4}[A-HJ-NP-Z0-9挂学警港澳使领]))$").IsMatch(text);
        }

        /// <summary>
        /// 验证字符串是否符合强密码格式（必须包含大小写字母和数字的组合，不能使用特殊字符，长度在 8-10 之间）
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public static bool IsValidPassword(this string text)
        {
            return new Regex(@"^(?=.*\d)(?=.*[a-z])(?=.*[A-Z])[a-zA-Z0-9]{8,10}$").IsMatch(text);
        }

        /// <summary>
        /// 验证字符串是否符合强密码格式（必须包含大小写字母和数字的组合，可以使用特殊字符，长度在8-10之间）
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public static bool IsValidPasswordEx(this string text)
        {
            return new Regex(@"^(?=.*\d)(?=.*[a-z])(?=.*[A-Z]).{8,10}$").IsMatch(text);
        }

        /// <summary>
        /// 正则表达式校验
        /// </summary>
        /// <param name="text"></param>
        /// <param name="reg"></param>
        /// <returns></returns>
        public static bool IsRegexMatch(this string text, string reg)
        {
            return IsRegexMatch(text, new Regex(reg));
        }

        /// <summary>
        /// 正则表达式校验
        /// </summary>
        /// <param name="text"></param>
        /// <param name="reg"></param>
        /// <param name="regex"></param>
        /// <returns></returns>
        public static bool IsRegexMatch(this string text, string reg, RegexOptions regex)
        {
            return IsRegexMatch(text, new Regex(reg, regex));
        }

        /// <summary>
        /// 正则表达式校验
        /// </summary>
        /// <param name="text"></param>
        /// <param name="regex"></param>
        /// <returns></returns>
        public static bool IsRegexMatch(this string text, Regex regex)
        {
            return regex.IsMatch(text);
        }
    }
}
