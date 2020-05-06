using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GradeManageSystem.Models
{
    public class DomainController
    {
        private const int YEAR = 108;
        private const int SEMESTER = 2;
        public DomainController()
        {
            Departments = new List<Department>();
            Login = new Login();
        }
        public DomainController(List<Department> departments, Login login)
        {
            Departments = departments;
            Login = login;
        }

        public int Year { get => YEAR; }
        public int Semester { get => SEMESTER; }

        public List<Department> Departments { get; set; }

        public Login Login { get; set; }
        
        public Dictionary<string, string> GetTeacherCourses(string teacherId)
        {
            foreach (var department in Departments)
                if (department.Accounts.Any(account => account.Id == teacherId))
                {
                    Teacher teacher = (Teacher)department.Accounts.Find(teacher => teacher.Id == teacherId);
                    return teacher.GetSemesterCourses(Year, Semester);
                }

            return null;
        }

        public Dictionary<string, string> GetAllDepartmentsIdName()
        {
            Dictionary<string, string> departments = new Dictionary<string, string>();

            foreach (var dep in Departments)
                departments.Add(dep.Id, dep.Name);

            return departments;
        }
    }
}
