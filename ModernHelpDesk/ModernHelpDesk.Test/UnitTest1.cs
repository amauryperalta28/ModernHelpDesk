using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ModernHelpDesk.Common.Models;
using ModernHelpDesk.Library.Helpers;

namespace ModernHelpDesk.Test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void GetAllDivision()
        {
            bool actual = DivisionHelper.GetAll().Count > 0;
            bool expected = true;

            Assert.AreEqual(expected, actual);
        }
    }
}
