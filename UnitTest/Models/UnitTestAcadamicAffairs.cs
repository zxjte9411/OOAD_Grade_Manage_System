using Microsoft.VisualStudio.TestTools.UnitTesting;
using GradeManageSystem.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace GradeManageSystem.Models.Tests
{
    [TestClass()]
    public class UnitTestAcadamicAffairs
    {
        [TestMethod()]
        public void TestConstructor()
        {
            UserInformation info = new UserInformation("AAA", "0912345678", "AAAA", new DateTime(2000, 7, 15), "男");
            AcadamicAffairs acadamicAffairs = new AcadamicAffairs("2313", "1111", 1, info);

            Assert.AreEqual("2313", acadamicAffairs.Id);
            Assert.AreEqual("1111", acadamicAffairs.Password);
            Assert.AreEqual(1, acadamicAffairs.Authority);
            Assert.AreEqual(info, acadamicAffairs.UserInformation);
        }

        [TestMethod()]
        public void TestIsStudent()
        {
            UserInformation userInformation = new UserInformation("BBB", "0912345678", "AAAA", new DateTime(2000, 7, 15), "男");
            AcadamicAffairs account = new AcadamicAffairs("AAA", "123", 1, userInformation);

            Assert.IsFalse(account.IsStudent());
        }

        [TestMethod()]
        public void TestIsTeacher()
        {
            UserInformation userInformation = new UserInformation("BBB", "0912345678", "AAAA", new DateTime(2000, 7, 15), "男");
            AcadamicAffairs account = new AcadamicAffairs("AAA", "123", 1, userInformation);

            Assert.IsFalse(account.IsTeacher());
        }

        [TestMethod()]
        public void TestIsAdmin()
        {
            UserInformation userInformation = new UserInformation("BBB", "0912345678", "AAAA", new DateTime(2000, 7, 15), "男");
            AcadamicAffairs account = new AcadamicAffairs("AAA", "123", 1, userInformation);

            Assert.IsFalse(account.IsAdmin());
        }

        [TestMethod()]
        public void TestIsAcadamicAffair()
        {
            UserInformation userInformation = new UserInformation("BBB", "0912345678", "AAAA", new DateTime(2000, 7, 15), "男");
            AcadamicAffairs account = new AcadamicAffairs("AAA", "123", 1, userInformation);

            Assert.IsTrue(account.IsAcadamicAffair());
        }
    }
}