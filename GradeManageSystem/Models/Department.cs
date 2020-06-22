using System;
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

        private bool CompareIdValue(int id)
        {
            return int.MinValue < id;
        }

        private int GetMaxId(List<Account> accounts, int year)
        {
            int maxValue = 0;
            accounts.ForEach((account) =>
            {
                if (account.Id.Substring(0, year.ToString().Length) == year.ToString())
                {
                    int id = int.Parse(account.Id.Substring(6, 3));
                    if (CompareIdValue(id))
                        maxValue = id;
                }
            });

            return maxValue;
        }

        private Student CreateStudent(AccountModel newAccount, int year)
        {
            Student student = new Student(year + Id.PadLeft(3, '0'), "", 3, "1", newAccount.UserInformation, null); // 依照帳號身分建立對應的帳號
            student.Id += (GetMaxId(GetAccountsByAuthority(newAccount.Authority), year) + 1).ToString().PadLeft(3, '0'); // 從已存在的帳號中找到最大的 ID 後三碼，再從這三碼左邊補 3 個 0
            student.Password = student.Id; // 密碼預設為帳號 ID
            Accounts.Add(student);
            return student;
        }

        private Account CreateAdmin(AccountModel newAccount, int year)
        {
            Administrator administrator = new Administrator("", "", 0, newAccount.UserInformation); // 依照帳號身分建立對應的帳號
            administrator.Id = string.Format("{0:000000}", (new Random()).Next(100000));//產生 6 位數字亂數, 左側不滿位數補0的字串產生方式
            administrator.Password = administrator.Id; // 密碼預設為帳號 ID
            Accounts.Add(administrator);
            return administrator;
        }

        private Account CreateAcadamicAffair(AccountModel newAccount, int year)
        {
            AcadamicAffairs acadamicAffair = new AcadamicAffairs("", "", 1, newAccount.UserInformation); // 依照帳號身分建立對應的帳號
            acadamicAffair.Id = string.Format("{0:000000}", (new Random()).Next(100000));//產生 6 位數字亂數, 左側不滿位數補0的字串產生方式
            acadamicAffair.Password = acadamicAffair.Id; // 密碼預設為帳號 ID
            Accounts.Add(acadamicAffair);
            return acadamicAffair;
        }

        private Account CreateTeacher(AccountModel newAccount, int year)
        {
            Administrator administrator = new Administrator("", "", 2, newAccount.UserInformation); // 依照帳號身分建立對應的帳號
            administrator.Id = string.Format("{0:000000}", (new Random()).Next(100000));//產生 6 位數字亂數, 左側不滿位數補0的字串產生方式
            administrator.Password = administrator.Id; // 密碼預設為帳號 ID
            Accounts.Add(administrator);
            return administrator;
        }

        public Account CreateAccount(AccountModel newAccount, int year)
        {
            if (newAccount.IsStudent())
            {
                return CreateStudent(newAccount, year);
            }
            else if (newAccount.IsTeacher())
            { 
                return CreateTeacher(newAccount, year); 
            }
            else if (newAccount.IsAcadamicAffair())
            { 
                return CreateAcadamicAffair(newAccount, year); 
            }
            else if (newAccount.IsAdmin())
            { 
                return CreateAdmin(newAccount, year); 
            }

            return null;
        }
    }
}
