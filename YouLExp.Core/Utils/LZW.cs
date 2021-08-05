using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace YouLExp.Core.Utils
{
    /// <summary>
    /// LZW算法
    /// </summary>
    public static class LZW
    {
        private const int _size = 2 << (9 - 1);

        /// <summary>
        /// LZW压缩
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public static int[] EnLZW(byte[] source, int size = _size)
        {
            if (source.Length == 0)
                return new int[0];

            List<int> output = new List<int>();

            int[][] tables = new int[size][];
            for (int i = 0; i < 256; i++)
            {
                tables[i] = new int[1];
                tables[i][0] = i;
            }
            int storeindex = 256;

            int prefix = source[0];

            for (int i = 1; i < source.Length; i++)
            {

                int c = source[i] >= 0 ? source[i] : source[i] + 255;
                int[] entry = new int[] { prefix, c };

                int position = IndexOfTables(tables, entry);
                if (position == -1)
                {
                    output.Add(prefix);
                    tables[storeindex++] = entry;
                    prefix = c;
                }
                else
                    prefix = position;
            }
            output.Add(prefix);

            int[] r = new int[output.Count];
            for (int i = 0; i < r.Length; i++)
                r[i] = output[i];

            return r;
        }

        /// <summary>
        /// LZW解压缩
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public static byte[] UnLZW(int[] source, int size = _size)
        {
            if (source.Length == 0)
                return new byte[0];
            if (source.Length == 1)
                return new byte[] { (byte)source[0] };

            int[][] tables = new int[size][];
            for (int i = 0; i < 256; i++)
            {
                tables[i] = new int[1];
                tables[i][0] = i;
            }
            int storeindex = 256;

            List<byte> output = new List<byte>();
            int prefix = source[0];
            int prefixPrefix = prefix;

            output.Add((byte)source[0]);

            for (int i = 1; i < source.Length; i++)
            {

                int c = source[i];
                int[] data;

                if (c >= storeindex)
                {
                    data = FindFromTables(tables, prefix);
                    int[] t = new int[data.Length + 1];

                    data.CopyTo(t, 0);

                    t[t.Length - 1] = prefixPrefix;
                    data = t;
                }
                else
                    data = FindFromTables(tables, c);

                prefixPrefix = data[0];
                int[] entry = new int[] { prefix, data[0] };
                tables[storeindex++] = entry;

                prefix = c;

                for (int j = 0; j < data.Length; j++)
                    output.Add((byte)data[j]);
            }

            byte[] r = new byte[output.Count];
            for (int i = 0; i < r.Length; i++)
                r[i] = output[i];
            return r;
        }

        #region 私有

        private static int IndexOfTables(int[][] tables, int[] data)
        {
            for (int i = 0; i < tables.Length && tables[i] != null; i++)
            {
                var eq = false;
                if (tables[i].Length == data.Length)
                {
                    eq = true;
                    for (int j = 0; j < tables[i].Length; j++)
                        if (tables[i][j] != data[j])
                            eq = false;
                }

                if (eq)
                    return i;
            }
            return -1;
        }

        private static int[] FindFromTables(int[][] tables, int position)
        {
            if (position < 256)
                return new int[] { position };
            var list = new List<int>
            {
                tables[position][0]
            };
            if (tables[position].Length > 1)
                list.Add(tables[position][1]);

            var loop = true;
            while (loop)
            {
                loop = false;

                for (int i = 0; i < list.Count; i++)
                {
                    position = list[i];

                    if (position > 255)
                    {
                        list.Remove(i);
                        for (int j = 0; j < tables[position].Length; j++)
                            list.Insert(i + j, tables[position][j]);
                        loop = true;
                    }
                }
            }
            int[] r = new int[list.Count];
            for (int i = 0; i < r.Length; i++)
                r[i] = list[i];
            return r;
        }

        #endregion
    }
}
