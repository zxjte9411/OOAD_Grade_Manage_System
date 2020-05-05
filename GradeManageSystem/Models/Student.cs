using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GradeManageSystem.Models
{
    public class Student : IAccount
    {
        public Student(string id, string password, string authority,
            UserInformation userInformation, Dictionary<Course, Grade> CourseGrade)
        {
            Id = id;
            Password = password;
            Authority = authority;
            UserInformation = userInformation;
            CourseGrades = CourseGrade;
        }
        public string Id { get; set; }
        public string Password { get; set; }
        public string Authority { get; set; }
        public UserInformation UserInformation { get; set; }
        public Dictionary<Course, Grade> CourseGrades { get; set; }
        
    }
}
