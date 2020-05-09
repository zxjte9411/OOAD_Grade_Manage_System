using Microsoft.VisualStudio.TestTools.UnitTesting;
using GradeManageSystem.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace GradeManageSystem.Models.Tests
{
    [TestClass()]
    public class UnitTestDepartment
    {
        [TestMethod()]
        public void TestConstructor()
        {
            UserInformation userInformation = new UserInformation("test", "0912345678", "AAAA", new DateTime(2000, 7, 15), "男");
            List<Course> courses = new List<Course>();
            courses.Add(new Course("123456", "math", 106, 2));
            courses.Add(new Course("222222", "English", 105, 1));

            Teacher teacher = new Teacher("987654321", "12345", 2, userInformation, courses);
            Administrator administrator = new Administrator("2313", "1111", 1, userInformation);

            List<IAccount> accounts = new List<IAccount>();
            accounts.Add(teacher);
            accounts.Add(administrator);
            Department department = new Department("205", "CS", accounts, courses);

            Assert.AreEqual("205", department.Id);
            Assert.AreEqual("CS", department.Name);
            Assert.AreEqual(teacher, department.Accounts[0]);
            Assert.AreEqual(administrator, department.Accounts[1]);
            Assert.AreEqual(courses, department.Courses);
        }
    }
}