using Microsoft.VisualStudio.TestTools.UnitTesting;
using YouLExp.Core;
using System;
using System.Collections.Generic;
using System.Text;

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
    }
}