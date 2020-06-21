using Microsoft.VisualStudio.TestTools.UnitTesting;
using GradeManageSystem.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace GradeManageSystem.Models.Tests
{
    [TestClass()]
    public class UnitTestTeacher
    {
        UserInformation userInformation;
        List<Course> courses;
        Teacher teacher;

        [TestInitialize()]
        public void TestInitialize()
        {
            userInformation = new UserInformation("test", "0912345678", "AAAA", new DateTime(2000, 7, 15), "男");
            courses = new List<Course>();
            courses.Add(new Course("123456", "math", 106, 2));
            courses.Add(new Course("222222", "English", 105, 1));

            teacher = new Teacher("987654321", "12345", 2, userInformation, courses);
        }

        [TestMethod()]
        public void TestConstructor()
        {
            Assert.AreEqual("987654321", teacher.Id);
            Assert.AreEqual("12345", teacher.Password);
            Assert.AreEqual(2, teacher.Authority);
            Assert.AreEqual(userInformation, teacher.UserInformation);
            Assert.AreEqual(courses, teacher.Courses);
        }

        [TestMethod]
        public void TestGetSemesterCourses()
        {
            var rst = new Dictionary<string, string>() { { courses[1].Id, courses[1].Name } };

            CollectionAssert.AreEqual(rst, teacher.GetSemesterCourses(105, 1));
        }
    }
}