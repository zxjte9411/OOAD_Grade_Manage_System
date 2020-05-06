using Microsoft.VisualStudio.TestTools.UnitTesting;
using GradeManageSystem.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace GradeManageSystem.Models.Tests
{
    [TestClass()]
    public class UnitTestAcadamicAffairs
    {
        [TestMethod()]
        public void AcadamicAffairsTestConstructor()
        {
            UserInformation info = new UserInformation("AAA", "0912345678", "AAAA", new DateTime(2000, 7, 15), "男");
            AcadamicAffairs acadamicAffairs = new AcadamicAffairs("2313", "1111", 1, info);

            Assert.AreEqual("2313", acadamicAffairs.Id);
            Assert.AreEqual("1111", acadamicAffairs.Password);
            Assert.AreEqual(1, acadamicAffairs.Authority);
            Assert.AreEqual(info, acadamicAffairs.UserInformation);
        }
    }
}