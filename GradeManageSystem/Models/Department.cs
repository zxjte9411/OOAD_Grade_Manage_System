using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GradeManageSystem.Models
{
    public class Department
    {
        public Department(string id, string name, List<IAccount> accounts, List<Course> courses)
        {
            Id = id;
            Name = name;
            Accounts = accounts;
            Courses = courses;
        }
        public string Id { get; set; }
        public string Name { get; set; }
        public List<IAccount> Accounts { get; set; }
        public List<Course> Courses { get; set; }
    }
}
