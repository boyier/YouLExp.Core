using Microsoft.VisualStudio.TestTools.UnitTesting;
using YouLExp.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace YouLExp.Core.Tests
{
    [TestClass()]
    public class DateTimeExtendTests
    {
        [TestMethod()]
        public void ToWeekOfYearTest()
        {
            var val = new DateTime(2021, 1, 1).ToWeekOfYear();
            Assert.AreEqual(val, 0);
            val = new DateTime(2021, 4, 19).ToWeekOfYear();
            Assert.AreEqual(val, 16);
        }
    }
}