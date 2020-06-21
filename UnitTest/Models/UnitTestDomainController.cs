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
        List<Department> departments;
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
        Login login;
        List<Dictionary<string, string>> gradeList;
        DomainController domainController;
        Dictionary<string, string> students;


        [TestInitialize()]
        public void TestInitialize()
        {
            departments = new List<Department>();
            userInformation = new UserInformation("test", "0912345678", "AAAA", new DateTime(2000, 7, 15), "男");
            courses = new List<Course>();
            courses.Add(new Course("123456", "math", 106, 2));
            courses.Add(new Course("222222", "English", 105, 1));
            courses.Add(new Course("312412", "test", 108, 1));
            courses.Add(new Course("312412", "test", 107, 1));
            courses.Add(new Course("235463", "test2", 108, 2));
            courseGrades1 = new Dictionary<Course, int>();
            courseGrades1.Add(courses[0], 68);
            courseGrades1.Add(courses[1], 73);
            courseGrades1.Add(courses[2], 89);
            courseGrades2 = new Dictionary<Course, int>();
            courseGrades2.Add(courses[2], 39);
            courseGrades2.Add(courses[4], 75);
            courseGrades3 = new Dictionary<Course, int>();
            courseGrades3.Add(courses[3], 86);
            courseGrades3.Add(courses[4], 75);

            student1 = new Student("105890031", "123", 3, "3", userInformation, courseGrades1);
            student2 = new Student("106680015", "123", 3, "4", userInformation, courseGrades2);
            student3 = new Student("108205001", "123", 3, "4", userInformation, courseGrades3);
            teacher = new Teacher("556888", "wer", 2, userInformation, courses);
            administrator = new Administrator("000000", "1111", 0, userInformation);

            accounts = new List<Account>();
            accounts.Add(student1);
            accounts.Add(student2);
            accounts.Add(student3);
            accounts.Add(teacher);
            accounts.Add(administrator);
            department = new Department("205", "CS", accounts, courses);
            departments.Add(department);

            gradeList = new List<Dictionary<string, string>>();
            Dictionary<string, string> keyValuePairs = new Dictionary<string, string>();
            keyValuePairs.Add("course_id", courses[3].Id.ToString());
            keyValuePairs.Add("course_name", courses[3].Name.ToString());
            keyValuePairs.Add("score", courseGrades3[courses[3]].ToString());
            keyValuePairs.Add("year", courses[3].Year.ToString());
            keyValuePairs.Add("semester", courses[3].Semester.ToString());
            gradeList.Add(keyValuePairs);
            keyValuePairs = new Dictionary<string, string>();
            keyValuePairs.Add("course_id", courses[4].Id.ToString());
            keyValuePairs.Add("course_name", courses[4].Name.ToString());
            keyValuePairs.Add("score", courseGrades3[courses[4]].ToString());
            keyValuePairs.Add("year", courses[4].Year.ToString());
            keyValuePairs.Add("semester", courses[4].Semester.ToString());
            gradeList.Add(keyValuePairs);

            login = new Login();
            domainController = new DomainController(departments, login);
        }

        [TestMethod()]
        public void DomainControllerTestConstructorNoParameters()
        {
            Assert.IsNotNull(domainController.Departments);
            Assert.IsNotNull(domainController.Login);
        }

        [TestMethod()]
        public void DomainControllerTestConstructor()
        {
            Assert.AreEqual(departments, domainController.Departments);
            Assert.AreEqual(login, domainController.Login);
        }

        [TestMethod()]
        public void TestGetTeacher()
        {
            Assert.AreEqual(teacher, domainController.GetAccount("556888"));
            Assert.AreEqual(null, domainController.GetAccount("12345"));
        }

        [TestMethod()]
        public void TestGetTeacherCoursesLastSemester()
        {
            CollectionAssert.AreEqual(new Dictionary<string, string> { { "235463", "test2" } }
            , domainController.GetTeacherLastSemesterCourses("556888"));
            Assert.AreEqual(null, domainController.GetTeacherLastSemesterCourses("4356"));
        }

        [TestMethod()]
        public void TestGetAllDepartmentsIdName()
        {
            CollectionAssert.AreEqual(new Dictionary<string, string> { { "205", "CS" } }
            , domainController.GetDepartmentsIdName());
        }

        [TestMethod()]
        public void TestGetStudentAllGradeList()
        {
            CollectionAssert.AreEqual(gradeList[0], domainController.GetStudentHistoryScores("108205001")[0]);
            CollectionAssert.AreEqual(gradeList[1], domainController.GetStudentHistoryScores("108205001")[1]);
        }

        [TestMethod()]
        public void TestGetCourseGradeList()
        {
            Dictionary<string, string> keyValuePairs = new Dictionary<string, string>();
            Student student = (Student)accounts[0];
            keyValuePairs.Add("id", student.Id.ToString());
            keyValuePairs.Add("name", student.UserInformation.Name.ToString());
            keyValuePairs.Add("department_name", department.Name.ToString());
            keyValuePairs.Add("grade", student.Grade.ToString());
            keyValuePairs.Add("score", student.CourseScores["312412"].ToString());
            keyValuePairs.Add("year", student.GetCourse("312412").Year.ToString());
            keyValuePairs.Add("semester", student.GetCourse("312412").Semester.ToString());
            gradeList.Add(keyValuePairs);

            keyValuePairs = new Dictionary<string, string>();
            student = (Student)accounts[2];
            keyValuePairs.Add("id", student.Id.ToString());
            keyValuePairs.Add("name", student.UserInformation.Name.ToString());
            keyValuePairs.Add("department_name", department.Name.ToString());
            keyValuePairs.Add("grade", student.Grade.ToString());
            keyValuePairs.Add("score", student.CourseScores["312412"].ToString());
            keyValuePairs.Add("year", student.GetCourse("312412").Year.ToString());
            keyValuePairs.Add("semester", student.GetCourse("312412").Semester.ToString());
            gradeList.Add(keyValuePairs);

            CollectionAssert.AreEqual(gradeList[2], domainController.GetScoreTableByCourse("312412", null, null)[0]);
            CollectionAssert.AreEqual(gradeList[3], domainController.GetScoreTableByCourse("312412", 107, 1)[0]);
        }

        [TestMethod()]
        public void TestUpdateStudentsGrade()
        {
            Dictionary<string, string> grades = new Dictionary<string, string>();
            grades.Add("106680015", "0");
            grades.Add("108205001", "0");

            domainController.UpdateCourseScoreTable("235463", grades);

            Assert.AreEqual(0, student2.CourseScores["235463"]);
            Assert.AreEqual(0, student3.CourseScores["235463"]);
        }

        [TestMethod()]
        public void TestCreateAccount()
        {
            AccountModel accountModel = new AccountModel("123", "321", 3, userInformation);
            domainController.CreateAccount(accountModel, "205");

            Assert.AreEqual(6, department.Accounts.Count);
            Assert.AreEqual("108205002", department.Accounts[5].Id);
            Assert.AreEqual("108205002", department.Accounts[5].Password);
            Assert.AreEqual(3, department.Accounts[5].Authority);
            Assert.AreEqual(userInformation, department.Accounts[5].UserInformation);
        }

        [TestMethod()]
        public void TestGetTeacherCourse()
        {
            CollectionAssert.AreEqual(courses, domainController.GetTeacherCourses("556888"));
        }

        [TestMethod()]
        public void TestUpdateUserInformationOfDepartment()
        {
            UserInformation userInformation2 = new UserInformation("AAAA", "0912345678", "AAAA", new DateTime(2000, 7, 15), "男");

            Assert.AreEqual(userInformation, domainController.GetAccount("556888").UserInformation);
            domainController.UpdateUserInformationByDepartment("205", "556888", userInformation2);
            Assert.AreEqual(userInformation2, domainController.GetAccount("556888").UserInformation);
        }

        [TestMethod()]
        public void SignInTest()
        {
            Administrator test = new Administrator("sdf", "1111", 0, userInformation);
            Dictionary<string, string> keyValuePairs = new Dictionary<string, string>()
            {
                { "authority", "2" },
                { "id", "556888" },
                { "token", "wer" }
            };

            CollectionAssert.AreEqual(keyValuePairs, domainController.SignIn(teacher, "wer"));
            Assert.AreEqual(null, domainController.SignIn(test, "aaa"));
        }
    }
}