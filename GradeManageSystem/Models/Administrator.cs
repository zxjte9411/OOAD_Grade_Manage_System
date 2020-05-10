using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GradeManageSystem.Models
{
    public class Administrator : Account
    {
        public Administrator(string id, string password, int authority, UserInformation userInformation):
            base(id, password, authority, userInformation)
        { }
        public override bool IsAdmin()
        {
            return true;
        }
    }
}
