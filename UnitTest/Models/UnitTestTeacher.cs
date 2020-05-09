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
        public void TestConstructor()
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

        [TestMethod]
        public void TestGetSemesterCourses()
        {
            UserInformation userInformation = new UserInformation("test", "0912345678", "AAAA", new DateTime(2000, 7, 15), "男");
            List<Course> courses = new List<Course>();
            courses.Add(new Course("123456", "math", 106, 2));
            courses.Add(new Course("222222", "English", 105, 1));
            var rst = new Dictionary<string, string>() { { courses[1].Id, courses[1].Name } };

            Teacher teacher = new Teacher("987654321", "12345", 2, userInformation, courses);

            CollectionAssert.AreEqual(rst, teacher.GetSemesterCourses(105, 1));
        }

        [TestMethod()]
        public void TestIsStudent()
        {
            UserInformation userInformation = new UserInformation("test", "0912345678", "AAAA", new DateTime(2000, 7, 15), "男");
            List<Course> courses = new List<Course>();
            courses.Add(new Course("123456", "math", 106, 2));
            courses.Add(new Course("222222", "English", 105, 1));

            Teacher teacher = new Teacher("987654321", "12345", 2, userInformation, courses);

            Assert.IsFalse(teacher.IsStudent());
        }

        [TestMethod()]
        public void TestIsTeacher()
        {
            UserInformation userInformation = new UserInformation("test", "0912345678", "AAAA", new DateTime(2000, 7, 15), "男");
            List<Course> courses = new List<Course>();
            courses.Add(new Course("123456", "math", 106, 2));
            courses.Add(new Course("222222", "English", 105, 1));

            Teacher teacher = new Teacher("987654321", "12345", 2, userInformation, courses);

            Assert.IsTrue(teacher.IsTeacher());
        }

        [TestMethod()]
        public void TestIsAdmin()
        {
            UserInformation userInformation = new UserInformation("test", "0912345678", "AAAA", new DateTime(2000, 7, 15), "男");
            List<Course> courses = new List<Course>();
            courses.Add(new Course("123456", "math", 106, 2));
            courses.Add(new Course("222222", "English", 105, 1));

            Teacher teacher = new Teacher("987654321", "12345", 2, userInformation, courses);

            Assert.IsFalse(teacher.IsAdmin());
        }

        [TestMethod()]
        public void TestIsAcadamicAffair()
        {
            UserInformation userInformation = new UserInformation("test", "0912345678", "AAAA", new DateTime(2000, 7, 15), "男");
            List<Course> courses = new List<Course>();
            courses.Add(new Course("123456", "math", 106, 2));
            courses.Add(new Course("222222", "English", 105, 1));

            Teacher teacher = new Teacher("987654321", "12345", 2, userInformation, courses);

            Assert.IsFalse(teacher.IsAcadamicAffair());
        }
    }
}