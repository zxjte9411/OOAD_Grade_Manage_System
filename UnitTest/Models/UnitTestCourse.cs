using Microsoft.VisualStudio.TestTools.UnitTesting;
using GradeManageSystem.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace GradeManageSystem.Models.Tests
{
    [TestClass()]
    public class UnitTestCourse
    {
        [TestMethod()]
        public void CourseTestConstructor()
        {
            Course course = new Course("1234", "Internet", 108, 2);

            Assert.AreEqual("1234", course.Id);
            Assert.AreEqual("Internet", course.Name);
            Assert.AreEqual(108, course.Year);
            Assert.AreEqual(2, course.Semester);
        }
    }
}