namespace GradeManageSystem.Models
{
    public class AcadamicAffairs : Account
    {
        public AcadamicAffairs(string id, string password, int authority, UserInformation userInformation) : 
            base(id, password, authority, userInformation)
        { }
    }
}
