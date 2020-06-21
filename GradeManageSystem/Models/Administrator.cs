namespace GradeManageSystem.Models
{
    public class Administrator : Account
    {
        public Administrator(string id, string password, int authority, UserInformation userInformation):
            base(id, password, authority, userInformation)
        { }
    }
}
