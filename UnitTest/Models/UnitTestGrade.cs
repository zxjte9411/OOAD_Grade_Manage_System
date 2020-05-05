using Microsoft.VisualStudio.TestTools.UnitTesting;
using GradeManageSystem.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace GradeManageSystem.Models.Tests
{
    [TestClass()]
    public class UnitTestGrade
    {
        [TestMethod()]
        public void GradeTestConstructor()
        {
            Grade grade = new Grade(50);
            Assert.AreEqual(50, grade.Score);
        }
    }
}