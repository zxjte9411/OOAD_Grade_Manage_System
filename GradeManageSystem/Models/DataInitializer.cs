using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace GradeManageSystem.Models
{
    public static class DataInitializer
    {
        public static void Initialize(DomainController domainController)
        {
            Random random = new Random();
            List<UserInformation> userInformations = new List<UserInformation>();
            List<Grade> grades = new List<Grade>();
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
            for (int i = 0; i < 5; i++)
                courses.Add(new Course(i.ToString(), "course" + i.ToString(), 109, 2));

            grades.Add(new Grade(59));
            grades.Add(new Grade(60));
            grades.Add(new Grade(99));
            grades.Add(new Grade(100));
            grades.Add(new Grade(98));

            Dictionary<Course, Grade> CourseGrades = new Dictionary<Course, Grade>();
            for (int i = 0; i < 5; i++)
                CourseGrades.Add(courses[i], grades[i]);

            accounts.Add(new Administrator("11111", "test", 0, userInformations[0]));
            accounts.Add(new AcadamicAffairs("30688", "test", 1, userInformations[1]));
            accounts.Add(new Teacher("12345", "test", 2, userInformations[2], courses));
            accounts.Add(new Teacher("24689", "test", 2, userInformations[3], courses));
            accounts.Add(new Teacher("54321", "test", 2, userInformations[4], courses));
            accounts.Add(new Student("103380001", "test", 3, userInformations[5], CourseGrades));
            accounts.Add(new Student("103380023", "test", 3, userInformations[6], CourseGrades));
            accounts.Add(new Student("103380047", "test", 3, userInformations[7], CourseGrades));

            for (int i = 0; i < 5; i++)
            {
                Department department = new Department(i.ToString(), "department"+i.ToString(), accounts, courses);
                domainController.Departments.Add(department);
            }
        }
    }
}
