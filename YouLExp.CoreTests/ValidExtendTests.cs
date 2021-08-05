using Microsoft.VisualStudio.TestTools.UnitTesting;
using YouLExp.Core;
using System;
using System.Collections.Generic;
using System.Text;
using YouLExp.Core.Utils;
using YouLExp.Core.Data;
using System.Linq;

namespace YouLExp.Core.Tests
{
    [TestClass()]
    public class ValidExtendTests
    {
        [TestMethod()]
        public void IsValidCarNoExTest()
        {
            var issuccess = "鲁A12345F".IsValidCarNo();
            Assert.IsTrue(issuccess);
            issuccess = "测1231231".IsValidCarNo();
            Assert.IsFalse(issuccess);
        }

        [TestMethod()]
        public void IsValidEmailAddressTest()
        {
            var issuccess = "text_waw12@163.com".IsValidEmailAddress();
            Assert.IsTrue(issuccess);
            issuccess = "12312312wajhfwaf".IsValidEmailAddress();
            Assert.IsFalse(issuccess);
        }

        [TestMethod()]
        public void GetCNCharSpellTest()
        {
            //var zz = "测试账号".GetCNCharSpell();
            //Assert.AreEqual(zz,"CSZH");
            //zz = "测"[0].GetCNCharSpell();
            //Assert.AreEqual(zz, "C");
            //zz = "A,账号？?!.。这是）（()【】{}[]jh".GetCNCharSpell();
            //Assert.AreEqual(zz, "A,ZH??!.?ZS??()??{}[]JH");

            var zz = "亳漯濮衢儋".GetChineseSpell();
            Assert.AreEqual(zz, "BLPQD");
            zz = "佛宿长重".GetChineseSpell();
            Assert.AreEqual(zz, "FSCC");
        }

        [TestMethod()]
        public void LZWTest()
        {
            //string str = string.Join(",", StringExtComm.ChineseCharList);

            //List<int[]> codess = new List<int[]>();
            //int[] intss;

            //foreach (var item in CHExtComm.ChineseCharList)
            //{
            //    codess.Add(LZW.EnLZW(Encoding.Default.GetBytes(item)));
            //}

            //List<byte[]> code = new List<byte[]>();

            //foreach (var item in codess)
            //{
            //    code.Add(LZW.UnLZW(item));
            //}

            //string[] newstr = new string[codess.Count];

            //for (int i = 0; i < newstr.Length; i++)
            //{
            //    newstr[i] = Encoding.Default.GetString(code[i]);
            //}

            ////验证
            //for (int i = 0; i < CHExtComm.ChineseCharList.Length; i++)
            //{
            //    Assert.AreEqual(CHExtComm.ChineseCharList[i], newstr[i]);
            //}

            //int max = codess.Max(q => q.Length);

            ////测试成功
            //var sss = newstr;
            //string sstr = codess.Select(s => $"new int[]{{{string.Join(",", s)}}}").ToStringJoin(",\n");

        }
    }
}