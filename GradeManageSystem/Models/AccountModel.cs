using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GradeManageSystem.Models
{
    public class AccountModel : IAccount
    {
        public string Id { get; set; }
        public string Password { get; set; }
        public int Authority { get; set; }
        public UserInformation UserInformation { get; set; }
    }
}
