using System.Collections.Generic;

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

        public virtual Dictionary<string, string> GetComposedAccountData(string token) => 
            new Dictionary<string, string>
                {
                    { "authority", Authority.ToString() },
                    { "id", Id },
                    { "token", token }
                };
    }
}
