using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
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

        public Teacher GetTeacher(string teacherId)
        {
            foreach (var department in Departments)
                if (department.IsAccountExist(teacherId))
                    return (Teacher)department.GetAccountById(teacherId);

            return null;
        }
        
        public Dictionary<string, string> GetTeacherCoursesLastSemester(string teacherId)
        {
            Teacher teacher = GetTeacher(teacherId);

            if (teacher != null)
                return teacher.GetSemesterCourses(Year, Semester);

            return null;
        }

        public Dictionary<string, string> GetAllDepartmentsIdName()
        {
            Dictionary<string, string> departments = new Dictionary<string, string>();

            foreach (var dep in Departments)
                departments.Add(dep.Id, dep.Name);

            return departments;
        }

        // course_id, course_name, score, year, semester
        public List<Dictionary<string, string>> GetStudentAllGradeList(string id)
        {
            List<Dictionary<string, string>> gradeList = new List<Dictionary<string, string>>();
            Student student = new Student();

            foreach (var department in Departments)
                if (department.IsAccountExist(id))
                {
                    student = (Student)department.GetAccountById(id);
                    break;
                }

            foreach (var course in student.Courses)
            {
                Dictionary<string, string> keyValuePairs = new Dictionary<string, string>();
                keyValuePairs.Add("course_id", course.Id.ToString());
                keyValuePairs.Add("course_name", course.Name.ToString());
                keyValuePairs.Add("score", student.CourseGrades[course.Id].ToString());
                keyValuePairs.Add("year", course.Year.ToString());
                keyValuePairs.Add("semester", course.Semester.ToString());
                gradeList.Add(keyValuePairs);
            }

            return gradeList;
        }

        // id, name, department_name, grade, score, year, semester
        public List<Dictionary<string, string>> GetCourseGradeList(string courseId, int? year, int? semester)
        {
            List<Dictionary<string, string>> courseGrades = new List<Dictionary<string, string>>();
            List<Student> students = GetStudentsOfCourse(courseId, year, semester);

            foreach (var department in Departments)
                foreach (var student in students)
                {
                    if (department.IsAccountExist(student.Id))
                    {
                        Dictionary<string, string> courseGrade = new Dictionary<string, string>();
                        courseGrade.Add("id", student.Id.ToString());
                        courseGrade.Add("name", student.UserInformation.Name.ToString());
                        courseGrade.Add("department_name", department.Name.ToString());
                        courseGrade.Add("grade", student.Grade.ToString());
                        courseGrade.Add("score", student.CourseGrades[courseId].ToString());
                        courseGrade.Add("year", (year ?? student.GetCourse(courseId).Year).ToString());
                        courseGrade.Add("semester", (semester ?? student.GetCourse(courseId).Semester).ToString());
                        courseGrades.Add(courseGrade);
                    }
                }

            return courseGrades;
        }

        public List<Student> GetStudentsOfCourse(string courseId, int? year, int? semester)
        {
            List<Student> students = new List<Student>();

            foreach (var department in Departments)
                students.AddRange(department.GetStudentsOfCourse(courseId, year, semester));

            return students;
        }

        public void UpdateStudentsGrade(string courseId, Dictionary<string, string> gradeList)
        {
            List<Student> students = GetStudentsOfCourse(courseId, Year, Semester);

            foreach (var student in students)
            {
                if (int.TryParse(gradeList[student.Id], out int score))
                    student.SetScore(courseId, score);
                else
                    throw new Exception("score parse to int fail");
            }
        }

        public int FindMaxId(List<IAccount> accounts)
        {
            int maxValue = int.MinValue;
            accounts.ForEach((account) => 
            {
                if (account.IsStudent())
                {
                    if (maxValue < int.Parse(account.Id))
                        maxValue = int.Parse(account.Id.Substring(6, 3));
                }
                else if (account.IsTeacher())
                {/*TODO*/}
                else if (account.IsAcadamicAffair())
                {/*TODO*/}
                else if (account.IsAdmin())
                {/*TODO*/}
            });

            return maxValue;
        }

        public IAccount CreateAccount(Department department, AccountModel newAccount)
        {
            if (newAccount.IsStudent())
            {
                Student student = new Student(YEAR+ department.Id.PadLeft(3, '0'), "", 3, "1", newAccount.UserInformation, null);
                string tempId = (FindMaxId(department.GetAccountByAuthority(newAccount.Authority)) + 1).ToString().PadLeft(3, '0'); ;
                student.Id += tempId;
                student.Password = tempId;
                department.Accounts.Add(student);
                return student;
            }
            else if (newAccount.IsTeacher())
            {/*TODO*/}
            else if (newAccount.IsAcadamicAffair())
            {/*TODO*/}
            else if (newAccount.IsAdmin())
            {/*TODO*/}

            return null;
        }
    }
}
