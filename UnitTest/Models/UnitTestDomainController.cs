using Microsoft.VisualStudio.TestTools.UnitTesting;
using GradeManageSystem.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace GradeManageSystem.Models.Tests
{
    [TestClass()]
    public class UnitTestDomainController
    {
        [TestMethod()]
        public void DomainControllerTestConstructorNoParameters()
        {
            DomainController domainController = new DomainController();

            Assert.IsNotNull(domainController.Departments);
            Assert.IsNotNull(domainController.Login);
        }

        [TestMethod()]
        public void DomainControllerTestConstructor()
        {
            List<Department> departments = new List<Department>();
            UserInformation userInformation = new UserInformation("test", "0912345678", "AAAA", new DateTime(2000, 7, 15), "男");
            List<Course> courses = new List<Course>();
            courses.Add(new Course("123456", "math", 106, 2));
            courses.Add(new Course("222222", "English", 105, 1));

            Teacher teacher = new Teacher("987654321", "12345", 2, userInformation, courses);
            Administrator administrator = new Administrator("2313", "1111", 1, userInformation);

            List<IAccount> accounts = new List<IAccount>();
            accounts.Add(teacher);
            accounts.Add(administrator);
            Department department = new Department("205", "CS", accounts, courses);
            departments.Add(department);

            Login login = new Login();
            DomainController domainController = new DomainController(departments, login);

            Assert.AreEqual(departments, domainController.Departments);
            Assert.AreEqual(login, domainController.Login);
        }
    }
}