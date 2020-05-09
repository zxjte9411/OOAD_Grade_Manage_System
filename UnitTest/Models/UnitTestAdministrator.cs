using Microsoft.VisualStudio.TestTools.UnitTesting;
using GradeManageSystem.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace GradeManageSystem.Models.Tests
{
    [TestClass()]
    public class UnitTestAdministrator
    {
        [TestMethod()]
        public void TestConstructor()
        {
            UserInformation info = new UserInformation("BBB", "0912345678", "AAAA", new DateTime(2000, 7, 15), "男");
            Administrator administrator = new Administrator("2313", "1111", 1, info);

            Assert.AreEqual("2313", administrator.Id);
            Assert.AreEqual("1111", administrator.Password);
            Assert.AreEqual(1, administrator.Authority);
            Assert.AreEqual(info, administrator.UserInformation);
        }

        [TestMethod()]
        public void TestIsStudent()
        {
            UserInformation userInformation = new UserInformation("BBB", "0912345678", "AAAA", new DateTime(2000, 7, 15), "男");
            Administrator account = new Administrator("AAA", "123", 0, userInformation);

            Assert.IsFalse(account.IsStudent());
        }

        [TestMethod()]
        public void TestIsTeacher()
        {
            UserInformation userInformation = new UserInformation("BBB", "0912345678", "AAAA", new DateTime(2000, 7, 15), "男");
            Administrator account = new Administrator("AAA", "123", 0, userInformation);

            Assert.IsFalse(account.IsTeacher());
        }

        [TestMethod()]
        public void TestIsAdmin()
        {
            UserInformation userInformation = new UserInformation("BBB", "0912345678", "AAAA", new DateTime(2000, 7, 15), "男");
            Administrator account = new Administrator("AAA", "123", 0, userInformation);

            Assert.IsTrue(account.IsAdmin());
        }

        [TestMethod()]
        public void TestIsAcadamicAffair()
        {
            UserInformation userInformation = new UserInformation("BBB", "0912345678", "AAAA", new DateTime(2000, 7, 15), "男");
            Administrator account = new Administrator("AAA", "123", 0, userInformation);

            Assert.IsFalse(account.IsAcadamicAffair());
        }
    }
}