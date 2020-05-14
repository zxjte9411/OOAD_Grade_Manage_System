using System.Collections.Generic;

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

        public Account GetAccount(string id)
        {
            foreach (var department in Departments)
                if (department.IsAccountExist(id))
                    return department.GetAccount(id);

            return null;
        }

        public List<Course> GetTeacherCourses(string id)
        {
            var account = (Teacher)GetAccount(id);
            return account.Courses;
        }

        public Department GetDepartment(string id)
        {
            return Departments.Find(department => department.Id == id);
        }
        
        public Dictionary<string, string> GetTeacherLastSemesterCourses(string teacherId)
        {
            Teacher teacher = (Teacher)GetAccount(teacherId);

            if (teacher != null)
                return teacher.GetSemesterCourses(Year, Semester);

            return null;
        }

        public Dictionary<string, string> GetDepartmentsIdName()
        {
            Dictionary<string, string> departments = new Dictionary<string, string>();

            foreach (var dep in Departments)
                departments.Add(dep.Id, dep.Name);

            return departments;
        }

        // course_id, course_name, score, year, semester
        public List<Dictionary<string, string>> GetStudentHistoryScores(string id)
        {
            List<Dictionary<string, string>> scoreTable = new List<Dictionary<string, string>>();
            Student student = (Student)GetAccount(id);

            foreach (var course in student.Courses)
            {
                Dictionary<string, string> keyValuePairs = new Dictionary<string, string>();
                keyValuePairs.Add("course_id", course.Id.ToString());
                keyValuePairs.Add("course_name", course.Name.ToString());
                keyValuePairs.Add("score", student.CourseScores[course.Id].ToString());
                keyValuePairs.Add("year", course.Year.ToString());
                keyValuePairs.Add("semester", course.Semester.ToString());
                scoreTable.Add(keyValuePairs);
            }

            return scoreTable;
        }

        // id, name, department_name, grade, score, year, semester
        public List<Dictionary<string, string>> GetScoreTableByCourse(string courseId, int? year, int? semester)
        {
            List<Dictionary<string, string>> courseGrades = new List<Dictionary<string, string>>();
            List<Student> students = GetStudentsByCourse(courseId, year, semester);

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
                        courseGrade.Add("score", student.CourseScores[courseId].ToString());
                        courseGrade.Add("year", (year ?? student.GetCourse(courseId).Year).ToString());
                        courseGrade.Add("semester", (semester ?? student.GetCourse(courseId).Semester).ToString());
                        courseGrades.Add(courseGrade);
                    }
                }

            return courseGrades;
        }

        public List<Student> GetStudentsByCourse(string courseId, int? year, int? semester)
        {
            List<Student> students = new List<Student>();

            foreach (var department in Departments)
                students.AddRange(department.GetStudentsByCourse(courseId, year, semester));

            return students;
        }

        public void UpdateCourseScoreTable(string courseId, Dictionary<string, string> scoreTable)
        {
            List<Student> students = GetStudentsByCourse(courseId, Year, Semester);

            foreach (var student in students)
                student.SetScore(courseId, int.Parse(scoreTable[student.Id]));
        }

        public void UpdateUserInformationByDepartment(string departmentId, string id, UserInformation userInformation)
        {
            var department = GetDepartment(departmentId);
            var account = department.GetAccount(id);
            account.UserInformation = userInformation;
        }

        public Account CreateAccount(AccountModel newAccount, string departmentId)
        {
            var department = GetDepartment(departmentId.ToString());

            return department.CreateAccount(newAccount, Year);
        }

        public Dictionary<string, string> SignIn(Account loginAccount, string token)
        {
            var account = GetAccount(loginAccount.Id);
            if (account != null && Login.ValidateUser(loginAccount.Password, account.Password))
                return account.GetComposedAccountData(token);

            return null;
        }
    }
}
