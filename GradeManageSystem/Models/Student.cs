using System.Collections.Generic;

namespace GradeManageSystem.Models
{
    public class Student : Account
    {
        public Student():base("", "", 3, null)
        { }

        public Student(string id, string password, int authority, string grade,
            UserInformation userInformation, Dictionary<Course, int> courseGrade)
            :base(id, password, authority, userInformation)
        {
            UserInformation = userInformation;
            Courses = new List<Course>();
            CourseScores = new Dictionary<string, int>();
            Grade = grade;
            if (courseGrade != null)
            {
                foreach (var course in courseGrade.Keys)
                {
                    Courses.Add(course);
                    CourseScores.Add(course.Id, courseGrade[course]);
                }
            }
        }

        public string Grade { get; set; }
        public List<Course> Courses { get; set; }
        public Dictionary<string, int> CourseScores { get; set; }

        public Course GetCourse(string id)
        {
            return Courses.Find(course => course.Id == id);
        }

        public void SetScore(string id, int score)
        {
            CourseScores[id] = score;
        }
    }
}
