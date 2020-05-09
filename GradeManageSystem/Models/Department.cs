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

        public List<Student> GetStudentsOfCourse(string courseId, int? year, int? semester)
        {
            List<Student> students = new List<Student>();

            foreach (var account in Accounts)
                if (account.IsStudent())
                    students.Add((Student)account);

            if (year != null && semester != null)
                RemoveStudentsAgent(students, courseId, year, semester);
            else
                RemoveStudentsAgent(students, courseId);

            return students;
        }

        private void RemoveStudentsAgent(List<Student> students, string courseId, int? year, int? semester)
        {
            for (int i = students.Count - 1; i >= 0; i--)
                if (!students[i].Courses.Any(course => course.Id == courseId && course.Year == year && course.Semester == semester))
                    students.RemoveAt(i);
        }

        private void RemoveStudentsAgent(List<Student> students, string courseId)
        {
            for (int i = students.Count - 1; i >= 0; i--)
                if (!students[i].Courses.Any(course => course.Id == courseId))
                    students.RemoveAt(i);
        }

        public List<IAccount> FindAccountByAuthority(int authority)
        {
            List<IAccount> accounts = new List<IAccount>();
            Accounts.ForEach((account) =>
            {
                if (account.Authority == authority)
                    accounts.Add(account);
            });

            return accounts;
        }

        public bool IsAccountExist(string id)
        {
            return Accounts.Any(account => account.Id == id);
        }

        public IAccount GetAccountById(string id)
        {
            return Accounts.Find(account => account.Id == id);
        }
    }
}
