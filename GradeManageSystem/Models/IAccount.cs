using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GradeManageSystem.Models
{
    public interface IAccount
    {
        public string Id { get; set; }
        public string Password { get; set; }
        public string Authority { get; set; }
        public UserInformation UserInformation { get; set; }
    }
}
