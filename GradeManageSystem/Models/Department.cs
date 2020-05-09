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
                RemoveStudentsAgent(students, courseId, (int)year, (int)semester);
            else
                RemoveStudentsAgent(students, courseId);

            return students;
        }

        private void RemoveStudentsAgent(List<Student> students, string courseId, int year, int semester)
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

        public List<IAccount> GetAccountByAuthority(int authority)
        {
            return Accounts.FindAll(account => account.Authority == authority);
        }

        public bool IsAccountExist(string id)
        {
            return Accounts.Any(account => account.Id == id);
        }

        public IAccount GetAccountById(string id)
        {
            return Accounts.Find(account => account.Id == id);
        }

        private int GetMaxId(List<IAccount> accounts)
        {
            int maxValue = int.MinValue;
            accounts.ForEach((account) =>
            {
                if (account.IsStudent())
                {
                    if (maxValue < int.Parse(account.Id.Substring(6, 3)))
                        maxValue = int.Parse(account.Id.Substring(6, 3));
                }
                //else if (account.IsTeacher())
                //{/*TODO*/}
                //else if (account.IsAcadamicAffair())
                //{/*TODO*/}
                //else if (account.IsAdmin())
                //{/*TODO*/}
            });

            return maxValue;
        }

        private Student CreateStudent(AccountModel newAccount, int year)
        {
            Student student = new Student(year + Id.PadLeft(3, '0'), "", 3, "1", newAccount.UserInformation, null);
            student.Id += (GetMaxId(GetAccountByAuthority(newAccount.Authority)) + 1).ToString().PadLeft(3, '0');
            student.Password = student.Id;
            Accounts.Add(student);
            return student;
        }

        public IAccount CreateAccount(AccountModel newAccount, int year)
        {
            if (newAccount.IsStudent())
            {
                return CreateStudent(newAccount, year);
            }
            //else if (newAccount.IsTeacher())
            //{/*TODO*/}
            //else if (newAccount.IsAcadamicAffair())
            //{/*TODO*/}
            //else if (newAccount.IsAdmin())
            //{/*TODO*/}

            return null;
        }
    }
}
