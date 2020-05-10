using System.Collections.Generic;

namespace GradeManageSystem.Models
{
    public class Teacher : Account
    {
        public Teacher(string id, string password, int authority, 
            UserInformation userInformation, List<Course> courses):
            base(id, password, authority, userInformation)
        {
            UserInformation = userInformation;
            Courses = courses;
        }

        public List<Course> Courses { get; set; }
        
        public Dictionary<string, string> GetSemesterCourses(int year, int semester)
        {
            Dictionary<string, string> courses = new Dictionary<string, string>();

            foreach (var course in Courses)
                if (course.Year == year && course.Semester == semester)
                    courses.Add(course.Id, course.Name);

            return courses;
        }

        public override bool IsTeacher()
        {
            return true;
        }
    }
}
