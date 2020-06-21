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
        UserInformation userInformation;
        Course course;
        List<Course> courses;
        Dictionary<Course, int> courseGrades;
        Dictionary<string, int> courseGrade;
        Student student;

        [TestInitialize()]
        public void TestInitialize()
        {
            userInformation = new UserInformation("test", "0912345678", "AAAA", new DateTime(2000, 7, 15), "男");
            course = new Course("123456789", "math", 105, 1);
            courses = new List<Course>();
            courses.Add(course);
            int grade = 100;
            courseGrades = new Dictionary<Course, int>();
            courseGrades.Add(course, grade);
            courseGrade = new Dictionary<string, int>();
            courseGrade.Add(course.Id, grade);
            student = new Student("102580039", "123456789", 3, "1", userInformation, courseGrades);
        }

        [TestMethod()]
        public void TestConstructor()
        {
            Student student1 = new Student();

            Assert.AreEqual("102580039", student.Id);
            Assert.AreEqual("123456789", student.Password);
            Assert.AreEqual(3, student.Authority);
            Assert.AreEqual("1", student.Grade);
            Assert.AreEqual(userInformation, student.UserInformation);
            Assert.AreEqual(courseGrade[course.Id], student.CourseScores[course.Id]);
            Assert.AreEqual(courses[0].Id, student.Courses[0].Id);
            Assert.AreEqual(courses[0].Name, student.Courses[0].Name);
        }

        [TestMethod()]
        public void TestSetScore()
        {
            Assert.AreEqual(100, student.CourseScores[course.Id]);

            student.SetScore(course.Id, 0);
            Assert.AreEqual(0, student.CourseScores[course.Id]);
        }

        [TestMethod()]
        public void TestGetCourse()
        {
            Assert.AreEqual(course, student.GetCourse(course.Id));
        }
    }
}