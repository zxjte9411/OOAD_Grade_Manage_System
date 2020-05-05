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
        [TestMethod()]
        public void TeacherTestConstructor()
        {
            UserInformation userInformation = new UserInformation("test", "0912345678", "AAAA", new DateTime(2000, 7, 15), "男");
            List<Course> courses = new List<Course>();
            courses.Add(new Course("123456", "math", 106, 2));
            courses.Add(new Course("222222", "English", 105, 1));

            Teacher teacher = new Teacher("987654321", "12345", 2, userInformation, courses);

            Assert.AreEqual("987654321", teacher.Id);
            Assert.AreEqual("12345", teacher.Password);
            Assert.AreEqual(2, teacher.Authority);
            Assert.AreEqual(userInformation, teacher.UserInformation);
            Assert.AreEqual(courses, teacher.Courses);
        }
    }
}