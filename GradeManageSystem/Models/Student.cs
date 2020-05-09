using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GradeManageSystem.Models
{
    public class Student : IAccount
    {
        public Student()
        {
        }

        public Student(string id, string password, int authority, string grade,
            UserInformation userInformation, Dictionary<Course, int> courseGrade)
        {
            Id = id;
            Password = password;
            Authority = authority;
            UserInformation = userInformation;
            Courses = new List<Course>();
            CourseGrades = new Dictionary<string, int>();
            Grade = grade;
            if (courseGrade != null)
            {
                foreach (var course in courseGrade.Keys)
                {
                    Courses.Add(course);
                    CourseGrades.Add(course.Id, courseGrade[course]);
                }
            }
        }
        public string Id { get; set; }
        public string Password { get; set; }
        public int Authority { get; set; }
        public string Grade { get; set; }
        public UserInformation UserInformation { get; set; }
        public List<Course> Courses { get; set; }
        public Dictionary<string, int> CourseGrades { get; set; }
        public bool IsStudent()
        {
            return Authority == 3;
        }
        public bool IsAdmin()
        {
            return Authority == 0;
        }
        public bool IsTeacher()
        {
            return Authority == 2;
        }
        public bool IsAcadamicAffair()
        {
            return Authority == 1;
        }

        public Course GetCourse(string id)
        {
            return Courses.Find(course => course.Id == id);
        }

        public void SetScore(string id, int score)
        {
            CourseGrades[id] = score;
        }
    }
}
