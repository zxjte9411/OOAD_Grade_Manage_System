using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GradeManageSystem.Models
{
    public class Teacher : Account
    {
        public Teacher(string id, string password, int authority, 
            UserInformation userInformation, List<Course> courses):
            base(id, password, authority, userInformation)
        {
            //Id = id;
            //Password = password;
            //Authority = authority;
            UserInformation = userInformation;
            Courses = courses;
        }
        //public string Id { get; set; }
        //public string Password { get; set; }
        //public int Authority { get; set; }
        //public UserInformation UserInformation { get; set; }
        public List<Course> Courses { get; set; }
        
        public Dictionary<string, string> GetSemesterCourses(int year, int semester)
        {
            Dictionary<string, string> courses = new Dictionary<string, string>();

            foreach (var course in Courses)
                if (course.Year == year && course.Semester == semester)
                    courses.Add(course.Id, course.Name);

            return courses;
        }
        //public bool IsStudent()
        //{
        //    return Authority == 3;
        //}
        //public bool IsAdmin()
        //{
        //    return Authority == 0;
        //}
        public override bool IsTeacher()
        {
            return true;
        }
        //public bool IsAcadamicAffair()
        //{
        //    return Authority == 1;
        //}
    }
}
