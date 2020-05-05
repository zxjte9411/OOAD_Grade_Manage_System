using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GradeManageSystem.Models
{
    public class Teacher : IAccount
    {
        public Teacher(string id, string password, string authority, 
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
        public string Authority { get; set; }
        public UserInformation UserInformation { get; set; }
        public List<Course> Courses { get; set; }
    }
}
