using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GradeManageSystem.Models
{
    public abstract class Account : IAccount
    {
        public virtual string Id { get; set; }
        public virtual string Password { get; set; }
        public virtual int Authority { get; set; }
        public virtual UserInformation UserInformation { get; set; }

        public virtual bool IsAcadamicAffair() 
        {
            return false;
        }
        public virtual bool IsAdmin()
        {
            return false;
        }
        public virtual bool IsStudent()
        {
            return false;
        }
        public virtual bool IsTeacher()
        {
            return false;
        }
    }
}
