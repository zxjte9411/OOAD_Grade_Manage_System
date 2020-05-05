using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GradeManageSystem.Models
{
    public class Grade
    {
        public Grade(int score)
        {
            Score = score;
        }
        public int Score { get; set; }
    }
}
