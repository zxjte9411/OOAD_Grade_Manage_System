namespace GradeManageSystem.Models
{
    public interface IAccount
    {
        public string Id { get; set; }
        public string Password { get; set; }
        public int Authority { get; set; }
        public UserInformation UserInformation { get; set; }
        public bool IsStudent();
        public bool IsAdmin();
        public bool IsTeacher();
        public bool IsAcadamicAffair();
    }
}
