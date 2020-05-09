using Microsoft.VisualStudio.TestTools.UnitTesting;
using GradeManageSystem.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json.Bson;

namespace GradeManageSystem.Models.Tests
{
    [TestClass()]
    public class UnitTestAccountModel
    {
        [TestMethod()]
        public void TestConstructor()
        {
            UserInformation userInformation = new UserInformation("BBB", "0912345678", "AAAA", new DateTime(2000, 7, 15), "男");
            AccountModel account = new AccountModel();
            account = new AccountModel("AAA", "123", 1, userInformation);

            Assert.AreEqual("AAA", account.Id);
            Assert.AreEqual("123", account.Password);
            Assert.AreEqual(1, account.Authority);
            Assert.AreEqual(userInformation, account.UserInformation);
        }

        [TestMethod()]
        public void TestIsStudent()
        {
            UserInformation userInformation = new UserInformation("BBB", "0912345678", "AAAA", new DateTime(2000, 7, 15), "男");
            AccountModel account = new AccountModel("AAA", "123", 3, userInformation);

            Assert.IsTrue(account.IsStudent());
        }

        [TestMethod()]
        public void TestIsTeacher()
        {
            UserInformation userInformation = new UserInformation("BBB", "0912345678", "AAAA", new DateTime(2000, 7, 15), "男");
            AccountModel account = new AccountModel("AAA", "123", 2, userInformation);

            Assert.IsTrue(account.IsTeacher());
        }

        [TestMethod()]
        public void TestIsAdmin()
        {
            UserInformation userInformation = new UserInformation("BBB", "0912345678", "AAAA", new DateTime(2000, 7, 15), "男");
            AccountModel account = new AccountModel("AAA", "123", 0, userInformation);

            Assert.IsTrue(account.IsAdmin());
        }

        [TestMethod()]
        public void TestIsAcadamicAffair()
        {
            UserInformation userInformation = new UserInformation("BBB", "0912345678", "AAAA", new DateTime(2000, 7, 15), "男");
            AccountModel account = new AccountModel("AAA", "123", 1, userInformation);

            Assert.IsTrue(account.IsAcadamicAffair());
        }
    }
}