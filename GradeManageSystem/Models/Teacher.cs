using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GradeManageSystem.Models
{
    public class Teacher : IAccount
    {
        public Teacher(string id, string password, int authority, 
            UserInformation userInformation, List<Course> courses)
        {
            Id = id;
            Password = password;
            Authority = authority;
            UserInformation = userInformation;
            Courses = courses;
        }
        public string Id { get; set; }
        public string Password { get; set; }
        public int Authority { get; set; }
        public UserInformation UserInformation { get; set; }
        public List<Course> Courses { get; set; }
        
        public Dictionary<string, string> GetSemesterCourses(int year, int semester)
        {
            Dictionary<string, string> courses = new Dictionary<string, string>();

            foreach (var course in Courses)
                if (course.Year == year && course.Semester == semester)
                    courses.Add(course.Id, course.Name);

            return courses;
        }
    }
}
