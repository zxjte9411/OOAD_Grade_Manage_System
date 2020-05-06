using Microsoft.VisualStudio.TestTools.UnitTesting;
using GradeManageSystem.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace GradeManageSystem.Models.Tests
{
    [TestClass()]
    public class UnitTestDataInitializer
    {
        [TestMethod()]
        public void InitializeTest()
        {
            DomainController domainController = new DomainController();
            DataInitializer.Initialize(domainController);
        }
    }
}