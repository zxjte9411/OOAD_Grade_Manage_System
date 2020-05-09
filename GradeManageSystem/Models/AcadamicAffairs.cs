using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GradeManageSystem.Models
{
    public class AcadamicAffairs : IAccount
    {
        public AcadamicAffairs(string id, string password, int authority, UserInformation userInformation)
        {
            Id = id;
            Password = password;
            Authority = authority;
            UserInformation = userInformation;
        }
        public string Id { get; set; }
        public string Password { get; set; }
        public int Authority { get; set; }
        public UserInformation UserInformation { get; set; }
        public bool IsStudent()
        {
            return Authority == 3;
        }
        public bool IsAdmin()
        {
            return Authority == 0;
        }
        public bool IsTeacher()
        {
            return Authority == 2;
        }
        public bool IsAcadamicAffair()
        {
            return Authority == 1;
        }
    }
}
