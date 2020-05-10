using Microsoft.VisualStudio.TestTools.UnitTesting;
using GradeManageSystem.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq.Expressions;

namespace GradeManageSystem.Models.Tests
{
    [TestClass()]
    public class UnitTestAccount
    {
        [TestMethod()]
        public void IsAcadamicAffairTest()
        {
            UserInformation info = new UserInformation("AAA", "0912345678", "AAAA", new DateTime(2000, 7, 15), "男");
            Account acadamicAffairs = new AcadamicAffairs("2313", "1111", 1, info);

            Assert.IsTrue(acadamicAffairs.IsAcadamicAffair());
            Assert.IsFalse(acadamicAffairs.IsStudent());
        }

        [TestMethod()]
        public void IsAdminTest()
        {
            UserInformation info = new UserInformation("AAA", "0912345678", "AAAA", new DateTime(2000, 7, 15), "男");
            Account account = new Administrator("2313", "1111", 0, info);

            Assert.IsTrue(account.IsAdmin());
            Assert.IsFalse(account.IsStudent());
        }

        [TestMethod()]
        public void IsStudentTest()
        {

            UserInformation info = new UserInformation("AAA", "0912345678", "AAAA", new DateTime(2000, 7, 15), "男");
            Dictionary<Course, int> course = new Dictionary<Course, int>() { { new Course("111", "222", 105, 2), 90 } };
            Account account = new Student("2313", "1111", 3, "test", info, course);

            Assert.IsTrue(account.IsStudent());
            Assert.IsFalse(account.IsAdmin());
        }

        [TestMethod()]
        public void IsTeacherTest()
        {
            UserInformation info = new UserInformation("AAA", "0912345678", "AAAA", new DateTime(2000, 7, 15), "男");
            List<Course> courses = new List<Course>();
            courses.Add(new Course("111", "222", 105, 2));
            Account account = new Teacher("2313", "1111", 2, info, courses);

            Assert.IsTrue(account.IsTeacher());
            Assert.IsFalse(account.IsAdmin());
        }

        [TestMethod()]
        public void GetComposedAccountDataTest()
        {
            UserInformation info = new UserInformation("AAA", "0912345678", "AAAA", new DateTime(2000, 7, 15), "男");
            Account account = new Administrator("2313", "1111", 0, info);

            Dictionary<string, string> keyValuePairs = new Dictionary<string, string>()
            {
                { "authority", "0" },
                { "id", "2313" },
                { "token", "1111" }
            };

            CollectionAssert.AreEqual(keyValuePairs, account.GetComposedAccountData("1111"));
        }
    }
}