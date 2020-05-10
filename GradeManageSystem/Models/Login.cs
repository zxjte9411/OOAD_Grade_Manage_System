namespace GradeManageSystem.Models
{
    public class Login
    {
        public bool ValidateUser(string loginPassword, string targetPassword)
        {
            return loginPassword == targetPassword;
        }
    }
}
