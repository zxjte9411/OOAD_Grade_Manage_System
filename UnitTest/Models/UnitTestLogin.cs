using Microsoft.VisualStudio.TestTools.UnitTesting;
using GradeManageSystem.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace GradeManageSystem.Models.Tests
{
    [TestClass()]
    public class UnitTestLogin
    {
        [TestMethod()]
        public void ValidateUserTest()
        {
            Assert.IsTrue(new Login().ValidateUser("1234", "1234"));
        }
    }
}