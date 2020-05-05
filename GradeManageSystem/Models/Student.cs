using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GradeManageSystem.Models
{
    public class Student : IAccount
    {
        public Student(string id, string password, int authority,
            UserInformation userInformation, Dictionary<Course, int> courseGrade)
        {
            Id = id;
            Password = password;
            Authority = authority;
            UserInformation = userInformation;
            Courses = new List<Course>();
            CourseGrades = new Dictionary<string, int>();
            foreach (var course in courseGrade.Keys)
            {
                Courses.Add(course);
                CourseGrades.Add(course.Id, courseGrade[course]);
            }
        }
        public string Id { get; set; }
        public string Password { get; set; }
        public int Authority { get; set; }
        public UserInformation UserInformation { get; set; }
        public List<Course> Courses { get; set; }
        public Dictionary<string, int> CourseGrades { get; set; }
        
    }
}
