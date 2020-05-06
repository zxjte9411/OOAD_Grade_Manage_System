using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GradeManageSystem.Models
{
    public class Department
    {
        public Department(string id, string name, List<IAccount> accounts, List<Course> courses)
        {
            Id = id;
            Name = name;
            Accounts = accounts;
            Courses = courses;
        }
        public string Id { get; set; }
        public string Name { get; set; }
        public List<IAccount> Accounts { get; set; }
        public List<Course> Courses { get; set; }

        public List<Student> GetStudentsOfCourse(string courseId, int year, int semester)
        {
            List<Student> students = new List<Student>();

            foreach (var account in Accounts)
            {
                if (account.Authority == 3)
                    students.Add((Student)account);

                if (students.Count > 0 && !students[students.Count - 1].Courses.Any(course => course.Id == courseId && course.Year == year && course.Semester == semester))
                    students.RemoveAt(students.Count - 1);
            }

            return students;
        }
    }
}
