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
        [TestMethod()]
        public void TestConstructor()
        {
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

            Assert.AreEqual("205", department.Id);
            Assert.AreEqual("CS", department.Name);
            Assert.AreEqual(teacher, department.Accounts[0]);
            Assert.AreEqual(administrator, department.Accounts[1]);
            Assert.AreEqual(courses, department.Courses);
        }

        [TestMethod()]
        public void TestGetStudentsOfCourse()
        {
            UserInformation userInformation = new UserInformation("test", "0912345678", "AAAA", new DateTime(2000, 7, 15), "男");
            List<Course> courses = new List<Course>();
            courses.Add(new Course("123456", "math", 106, 2));
            courses.Add(new Course("222222", "English", 105, 1));
            courses.Add(new Course("312412", "test", 108, 1));
            courses.Add(new Course("312412", "test", 107, 1));
            Dictionary<Course, int> courseGrades1 = new Dictionary<Course, int>();
            courseGrades1.Add(courses[0], 68);
            courseGrades1.Add(courses[1], 73);
            courseGrades1.Add(courses[2], 89);
            Dictionary<Course, int> courseGrades2 = new Dictionary<Course, int>();
            courseGrades2.Add(courses[2], 39);
            Dictionary<Course, int> courseGrades3 = new Dictionary<Course, int>();
            courseGrades3.Add(courses[3], 86);

            Student student1 = new Student("1", "123", 3, "3", userInformation, courseGrades1);
            Student student2 = new Student("2", "123", 3, "4", userInformation, courseGrades2);
            Student student3 = new Student("3", "123", 3, "4", userInformation, courseGrades3);

            List<IAccount> accounts = new List<IAccount>();
            accounts.Add(student1);
            accounts.Add(student2);
            accounts.Add(student3);
            Department department = new Department("205", "CS", accounts, courses);

            CollectionAssert.AreEqual(accounts.GetRange(0, 1), department.GetStudentsOfCourse("222222", null, null));
            CollectionAssert.AreEqual(accounts.GetRange(0, 2), department.GetStudentsOfCourse("312412", 108, 1));
        }

        [TestMethod()]
        public void TestGetAccountByAuthority()
        {
            UserInformation userInformation = new UserInformation("test", "0912345678", "AAAA", new DateTime(2000, 7, 15), "男");
            List<Course> courses = new List<Course>();
            courses.Add(new Course("123456", "math", 106, 2));
            courses.Add(new Course("222222", "English", 105, 1));
            courses.Add(new Course("312412", "test", 108, 1));
            courses.Add(new Course("312412", "test", 107, 1));
            Dictionary<Course, int> courseGrades1 = new Dictionary<Course, int>();
            courseGrades1.Add(courses[0], 68);
            courseGrades1.Add(courses[1], 73);
            courseGrades1.Add(courses[2], 89);
            Dictionary<Course, int> courseGrades2 = new Dictionary<Course, int>();
            courseGrades2.Add(courses[2], 39);
            Dictionary<Course, int> courseGrades3 = new Dictionary<Course, int>();
            courseGrades3.Add(courses[3], 86);

            Student student1 = new Student("1", "123", 3, "3", userInformation, courseGrades1);
            Student student2 = new Student("2", "123", 3, "4", userInformation, courseGrades2);
            Student student3 = new Student("3", "123", 3, "4", userInformation, courseGrades3);
            Teacher teacher = new Teacher("123", "wer", 2, userInformation, courses);

            List<IAccount> accounts = new List<IAccount>();
            accounts.Add(student1);
            accounts.Add(student2);
            accounts.Add(student3);
            accounts.Add(teacher);

            Department department = new Department("205", "CS", accounts, courses);

            CollectionAssert.AreEqual(accounts.GetRange(0, 3), department.GetAccountByAuthority(3));
            CollectionAssert.AreEqual(accounts.GetRange(3, 1), department.GetAccountByAuthority(2));
        }

        [TestMethod()]
        public void TestIsAccountExist()
        {
            UserInformation userInformation = new UserInformation("test", "0912345678", "AAAA", new DateTime(2000, 7, 15), "男");
            List<Course> courses = new List<Course>();
            courses.Add(new Course("123456", "math", 106, 2));
            courses.Add(new Course("222222", "English", 105, 1));
            courses.Add(new Course("312412", "test", 108, 1));
            courses.Add(new Course("312412", "test", 107, 1));
            Dictionary<Course, int> courseGrades1 = new Dictionary<Course, int>();
            courseGrades1.Add(courses[0], 68);
            courseGrades1.Add(courses[1], 73);
            courseGrades1.Add(courses[2], 89);
            Dictionary<Course, int> courseGrades2 = new Dictionary<Course, int>();
            courseGrades2.Add(courses[2], 39);
            Dictionary<Course, int> courseGrades3 = new Dictionary<Course, int>();
            courseGrades3.Add(courses[3], 86);

            Student student1 = new Student("1", "123", 3, "3", userInformation, courseGrades1);
            Student student2 = new Student("2", "123", 3, "4", userInformation, courseGrades2);
            Student student3 = new Student("3", "123", 3, "4", userInformation, courseGrades3);
            Teacher teacher = new Teacher("123", "wer", 2, userInformation, courses);

            List<IAccount> accounts = new List<IAccount>();
            accounts.Add(student1);
            accounts.Add(student2);
            accounts.Add(student3);
            accounts.Add(teacher);

            Department department = new Department("205", "CS", accounts, courses);

            Assert.IsTrue(department.IsAccountExist("123"));
            Assert.IsFalse(department.IsAccountExist("adfgd"));
        }

        [TestMethod()]
        public void TestGetAccountById()
        {
            UserInformation userInformation = new UserInformation("test", "0912345678", "AAAA", new DateTime(2000, 7, 15), "男");
            List<Course> courses = new List<Course>();
            courses.Add(new Course("123456", "math", 106, 2));
            courses.Add(new Course("222222", "English", 105, 1));
            courses.Add(new Course("312412", "test", 108, 1));
            courses.Add(new Course("312412", "test", 107, 1));
            Dictionary<Course, int> courseGrades1 = new Dictionary<Course, int>();
            courseGrades1.Add(courses[0], 68);
            courseGrades1.Add(courses[1], 73);
            courseGrades1.Add(courses[2], 89);
            Dictionary<Course, int> courseGrades2 = new Dictionary<Course, int>();
            courseGrades2.Add(courses[2], 39);
            Dictionary<Course, int> courseGrades3 = new Dictionary<Course, int>();
            courseGrades3.Add(courses[3], 86);

            Student student1 = new Student("1", "123", 3, "3", userInformation, courseGrades1);
            Student student2 = new Student("2", "123", 3, "4", userInformation, courseGrades2);
            Student student3 = new Student("3", "123", 3, "4", userInformation, courseGrades3);
            Teacher teacher = new Teacher("123", "wer", 2, userInformation, courses);

            List<IAccount> accounts = new List<IAccount>();
            accounts.Add(student1);
            accounts.Add(student2);
            accounts.Add(student3);
            accounts.Add(teacher);

            Department department = new Department("205", "CS", accounts, courses);

            Assert.AreEqual(accounts[1], department.GetAccountById("2"));
        }

        [TestMethod()]
        public void TestCreateAccount()
        {
            UserInformation userInformation = new UserInformation("test", "0912345678", "AAAA", new DateTime(2000, 7, 15), "男");
            List<Course> courses = new List<Course>();
            courses.Add(new Course("123456", "math", 106, 2));
            courses.Add(new Course("222222", "English", 105, 1));
            courses.Add(new Course("312412", "test", 108, 1));
            courses.Add(new Course("312412", "test", 107, 1));
            Dictionary<Course, int> courseGrades1 = new Dictionary<Course, int>();
            courseGrades1.Add(courses[0], 68);
            courseGrades1.Add(courses[1], 73);
            courseGrades1.Add(courses[2], 89);
            Dictionary<Course, int> courseGrades2 = new Dictionary<Course, int>();
            courseGrades2.Add(courses[2], 39);
            Dictionary<Course, int> courseGrades3 = new Dictionary<Course, int>();
            courseGrades3.Add(courses[3], 86);

            Student student1 = new Student("105205001", "123", 3, "3", userInformation, courseGrades1);
            Student student2 = new Student("105205002", "123", 3, "4", userInformation, courseGrades2);
            Student student3 = new Student("105205003", "123", 3, "4", userInformation, courseGrades3);
            Teacher teacher = new Teacher("123", "wer", 2, userInformation, courses);

            List<IAccount> accounts = new List<IAccount>();
            accounts.Add(student1);
            accounts.Add(student2);
            accounts.Add(student3);
            accounts.Add(teacher);

            Department department = new Department("205", "CS", accounts, courses);
            AccountModel accountModel = new AccountModel("123", "321", 3, userInformation);

            department.CreateAccount(accountModel, 108);
            accountModel = new AccountModel("123", "321", 0, userInformation);
            Assert.AreEqual(null, department.CreateAccount(accountModel, 108));

            Assert.AreEqual(5, department.Accounts.Count);
            Assert.AreEqual("108205004", department.Accounts[4].Id);
            Assert.AreEqual("108205004", department.Accounts[4].Password);
            Assert.AreEqual(3, department.Accounts[4].Authority);
            Assert.AreEqual(userInformation, department.Accounts[4].UserInformation);
        }
    }
}