using GradeManageSystem.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace UnitTest
{
    [TestClass]
    public class UnitTestUserInformation
    {
        [TestMethod]
        public void TestConstructor()
        {
            UserInformation userInformation = new UserInformation("0912345678", "AAAA", new DateTime(2000, 7, 15), "¨k");
            Assert.AreEqual("0912345678", userInformation.Phone);
            Assert.AreEqual("AAAA", userInformation.Address);
            Assert.AreEqual(new DateTime(2000, 7, 15), userInformation.Birthday);
            Assert.AreEqual("¨k", userInformation.Gender);
        }
    }
}
