using Microsoft.VisualStudio.TestTools.UnitTesting;
using GradeManageSystem.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace GradeManageSystem.Models.Tests
{
    [TestClass()]
    public class UnitTestDepartment
    {
        UserInformation userInformation;
        List<Course> courses;
        Dictionary<Course, int> courseGrades1;
        Dictionary<Course, int> courseGrades2;
        Dictionary<Course, int> courseGrades3;
        Student student1;
        Student student2;
        Student student3;
        Teacher teacher;
        Administrator administrator;
        List<Account> accounts;
        Department department;
        AccountModel accountModel;


        [TestInitialize]
        public void TestInitialize()
        {
            userInformation = new UserInformation("test", "0912345678", "AAAA", new DateTime(2000, 7, 15), "男");
            administrator = new Administrator("2313", "1111", 1, userInformation);
            courses = new List<Course>();
            courses.Add(new Course("123456", "math", 106, 2));
            courses.Add(new Course("222222", "English", 105, 1));
            courses.Add(new Course("312412", "test", 108, 1));
            courses.Add(new Course("312412", "test", 107, 1));

            courseGrades1 = new Dictionary<Course, int>();
            courseGrades1.Add(courses[0], 68);
            courseGrades1.Add(courses[1], 73);
            courseGrades1.Add(courses[2], 89);

            courseGrades2 = new Dictionary<Course, int>();
            courseGrades2.Add(courses[2], 39);

            courseGrades3 = new Dictionary<Course, int>();
            courseGrades3.Add(courses[3], 86);

            student1 = new Student("105205001", "123", 3, "3", userInformation, courseGrades1);
            student2 = new Student("105205002", "123", 3, "4", userInformation, courseGrades2);
            student3 = new Student("105205003", "123", 3, "4", userInformation, courseGrades3);
            teacher = new Teacher("123", "wer", 2, userInformation, courses);

            accounts = new List<Account>();
            accounts.Add(student1);
            accounts.Add(student2);
            accounts.Add(student3);
            accounts.Add(teacher);
            accounts.Add(administrator);

            department = new Department("205", "CS", accounts, courses);
            accountModel = new AccountModel("123", "321", 3, userInformation);

            department.CreateAccount(accountModel, 108);
        }

        [TestMethod()]
        public void TestConstructor()
        {
            Assert.AreEqual("205", department.Id);
            Assert.AreEqual("CS", department.Name);
            Assert.AreEqual(teacher, department.Accounts[3]);
            Assert.AreEqual(administrator, department.Accounts[4]);
            Assert.AreEqual(courses, department.Courses);
        }

        [TestMethod()]
        public void TestGetStudentsOfCourse()
        {
            CollectionAssert.AreEqual(accounts.GetRange(0, 1), department.GetStudentsByCourse("222222", null, null));
            CollectionAssert.AreEqual(accounts.GetRange(0, 2), department.GetStudentsByCourse("312412", 108, 1));
        }

        [TestMethod()]
        public void TestGetAccountByAuthority()
        {
            List<Account> testAccounts = accounts.GetRange(0, 3);
            testAccounts.Add(accounts[5]);
            CollectionAssert.AreEqual(testAccounts, department.GetAccountsByAuthority(3));
            CollectionAssert.AreEqual(accounts.GetRange(3, 1), department.GetAccountsByAuthority(2));
        }

        [TestMethod()]
        public void TestIsAccountExist()
        {
            Assert.IsTrue(department.IsAccountExist("108205001"));
            Assert.IsFalse(department.IsAccountExist("adfgd"));
        }

        [TestMethod()]
        public void TestGetAccountById()
        {
            Assert.AreEqual(student1, department.GetAccount("105205001"));
        }

        [TestMethod()]
        public void TestCreateAccount()
        {
            Assert.AreEqual(6, department.Accounts.Count);
            Assert.AreEqual("108205001", department.Accounts[5].Id);
            Assert.AreEqual("108205001", department.Accounts[5].Password);
            Assert.AreEqual(3, department.Accounts[5].Authority);
            Assert.AreEqual(userInformation, department.Accounts[5].UserInformation);
        }
    }
}