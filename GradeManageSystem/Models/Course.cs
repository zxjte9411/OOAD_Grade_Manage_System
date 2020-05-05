using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GradeManageSystem.Models
{
    public class Course
    {
        public Course(int id, string name, int year, int semester)
        {
            Id = id;
            Name = name;
            Year = year;
            Semester = semester;
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public int Year { get; set; }
        public int Semester { get; set; }
    }
}
