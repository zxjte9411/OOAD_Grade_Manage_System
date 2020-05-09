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

        [TestMethod()]
        public void TestGetTeacher()
        {
            List<Department> departments = new List<Department>();
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
            Administrator administrator = new Administrator("2313", "1111", 1, userInformation);            

            List<IAccount> accounts = new List<IAccount>();
            accounts.Add(teacher);
            accounts.Add(administrator);
            accounts.Add(student1);
            accounts.Add(student2);
            accounts.Add(student3);
            Department department = new Department("205", "CS", accounts, courses);
            departments.Add(department);

            DomainController domainController = new DomainController(departments, new Login());

            Assert.AreEqual(teacher, domainController.GetAccount("123"));
            Assert.AreEqual(null, domainController.GetAccount("4356"));
        }

        [TestMethod()]
        public void TestGetTeacherCoursesLastSemester()
        {
            List<Department> departments = new List<Department>();
            UserInformation userInformation = new UserInformation("test", "0912345678", "AAAA", new DateTime(2000, 7, 15), "男");
            List<Course> courses = new List<Course>();
            courses.Add(new Course("123456", "math", 106, 2));
            courses.Add(new Course("222222", "English", 105, 1));
            courses.Add(new Course("312412", "test", 108, 1));
            courses.Add(new Course("312412", "test", 107, 1));
            courses.Add(new Course("235463", "test2", 108, 2));
            Dictionary<Course, int> courseGrades1 = new Dictionary<Course, int>();
            courseGrades1.Add(courses[0], 68);
            courseGrades1.Add(courses[1], 73);
            courseGrades1.Add(courses[2], 89);
            Dictionary<Course, int> courseGrades2 = new Dictionary<Course, int>();
            courseGrades2.Add(courses[2], 39);
            Dictionary<Course, int> courseGrades3 = new Dictionary<Course, int>();
            courseGrades3.Add(courses[3], 86);
            courseGrades3.Add(courses[4], 75);

            Student student1 = new Student("1", "123", 3, "3", userInformation, courseGrades1);
            Student student2 = new Student("2", "123", 3, "4", userInformation, courseGrades2);
            Student student3 = new Student("3", "123", 3, "4", userInformation, courseGrades3);
            Teacher teacher = new Teacher("123", "wer", 2, userInformation, courses);
            Administrator administrator = new Administrator("2313", "1111", 1, userInformation);

            List<IAccount> accounts = new List<IAccount>();
            accounts.Add(teacher);
            accounts.Add(administrator);
            accounts.Add(student1);
            accounts.Add(student2);
            accounts.Add(student3);
            Department department = new Department("205", "CS", accounts, courses);
            departments.Add(department);

            DomainController domainController = new DomainController(departments, new Login());

            CollectionAssert.AreEqual(new Dictionary<string, string> { { "235463", "test2" } }
            , domainController.GetTeacherCoursesLastSemester("123"));
            Assert.AreEqual(null, domainController.GetTeacherCoursesLastSemester("4356"));
        }

        [TestMethod()]
        public void TestGetAllDepartmentsIdName()
        {
            List<Department> departments = new List<Department>();
            UserInformation userInformation = new UserInformation("test", "0912345678", "AAAA", new DateTime(2000, 7, 15), "男");
            List<Course> courses = new List<Course>();
            courses.Add(new Course("123456", "math", 106, 2));
            courses.Add(new Course("222222", "English", 105, 1));
            courses.Add(new Course("312412", "test", 108, 1));
            courses.Add(new Course("312412", "test", 107, 1));
            courses.Add(new Course("235463", "test2", 108, 2));
            Dictionary<Course, int> courseGrades1 = new Dictionary<Course, int>();
            courseGrades1.Add(courses[0], 68);
            courseGrades1.Add(courses[1], 73);
            courseGrades1.Add(courses[2], 89);
            Dictionary<Course, int> courseGrades2 = new Dictionary<Course, int>();
            courseGrades2.Add(courses[2], 39);
            Dictionary<Course, int> courseGrades3 = new Dictionary<Course, int>();
            courseGrades3.Add(courses[3], 86);
            courseGrades3.Add(courses[4], 75);

            Student student1 = new Student("1", "123", 3, "3", userInformation, courseGrades1);
            Student student2 = new Student("2", "123", 3, "4", userInformation, courseGrades2);
            Student student3 = new Student("3", "123", 3, "4", userInformation, courseGrades3);
            Teacher teacher = new Teacher("123", "wer", 2, userInformation, courses);
            Administrator administrator = new Administrator("2313", "1111", 1, userInformation);

            List<IAccount> accounts = new List<IAccount>();
            accounts.Add(teacher);
            accounts.Add(administrator);
            accounts.Add(student1);
            accounts.Add(student2);
            accounts.Add(student3);
            Department department = new Department("205", "CS", accounts, courses);
            departments.Add(department);

            DomainController domainController = new DomainController(departments, new Login());

            CollectionAssert.AreEqual(new Dictionary<string, string> { { "205", "CS" } }
            , domainController.GetAllDepartmentsIdName());
        }

        [TestMethod()]
        public void TestGetStudentAllGradeList()
        {
            List<Department> departments = new List<Department>();
            UserInformation userInformation = new UserInformation("test", "0912345678", "AAAA", new DateTime(2000, 7, 15), "男");
            List<Course> courses = new List<Course>();
            courses.Add(new Course("123456", "math", 106, 2));
            courses.Add(new Course("222222", "English", 105, 1));
            courses.Add(new Course("312412", "test", 108, 1));
            courses.Add(new Course("312412", "test", 107, 1));
            courses.Add(new Course("235463", "test2", 108, 2));
            Dictionary<Course, int> courseGrades1 = new Dictionary<Course, int>();
            courseGrades1.Add(courses[0], 68);
            courseGrades1.Add(courses[1], 73);
            courseGrades1.Add(courses[2], 89);
            Dictionary<Course, int> courseGrades2 = new Dictionary<Course, int>();
            courseGrades2.Add(courses[2], 39);
            Dictionary<Course, int> courseGrades3 = new Dictionary<Course, int>();
            courseGrades3.Add(courses[3], 86);
            courseGrades3.Add(courses[4], 75);

            Student student1 = new Student("1", "123", 3, "3", userInformation, courseGrades1);
            Student student2 = new Student("2", "123", 3, "4", userInformation, courseGrades2);
            Student student3 = new Student("3", "123", 3, "4", userInformation, courseGrades3);
            Teacher teacher = new Teacher("123", "wer", 2, userInformation, courses);
            Administrator administrator = new Administrator("2313", "1111", 1, userInformation);

            List<IAccount> accounts = new List<IAccount>();
            accounts.Add(teacher);
            accounts.Add(administrator);
            accounts.Add(student1);
            accounts.Add(student2);
            accounts.Add(student3);
            Department department = new Department("205", "CS", accounts, courses);
            departments.Add(department);

            DomainController domainController = new DomainController(departments, new Login());

            List<Dictionary<string, string>> gradeList = new List<Dictionary<string, string>>();
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

            CollectionAssert.AreEqual(gradeList[0], domainController.GetStudentAllGradeList("3")[0]);
            CollectionAssert.AreEqual(gradeList[1], domainController.GetStudentAllGradeList("3")[1]);
        }

        [TestMethod()]
        public void TestGetCourseGradeList()
        {
            List<Department> departments = new List<Department>();
            UserInformation userInformation = new UserInformation("test", "0912345678", "AAAA", new DateTime(2000, 7, 15), "男");
            List<Course> courses = new List<Course>();
            courses.Add(new Course("123456", "math", 106, 2));
            courses.Add(new Course("222222", "English", 105, 1));
            courses.Add(new Course("312412", "test", 108, 1));
            courses.Add(new Course("312412", "test", 107, 1));
            courses.Add(new Course("235463", "test2", 108, 2));
            Dictionary<Course, int> courseGrades1 = new Dictionary<Course, int>();
            courseGrades1.Add(courses[0], 68);
            courseGrades1.Add(courses[1], 73);
            courseGrades1.Add(courses[2], 89);
            Dictionary<Course, int> courseGrades2 = new Dictionary<Course, int>();
            courseGrades2.Add(courses[2], 39);
            Dictionary<Course, int> courseGrades3 = new Dictionary<Course, int>();
            courseGrades3.Add(courses[3], 86);
            courseGrades3.Add(courses[4], 75);

            Student student1 = new Student("1", "123", 3, "3", userInformation, courseGrades1);
            Student student2 = new Student("2", "123", 3, "4", userInformation, courseGrades2);
            Student student3 = new Student("3", "123", 3, "4", userInformation, courseGrades3);
            Teacher teacher = new Teacher("123", "wer", 2, userInformation, courses);
            Administrator administrator = new Administrator("2313", "1111", 1, userInformation);

            List<IAccount> accounts = new List<IAccount>();
            accounts.Add(teacher);
            accounts.Add(administrator);
            accounts.Add(student1);
            accounts.Add(student2);
            accounts.Add(student3);
            Department department = new Department("205", "CS", accounts, courses);
            departments.Add(department);

            DomainController domainController = new DomainController(departments, new Login());

            List<Dictionary<string, string>> gradeList = new List<Dictionary<string, string>>();
            Dictionary<string, string> keyValuePairs = new Dictionary<string, string>();
            Student student = (Student)accounts[2];
            keyValuePairs.Add("id", student.Id.ToString());
            keyValuePairs.Add("name", student.UserInformation.Name.ToString());
            keyValuePairs.Add("department_name", department.Name.ToString());
            keyValuePairs.Add("grade", student.Grade.ToString());
            keyValuePairs.Add("score", student.CourseGrades["312412"].ToString());
            keyValuePairs.Add("year", student.GetCourse("312412").Year.ToString());
            keyValuePairs.Add("semester", student.GetCourse("312412").Semester.ToString());
            gradeList.Add(keyValuePairs);

            keyValuePairs = new Dictionary<string, string>();
            student = (Student)accounts[3];
            keyValuePairs.Add("id", student.Id.ToString());
            keyValuePairs.Add("name", student.UserInformation.Name.ToString());
            keyValuePairs.Add("department_name", department.Name.ToString());
            keyValuePairs.Add("grade", student.Grade.ToString());
            keyValuePairs.Add("score", student.CourseGrades["312412"].ToString());
            keyValuePairs.Add("year", student.GetCourse("312412").Year.ToString());
            keyValuePairs.Add("semester", student.GetCourse("312412").Semester.ToString());
            gradeList.Add(keyValuePairs);

            keyValuePairs = new Dictionary<string, string>();
            student = (Student)accounts[4];
            keyValuePairs.Add("id", student.Id.ToString());
            keyValuePairs.Add("name", student.UserInformation.Name.ToString());
            keyValuePairs.Add("department_name", department.Name.ToString());
            keyValuePairs.Add("grade", student.Grade.ToString());
            keyValuePairs.Add("score", student.CourseGrades["312412"].ToString());
            keyValuePairs.Add("year", student.GetCourse("312412").Year.ToString());
            keyValuePairs.Add("semester", student.GetCourse("312412").Semester.ToString());
            gradeList.Add(keyValuePairs);

            CollectionAssert.AreEqual(gradeList[0], domainController.GetCourseGradeList("312412", null, null)[0]);
            CollectionAssert.AreEqual(gradeList[2], domainController.GetCourseGradeList("312412", 107, 1)[0]);
        }

        [TestMethod()]
        public void TestUpdateStudentsGrade()
        {
            List<Department> departments = new List<Department>();
            UserInformation userInformation = new UserInformation("test", "0912345678", "AAAA", new DateTime(2000, 7, 15), "男");
            List<Course> courses = new List<Course>();
            courses.Add(new Course("123456", "math", 106, 2));
            courses.Add(new Course("222222", "English", 105, 1));
            courses.Add(new Course("312412", "test", 108, 1));
            courses.Add(new Course("312412", "test", 107, 1));
            courses.Add(new Course("235463", "test2", 108, 2));
            Dictionary<Course, int> courseGrades1 = new Dictionary<Course, int>();
            courseGrades1.Add(courses[0], 68);
            courseGrades1.Add(courses[1], 73);
            courseGrades1.Add(courses[2], 89);
            Dictionary<Course, int> courseGrades2 = new Dictionary<Course, int>();
            courseGrades2.Add(courses[2], 39);
            courseGrades2.Add(courses[4], 75);
            Dictionary<Course, int> courseGrades3 = new Dictionary<Course, int>();
            courseGrades3.Add(courses[3], 86);
            courseGrades3.Add(courses[4], 75);

            Student student1 = new Student("1", "123", 3, "3", userInformation, courseGrades1);
            Student student2 = new Student("2", "123", 3, "4", userInformation, courseGrades2);
            Student student3 = new Student("3", "123", 3, "4", userInformation, courseGrades3);

            List<IAccount> accounts = new List<IAccount>();
            accounts.Add(student1);
            accounts.Add(student2);
            accounts.Add(student3);
            Department department = new Department("205", "CS", accounts, courses);
            departments.Add(department);

            DomainController domainController = new DomainController(departments, new Login());

            Dictionary<string, string> students = new Dictionary<string, string>();
            students.Add("2", "0");
            students.Add("3", "0");
            try
            {
                students.Add("3", "dagd");
            }
            catch { }

            domainController.UpdateStudentsGrade("235463", students);

            Assert.AreEqual(0, student2.CourseGrades["235463"]);
            Assert.AreEqual(0, student3.CourseGrades["235463"]);
        }

        [TestMethod()]
        public void TestCreateAccount()
        {
            List<Department> departments = new List<Department>();
            UserInformation userInformation = new UserInformation("test", "0912345678", "AAAA", new DateTime(2000, 7, 15), "男");
            List<Course> courses = new List<Course>();
            courses.Add(new Course("123456", "math", 106, 2));
            courses.Add(new Course("222222", "English", 105, 1));
            courses.Add(new Course("312412", "test", 108, 1));
            courses.Add(new Course("312412", "test", 107, 1));
            courses.Add(new Course("235463", "test2", 108, 2));
            Dictionary<Course, int> courseGrades1 = new Dictionary<Course, int>();
            courseGrades1.Add(courses[0], 68);
            courseGrades1.Add(courses[1], 73);
            courseGrades1.Add(courses[2], 89);
            Dictionary<Course, int> courseGrades2 = new Dictionary<Course, int>();
            courseGrades2.Add(courses[2], 39);
            courseGrades2.Add(courses[4], 75);
            Dictionary<Course, int> courseGrades3 = new Dictionary<Course, int>();
            courseGrades3.Add(courses[3], 86);
            courseGrades3.Add(courses[4], 75);

            Student student1 = new Student("105205001", "123", 3, "3", userInformation, courseGrades1);
            Student student2 = new Student("105205002", "123", 3, "4", userInformation, courseGrades2);
            Student student3 = new Student("105205003", "123", 3, "4", userInformation, courseGrades3);
            Teacher teacher = new Teacher("123", "wer", 2, userInformation, courses);
            Administrator administrator = new Administrator("2313", "1111", 1, userInformation);

            List<IAccount> accounts = new List<IAccount>();
            accounts.Add(teacher);
            accounts.Add(administrator);
            accounts.Add(student1);
            accounts.Add(student2);
            accounts.Add(student3);
            Department department = new Department("205", "CS", accounts, courses);
            departments.Add(department);

            DomainController domainController = new DomainController(departments, new Login());

            AccountModel accountModel = new AccountModel("123", "321", 3, userInformation);
            domainController.CreateAccount(accountModel, "205");

            Assert.AreEqual(6, department.Accounts.Count);
            Assert.AreEqual("108205004", department.Accounts[5].Id);
            Assert.AreEqual("108205004", department.Accounts[5].Password);
            Assert.AreEqual(3, department.Accounts[5].Authority);
            Assert.AreEqual(userInformation, department.Accounts[5].UserInformation);
        }

        [TestMethod()]
        public void TestGetTeacherCourse()
        {
            List<Department> departments = new List<Department>();
            UserInformation userInformation = new UserInformation("test", "0912345678", "AAAA", new DateTime(2000, 7, 15), "男");
            List<Course> courses = new List<Course>();
            courses.Add(new Course("123456", "math", 106, 2));
            courses.Add(new Course("222222", "English", 105, 1));
            courses.Add(new Course("312412", "test", 108, 1));
            courses.Add(new Course("312412", "test", 107, 1));
            courses.Add(new Course("235463", "test2", 108, 2));
            Teacher teacher = new Teacher("123", "wer", 2, userInformation, courses);
            Administrator administrator = new Administrator("2313", "1111", 1, userInformation);

            List<IAccount> accounts = new List<IAccount>();
            accounts.Add(teacher);
            Department department = new Department("205", "CS", accounts, courses);
            departments.Add(department);

            DomainController domainController = new DomainController(departments, new Login());

            CollectionAssert.AreEqual(courses, domainController.GetTeacherCourse("123"));
        }

        [TestMethod()]
        public void TestUpdateUserInformationOfDepartment()
        {
            List<Department> departments = new List<Department>();
            UserInformation userInformation = new UserInformation("test", "0912345678", "AAAA", new DateTime(2000, 7, 15), "男");
            UserInformation userInformation2 = new UserInformation("AAAA", "0912345678", "AAAA", new DateTime(2000, 7, 15), "男");
            List<Course> courses = new List<Course>();
            Teacher teacher = new Teacher("123", "wer", 2, userInformation, courses);
            Administrator administrator = new Administrator("2313", "1111", 1, userInformation);

            List<IAccount> accounts = new List<IAccount>();
            accounts.Add(teacher);
            Department department = new Department("205", "CS", accounts, courses);
            departments.Add(department);

            DomainController domainController = new DomainController(departments, new Login());

            Assert.AreEqual(userInformation, domainController.GetAccount("123").UserInformation);
            domainController.UpdateUserInformationOfDepartment("205", "123", userInformation2);
            Assert.AreEqual(userInformation2, domainController.GetAccount("123").UserInformation);
        }
    }
}