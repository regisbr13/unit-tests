using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyClasses;

namespace MyClassesTest
{
    [TestClass]
    public class AssertClassTest
    {
        #region AreEqual/AreNotEqual Tests
        [TestMethod]
        public void AreEqualTest()
        {
            string str1 = "AccessOne";
            string str2 = "accessOne";
            //Assert.AreEqual(str1, str2);
            Assert.AreNotEqual(str1, str2);
        }
        #endregion

        #region AreSame/AreNotSame Tests
        [TestMethod]
        public void AreSameTest()
        {
            var x = new FileProcess();
            var y = x;
            Assert.AreSame(x, y);
            //Assert.AreNotSame(x, y);
        }
        #endregion
    }
}
