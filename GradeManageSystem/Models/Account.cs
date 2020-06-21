using System.Collections.Generic;

namespace GradeManageSystem.Models
{
    public abstract class Account
    {
        enum AuthorityEnum
        {
            Administrator,
            AcadamicAffairs,
            Teacher,
            Student
        }
        protected Account(string id, string password, int authority, UserInformation userInformation)
        {
            Id = id;
            Password = password;
            Authority = authority;
            UserInformation = userInformation;
        }
        public virtual string Id { get; set; }
        public virtual string Password { get; set; }
        public virtual int Authority { get; set; }
        public virtual UserInformation UserInformation { get; set; }

        public virtual bool IsAcadamicAffair() 
        {
            return Authority == (int)AuthorityEnum.AcadamicAffairs;
        }

        public virtual bool IsAdmin()
        {
            return Authority == (int)AuthorityEnum.Administrator;
        }

        public virtual bool IsStudent()
        {
            return Authority == (int)AuthorityEnum.Student;
        }

        public virtual bool IsTeacher()
        {
            return Authority == (int)AuthorityEnum.Teacher;
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
