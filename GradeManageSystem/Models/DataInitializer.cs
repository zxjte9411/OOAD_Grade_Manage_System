using System;
using System.Collections.Generic;

namespace GradeManageSystem.Models
{
    public static class DataInitializer
    {
        public static void Initialize(DomainController domainController)
        {
            Random random = new Random();
            List<UserInformation> userInformations = new List<UserInformation>();
            List<int> grades = new List<int>();
            List<Account> accounts = new List<Account>();
            List<Course> courses = new List<Course>();

            userInformations.Add(new UserInformation("迪亞布羅", "07-5353563", "Taiwan (ROC)", new DateTime(1988, 1, 1), "男"));
            userInformations.Add(new UserInformation("吉良及影", "04-4893953", "Taiwan (ROC)", new DateTime(1987, 9, 21), "男"));
            userInformations.Add(new UserInformation("喬納森", "03-1563693", "Taiwan (ROC)", new DateTime(1981, 1, 2), "男"));
            userInformations.Add(new UserInformation("喬瑟夫", "06-1233935", "Taiwan (ROC)", new DateTime(1979, 1, 3), "男"));
            userInformations.Add(new UserInformation("布加拉提", "01-389562", "Taiwan (ROC)", new DateTime(1983, 9, 4), "男"));
            userInformations.Add(new UserInformation("Q太郎", "02-4523542", "Taiwan (ROC)", new DateTime(1998, 2, 5), "男"));
            userInformations.Add(new UserInformation("仗助", "05-1234536", "Taiwan (ROC)", new DateTime(1997, 9, 6), "男"));
            userInformations.Add(new UserInformation("喬魯若", "04-3563451", "Taiwan (ROC)", new DateTime(1997, 8, 10), "男"));
            userInformations.Add(new UserInformation("徐倫", "04-2423873", "Taiwan (ROC)", new DateTime(1995, 2, 10), "女"));
            userInformations.Add(new UserInformation("花京院", "04-4659312", "Taiwan (ROC)", new DateTime(1997, 3, 24), "男"));

            courses.Add(new Course("275689", "math", 108, 2));
            courses.Add(new Course("223459", "english", 108, 2));
            courses.Add(new Course("234559", "OOAD", 107, 1));
            courses.Add(new Course("123456", "OOP", 107, 2));
            courses.Add(new Course("275449", "ML", 107, 1));
            courses.Add(new Course("267986", "algorithm", 107, 2));
            courses.Add(new Course("212339", "front-end", 108, 1));
            courses.Add(new Course("296767", "data science", 108, 2));
            courses.Add(new Course("452785", "database", 108, 2));
            courses.Add(new Course("123787", "physics", 108, 2));

            grades.Add(59);
            grades.Add(60);
            grades.Add(99);
            grades.Add(100);
            grades.Add(98);
            grades.Add(60);
            grades.Add(32);
            grades.Add(76);
            grades.Add(85);
            grades.Add(56);
            grades.Add(30);

            // for student 1
            Dictionary<Course, int> CourseGrades0 = new Dictionary<Course, int>();
            CourseGrades0.Add(courses[0], grades[10]);
            CourseGrades0.Add(courses[1], grades[10]);
            CourseGrades0.Add(courses[2], grades[4]);
            CourseGrades0.Add(courses[3], grades[2]);
            CourseGrades0.Add(courses[4], grades[5]);
            CourseGrades0.Add(courses[5], grades[6]);
            CourseGrades0.Add(courses[6], grades[6]);
            // for student 2
            Dictionary<Course, int> CourseGrades1 = new Dictionary<Course, int>();
            CourseGrades1.Add(courses[0], grades[10]);
            CourseGrades1.Add(courses[1], grades[10]);
            CourseGrades1.Add(courses[2], grades[5]);
            CourseGrades1.Add(courses[3], grades[6]);
            CourseGrades1.Add(courses[4], grades[1]);
            CourseGrades1.Add(courses[5], grades[4]);
            CourseGrades1.Add(courses[6], grades[8]);
            // for student 3
            Dictionary<Course, int> CourseGrades2 = new Dictionary<Course, int>();
            CourseGrades2.Add(courses[7], grades[10]);
            CourseGrades2.Add(courses[8], grades[10]);
            CourseGrades2.Add(courses[2], grades[4]);
            CourseGrades2.Add(courses[9], grades[10]);
            CourseGrades2.Add(courses[4], grades[3]);
            CourseGrades2.Add(courses[5], grades[4]);
            CourseGrades2.Add(courses[6], grades[9]);
            // for student 4
            Dictionary<Course, int> CourseGrades3 = new Dictionary<Course, int>();
            CourseGrades3.Add(courses[7], grades[10]);
            CourseGrades3.Add(courses[8], grades[10]);
            CourseGrades3.Add(courses[9], grades[10]);
            CourseGrades3.Add(courses[1], grades[10]);
            CourseGrades3.Add(courses[5], grades[5]);
            CourseGrades3.Add(courses[6], grades[3]);
            CourseGrades3.Add(courses[2], grades[8]);
            // for student 5
            Dictionary<Course, int> CourseGrades4 = new Dictionary<Course, int>();
            CourseGrades4.Add(courses[3], grades[5]);
            CourseGrades4.Add(courses[6], grades[7]);
            CourseGrades4.Add(courses[4], grades[4]);
            CourseGrades4.Add(courses[7], grades[10]);
            CourseGrades4.Add(courses[8], grades[10]);
            CourseGrades4.Add(courses[1], grades[10]);
            CourseGrades4.Add(courses[9], grades[10]);

            accounts.Add(new Administrator("admin", "test", 0, userInformations[0]));
            accounts.Add(new AcadamicAffairs("academicaffair", "test", 1, userInformations[1]));
            accounts.Add(new Teacher("teacher", "test", 2, userInformations[2], courses.GetRange(0, 4)));
            accounts.Add(new Teacher("24689", "test", 2, userInformations[3], courses.GetRange(4, 4)));
            accounts.Add(new Teacher("54321", "test", 2, userInformations[4], courses.GetRange(6, 4)));
            accounts.Add(new Student("student", "test", 3, "2", userInformations[5], CourseGrades0));
            accounts.Add(new Student("106580023", "test", 3, "2", userInformations[6], CourseGrades1));
            accounts.Add(new Student("105580047", "test", 3, "3", userInformations[7], CourseGrades2));
            accounts.Add(new Student("107570047", "test", 3, "1", userInformations[8], CourseGrades3));
            accounts.Add(new Student("104570047", "test", 3, "4", userInformations[9], CourseGrades4));

            // Dep1
            List<Account> tmp = accounts.GetRange(0, 3);
            tmp.Add(accounts[5]);
            Department department = new Department("590", "電機", tmp, courses.GetRange(0, 4));
            domainController.Departments.Add(department);
            // Dep2
            tmp = accounts.GetRange(6, 2);
            tmp.Add(accounts[3]);
            department = new Department("580", "資工", tmp, courses.GetRange(4, 3));
            domainController.Departments.Add(department);
            // Dep3
            tmp = accounts.GetRange(8, 2);
            tmp.Add(accounts[4]);
            department = new Department("570", "電子", tmp, courses.GetRange(6, 4));
            domainController.Departments.Add(department);
        }
    }
}
