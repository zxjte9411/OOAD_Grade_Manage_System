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
            List<IAccount> accounts = new List<IAccount>();
            List<Course> courses = new List<Course>();

            userInformations.Add(new UserInformation("admin", "07-53535113", "Taiwan (ROC)", new DateTime(1999, 1, 1), "男"));
            userInformations.Add(new UserInformation("aca", "09-53535253", "Taiwan (ROC)", new DateTime(1997, 9, 21), "女"));
            userInformations.Add(new UserInformation("t1", "03-53533153", "Taiwan (ROC)", new DateTime(1998, 1, 2), "男"));
            userInformations.Add(new UserInformation("t2", "06-53525153", "Taiwan (ROC)", new DateTime(1998, 1, 3), "女"));
            userInformations.Add(new UserInformation("t3", "01-53535153", "Taiwan (ROC)", new DateTime(1997, 9, 4), "男"));
            userInformations.Add(new UserInformation("s1", "02-53535153", "Taiwan (ROC)", new DateTime(1998, 2, 5), "女"));
            userInformations.Add(new UserInformation("s2", "05-53535153", "Taiwan (ROC)", new DateTime(1997, 9, 6), "男"));
            userInformations.Add(new UserInformation("s3", "04-12345678", "Taiwan (ROC)", new DateTime(1997, 8, 10), "女"));
            userInformations.Add(new UserInformation("s4", "04-12412478", "Taiwan (ROC)", new DateTime(1995, 2, 10), "女"));
            userInformations.Add(new UserInformation("s5", "04-14232558", "Taiwan (ROC)", new DateTime(1997, 3, 24), "男"));

            courses.Add(new Course("275689", "course1", 108, 2));
            courses.Add(new Course("223459", "course2", 108, 2));
            courses.Add(new Course("234559", "course3", 107, 1));
            courses.Add(new Course("123456", "course4", 107, 2));
            courses.Add(new Course("275449", "course5", 107, 1));
            courses.Add(new Course("267986", "course6", 107, 2));
            courses.Add(new Course("212339", "course7", 108, 1));
            courses.Add(new Course("296767", "course8", 108, 2));
            courses.Add(new Course("452785", "course9", 108, 2));
            courses.Add(new Course("123787", "course10", 108, 2));

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

            // for student 1
            Dictionary<Course, int> CourseGrades0 = new Dictionary<Course, int>();
            CourseGrades0.Add(courses[0], grades[1]);
            CourseGrades0.Add(courses[1], grades[3]);
            CourseGrades0.Add(courses[2], grades[4]);
            CourseGrades0.Add(courses[3], grades[2]);
            CourseGrades0.Add(courses[4], grades[5]);
            CourseGrades0.Add(courses[5], grades[6]);
            CourseGrades0.Add(courses[6], grades[6]);
            // for student 2
            Dictionary<Course, int> CourseGrades1 = new Dictionary<Course, int>();
            CourseGrades1.Add(courses[0], grades[2]);
            CourseGrades1.Add(courses[1], grades[4]);
            CourseGrades1.Add(courses[2], grades[5]);
            CourseGrades1.Add(courses[3], grades[6]);
            CourseGrades1.Add(courses[4], grades[1]);
            CourseGrades1.Add(courses[5], grades[4]);
            CourseGrades1.Add(courses[6], grades[8]);
            // for student 3
            Dictionary<Course, int> CourseGrades2 = new Dictionary<Course, int>();
            CourseGrades2.Add(courses[7], grades[7]);
            CourseGrades2.Add(courses[8], grades[6]);
            CourseGrades2.Add(courses[2], grades[4]);
            CourseGrades2.Add(courses[9], grades[2]);
            CourseGrades2.Add(courses[4], grades[3]);
            CourseGrades2.Add(courses[5], grades[4]);
            CourseGrades2.Add(courses[6], grades[9]);
            // for student 4
            Dictionary<Course, int> CourseGrades3 = new Dictionary<Course, int>();
            CourseGrades3.Add(courses[7], grades[7]);
            CourseGrades3.Add(courses[8], grades[9]);
            CourseGrades3.Add(courses[9], grades[5]);
            CourseGrades3.Add(courses[1], grades[4]);
            CourseGrades3.Add(courses[5], grades[5]);
            CourseGrades3.Add(courses[6], grades[3]);
            CourseGrades3.Add(courses[2], grades[8]);
            // for student 5
            Dictionary<Course, int> CourseGrades4 = new Dictionary<Course, int>();
            CourseGrades4.Add(courses[3], grades[5]);
            CourseGrades4.Add(courses[6], grades[7]);
            CourseGrades4.Add(courses[4], grades[4]);
            CourseGrades4.Add(courses[7], grades[1]);
            CourseGrades4.Add(courses[8], grades[2]);
            CourseGrades4.Add(courses[1], grades[6]);
            CourseGrades4.Add(courses[9], grades[9]);

            accounts.Add(new Administrator("11111", "test", 0, userInformations[0]));
            accounts.Add(new AcadamicAffairs("30688", "test", 1, userInformations[1]));
            accounts.Add(new Teacher("12345", "test", 2, userInformations[2], courses.GetRange(0, 4)));
            accounts.Add(new Teacher("24689", "test", 2, userInformations[3], courses.GetRange(4, 4)));
            accounts.Add(new Teacher("54321", "test", 2, userInformations[4], courses.GetRange(6, 4)));
            accounts.Add(new Student("106590001", "test", 3, "2", userInformations[5], CourseGrades0));
            accounts.Add(new Student("106580023", "test", 3, "2", userInformations[6], CourseGrades1));
            accounts.Add(new Student("105580047", "test", 3, "3", userInformations[7], CourseGrades2));
            accounts.Add(new Student("107570047", "test", 3, "1", userInformations[8], CourseGrades3));
            accounts.Add(new Student("104570047", "test", 3, "4", userInformations[9], CourseGrades4));

            // Dep1
            List<IAccount> tmp = accounts.GetRange(0, 3);
            tmp.Add(accounts[5]);
            Department department = new Department("590", "department1", tmp, courses.GetRange(0, 4));
            domainController.Departments.Add(department);
            // Dep2
            tmp = accounts.GetRange(6, 2);
            tmp.Add(accounts[3]);
            department = new Department("580", "department2", tmp, courses.GetRange(4, 3));
            domainController.Departments.Add(department);
            // Dep3
            tmp = accounts.GetRange(8, 2);
            tmp.Add(accounts[4]);
            department = new Department("570", "department3", tmp, courses.GetRange(6, 4));
            domainController.Departments.Add(department);
        }
    }
}
