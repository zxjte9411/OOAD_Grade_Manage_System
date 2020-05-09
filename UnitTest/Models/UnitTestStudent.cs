using Microsoft.VisualStudio.TestTools.UnitTesting;
using GradeManageSystem.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace GradeManageSystem.Models.Tests
{
    [TestClass()]
    public class UnitTestStudent
    {
        [TestMethod()]
        public void TestConstructor()
        {
            Student student1 = new Student();
            UserInformation info = new UserInformation("test", "0912345678", "AAAA", new DateTime(2000, 7, 15), "男");
            Course course = new Course("123456789", "math", 105, 1);
            List<Course> courses = new List<Course>();
            courses.Add(course);
            int grade = 100;
            Dictionary<Course, int> courseGrades = new Dictionary<Course, int>();
            courseGrades.Add(course, grade);
            Dictionary<string, int> courseGrade = new Dictionary<string, int>();
            courseGrade.Add(course.Id, grade);
            Student student = new Student("102580039", "123456789", 3, "1", info, courseGrades);

            Assert.AreEqual("102580039", student.Id);
            Assert.AreEqual("123456789", student.Password);
            Assert.AreEqual(3, student.Authority);
            Assert.AreEqual("1", student.Grade);
            Assert.AreEqual(info, student.UserInformation);
            Assert.AreEqual(courseGrade[course.Id], student.CourseGrades[course.Id]);
            Assert.AreEqual(courses[0].Id, student.Courses[0].Id);
            Assert.AreEqual(courses[0].Name, student.Courses[0].Name);
        }

        [TestMethod()]
        public void TestSetScore()
        {
            UserInformation userInformation = new UserInformation("BBB", "0912345678", "AAAA", new DateTime(2000, 7, 15), "男");
            Course course = new Course("123456789", "math", 105, 1);
            List<Course> courses = new List<Course>();
            courses.Add(course);
            int grade = 100;
            Dictionary<Course, int> courseGrades = new Dictionary<Course, int>();
            courseGrades.Add(course, grade);
            Dictionary<string, int> courseGrade = new Dictionary<string, int>();
            courseGrade.Add(course.Id, grade);
            Student student = new Student("102580039", "123456789", 3, "1", userInformation, courseGrades);

            Assert.AreEqual(100, student.CourseGrades[course.Id]);

            student.SetScore(course.Id, 0);
            Assert.AreEqual(0, student.CourseGrades[course.Id]);
        }

        [TestMethod()]
        public void TestGetCourse()
        {
            UserInformation userInformation = new UserInformation("BBB", "0912345678", "AAAA", new DateTime(2000, 7, 15), "男");
            Course course = new Course("123456789", "math", 105, 1);
            List<Course> courses = new List<Course>();
            courses.Add(course);
            int grade = 100;
            Dictionary<Course, int> courseGrades = new Dictionary<Course, int>();
            courseGrades.Add(course, grade);
            Student student = new Student("102580039", "123456789", 3, "1", userInformation, courseGrades);

            Assert.AreEqual(course, student.GetCourse(course.Id));
        }

        [TestMethod()]
        public void TestIsStudent()
        {
            UserInformation userInformation = new UserInformation("BBB", "0912345678", "AAAA", new DateTime(2000, 7, 15), "男");
            Course course = new Course("123456789", "math", 105, 1);
            List<Course> courses = new List<Course>();
            courses.Add(course);
            int grade = 100;
            Dictionary<Course, int> courseGrades = new Dictionary<Course, int>();
            courseGrades.Add(course, grade);
            Student student = new Student("102580039", "123456789", 3, "1", userInformation, courseGrades);

            Assert.IsTrue(student.IsStudent());
        }

        [TestMethod()]
        public void TestIsTeacher()
        {
            UserInformation userInformation = new UserInformation("BBB", "0912345678", "AAAA", new DateTime(2000, 7, 15), "男");
            Course course = new Course("123456789", "math", 105, 1);
            List<Course> courses = new List<Course>();
            courses.Add(course);
            int grade = 100;
            Dictionary<Course, int> courseGrades = new Dictionary<Course, int>();
            courseGrades.Add(course, grade);
            Student student = new Student("102580039", "123456789", 3, "1", userInformation, courseGrades);

            Assert.IsFalse(student.IsTeacher());
        }

        [TestMethod()]
        public void TestIsAdmin()
        {
            UserInformation userInformation = new UserInformation("BBB", "0912345678", "AAAA", new DateTime(2000, 7, 15), "男");
            Course course = new Course("123456789", "math", 105, 1);
            List<Course> courses = new List<Course>();
            courses.Add(course);
            int grade = 100;
            Dictionary<Course, int> courseGrades = new Dictionary<Course, int>();
            courseGrades.Add(course, grade);
            Student student = new Student("102580039", "123456789", 3, "1", userInformation, courseGrades);

            Assert.IsFalse(student.IsAdmin());
        }

        [TestMethod()]
        public void TestIsAcadamicAffair()
        {
            UserInformation userInformation = new UserInformation("BBB", "0912345678", "AAAA", new DateTime(2000, 7, 15), "男");
            Course course = new Course("123456789", "math", 105, 1);
            List<Course> courses = new List<Course>();
            courses.Add(course);
            int grade = 100;
            Dictionary<Course, int> courseGrades = new Dictionary<Course, int>();
            courseGrades.Add(course, grade);
            Student student = new Student("102580039", "123456789", 3, "1", userInformation, courseGrades);

            Assert.IsFalse(student.IsAcadamicAffair());
        }
    }
}