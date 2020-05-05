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
        public void StudentTestConstructor()
        {
            UserInformation info = new UserInformation("test", "0912345678", "AAAA", new DateTime(2000, 7, 15), "男");
            Course course = new Course("123456789", "math", 105, 1);
            Grade grade = new Grade(100);
            Dictionary<Course, Grade> courseGrades = new Dictionary<Course, Grade>();
            courseGrades.Add(course, grade);

            Student student = new Student("102580039", "123456789", 3, info, courseGrades);

            Assert.AreEqual("102580039", student.Id);
            Assert.AreEqual("123456789", student.Password);
            Assert.AreEqual(3, student.Authority);
            Assert.AreEqual(info, student.UserInformation);
            Assert.AreEqual(courseGrades, student.CourseGrades);
        }
    }
}