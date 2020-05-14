using System.Collections.Generic;
using System.Linq;

namespace GradeManageSystem.Models
{
    public class Department
    {
        public Department(string id, string name, List<Account> accounts, List<Course> courses)
        {
            Id = id;
            Name = name;
            Accounts = accounts;
            Courses = courses;
        }
        public string Id { get; set; }
        public string Name { get; set; }
        public List<Account> Accounts { get; set; }
        public List<Course> Courses { get; set; }

        public List<Student> GetStudentsByCourse(string courseId, int? year, int? semester)
        {
            List<Student> students = new List<Student>();
            Student student;

            foreach (var account in Accounts)
                if (account.IsStudent())
                {
                    student = (Student)account;
                    AddStudentsAgent(students, student, courseId, year, semester);
                }


            return students;
        }

        private void AddStudentsAgent(List<Student> students, Student student, string courseId, int? year, int? semester)
        {
            if (year != null && semester != null)
                AddStudent(students, student, courseId, (int)year, (int)semester);
            else
                AddStudent(students, student, courseId);
        }

        private void AddStudent(List<Student> students, Student student, string courseId, int year, int semester)
        {
            if (student.Courses.Any(course => course.Id == courseId && course.Year == year && course.Semester == semester))
                students.Add(student);
        }

        private void AddStudent(List<Student> students, Student student, string courseId)
        {
            if (student.Courses.Any(course => course.Id == courseId))
                students.Add(student);
        }

        public List<Account> GetAccountsByAuthority(int authority)
        {
            return Accounts.FindAll(account => account.Authority == authority);
        }

        public bool IsAccountExist(string id)
        {
            return Accounts.Any(account => account.Id == id);
        }

        public Account GetAccount(string id)
        {
            return Accounts.Find(account => account.Id == id);
        }

        private int GetMaxId(List<Account> accounts)
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
            student.Id += (GetMaxId(GetAccountsByAuthority(newAccount.Authority)) + 1).ToString().PadLeft(3, '0');
            student.Password = student.Id;
            Accounts.Add(student);
            return student;
        }

        public Account CreateAccount(AccountModel newAccount, int year)
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
