using System;
using System.Collections.Generic;
using System.Text;
using YouLExp.Core.Data;

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

        #region 

        /// <summary>
        /// 获取字符串文本每个字的拼音首字母并拼接起来
        /// </summary>
        /// <param name="chText">默认获取字符串第一个字符的首字母</param>
        /// <param name="isOR">识别字符失败后是否返回原值</param>
        /// <returns>返回每个字的拼音首字母组成的字符串 </returns>
        [Obsolete("生僻字在此方法中，无法识别，请使用GetChineseSpell方法。")]
        public static string GetCNCharSpell(this string chText, bool isOR = false)
        {
            int len = chText.Length;
            StringBuilder text = new StringBuilder();

            for (int i = 0; i < len; i++)
            {
                text.Append(GetCNCharSpell(chText.Substring(i, 1)[0], isOR));
            }

            return text.ToString();
        }

        /// <summary>
        /// 获取拼音首字母
        /// </summary>
        /// <param name="cnchar">默认获取字符串第一个字符的首字母</param>
        /// <param name="isOR">识别字符失败后是否返回原值</param>
        /// <returns>返回字符串第一个字的首字母</returns>
        [Obsolete("生僻字在此方法中，无法识别，请使用GetChineseSpell方法。")]
        public static string GetCNCharSpell(this char cnchar, bool isOR = false)
        {
            return GetSpell(cnchar.ToString(), isOR).ToUpper();

            //var val = Encoding.Default.GetBytes(chChar);
            //long longchar;

            //if (val.Length == 1)
            //    return chChar.ToUpper();
            //else
            //    longchar = (short)val[0] * 256 + (short)val[1];//从单个字符中获取字节数组

            //switch (longchar)
            //{
            //    case var a when a >= 45217 && a <= 45252:
            //        return "A";
            //    case var a when a >= 45253 && a <= 45760:
            //        return "B";
            //    case var a when a >= 45761 && a <= 46317:
            //        return "C";
            //    case var a when a >= 46318 && a <= 46825:
            //        return "D";
            //    case var a when a >= 46826 && a <= 47009:
            //        return "E";
            //    case var a when a >= 47010 && a <= 47296:
            //        return "F";
            //    case var a when a >= 47297 && a <= 47613:
            //        return "G";
            //    case var a when a >= 47614 && a <= 48118:
            //        return "H";
            //    case var a when a >= 48119 && a <= 49061:
            //        return "J";
            //    case var a when a >= 49062 && a <= 49323:
            //        return "K";
            //    case var a when a >= 49324 && a <= 49324:
            //        return "L";
            //    case var a when a >= 49896 && a <= 50370:
            //        return "M";
            //    case var a when a >= 50371 && a <= 50613:
            //        return "N";
            //    case var a when a >= 50614 && a <= 50621:
            //        return "O";
            //    case var a when a >= 50622 && a <= 50905:
            //        return "P";
            //    case var a when a >= 50906 && a <= 51386:
            //        return "Q";
            //    case var a when a >= 51387 && a <= 51445:
            //        return "R";
            //    case var a when a >= 51446 && a <= 52217:
            //        return "S";
            //    case var a when a >= 52218 && a <= 52697:
            //        return "T";
            //    case var a when a >= 52698 && a <= 52979:
            //        return "W";
            //    case var a when a >= 52980 && a <= 53640:
            //        return "X";
            //    case var a when a >= 53689 && a <= 54480:
            //        return "Y";
            //    case var a when a >= 54481 && a <= 55289:
            //        return "Z";
            //    default:
            //        return "?";
            //}
        }

        private static string GetSpell(string cnChar, bool isOriginalReturn)
        {
            //将汉字转化为ASNI码,二进制序列 
            byte[] arrCN = Encoding.Default.GetBytes(cnChar);

            if (arrCN.Length > 1)
            {
                int area = (short)arrCN[0];
                int pos = (short)arrCN[1];
                int code = (area << 8) + pos;
                int[] areacode = { 45217, 45253, 45761, 46318, 46826, 47010, 47297, 47614, 48119, 48119, 49062, 49324, 49896, 50371, 50614, 50622, 50906, 51387, 51446, 52218, 52698, 52698, 52698, 52980, 53689, 54481 };
                int max;
                for (int i = 0; i < 26; i++)
                {
                    max = 55290;

                    if (i != 25)
                        max = areacode[i + 1];

                    if (areacode[i] <= code && code < max)
                        return Encoding.Default.GetString(new byte[] { (byte)(65 + i) });
                }
                return isOriginalReturn ? cnChar : "?";
            }
            else return cnChar;
        }

        #endregion

        /// <summary> 
        /// 获得一个字符串的汉语拼音码(包含生僻词)
        /// <para>此方法目前包含了20901个汉字，收录的字符的Unicode编码范围为19968至40869</para>
        /// </summary> 
        /// <param name="strText">字符串</param> 
        /// <returns>汉语拼音码,该字符串只包含大写的英文字母</returns> 
        public static string GetChineseSpell(this string strText)
        {
            if (strText == null || strText.Length == 0)
                return strText;
            StringBuilder text = new StringBuilder();
            char vChar;

            for (int i = 0; i < strText.Length; i++)
            {
                vChar = strText[i];

                if ((vChar >= 'a' && vChar <= 'z') || (vChar >= 'A' && vChar <= 'Z'))
                    text.Append(char.ToUpper(vChar));
                else if ((int)vChar >= 19968 && (int)vChar <= 40869)
                {
                    for (int j = 0; i < StringExtComm.ChineseCharList.Length; j++)
                    {
                        if (StringExtComm.ChineseCharList[j].IndexOf(vChar) > 0)
                        {
                            text.Append(StringExtComm.ChineseCharList[j][0]);
                            break;
                        }
                    }
                }
            }
            return text.ToString();
        }

    }
}
