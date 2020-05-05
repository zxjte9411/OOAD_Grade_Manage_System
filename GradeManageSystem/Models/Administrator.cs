using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GradeManageSystem.Models
{
    public class Administrator : IAccount
    {
        public Administrator(string id, string password, string authority, UserInformation userInformation)
        {
            Id = id;
            Password = password;
            Authority = authority;
            UserInformation = userInformation;
        }
        public string Id { get; set; }
        public string Password { get; set; }
        public string Authority { get; set; }
        public UserInformation UserInformation { get; set; }
    }
}
