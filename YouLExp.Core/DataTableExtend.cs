using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace YouLExp.Core
{
    /// <summary>
    /// <see cref="DataTable"/>扩展类
    /// </summary>
    public static class DataTableExtend
    {
        /// <summary>
        /// 判断<see cref="DataRow"/>行中是否存在<see cref="DataColumn"/>列
        /// </summary>
        /// <param name="dr">要验证的行</param>
        /// <param name="colunmName">列名</param>
        /// <returns></returns>
        public static bool ContainsColunmName(this DataRow dr, string colunmName)
        {
            return dr.Table.Columns.Contains(colunmName);
        }
    }
}
