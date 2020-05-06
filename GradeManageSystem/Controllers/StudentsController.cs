using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GradeManageSystem.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GradeManageSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
         
        DomainController _domainController;

        public StudentsController(DomainController domainController)
        {
            _domainController = domainController;
        }

        [HttpGet("{courseId}")]
        public IActionResult GetStudentsOfCourse(string courseId)
        {
            List<Dictionary<string, string>> dataResult = null;
            if (courseId != null)
            {
                dataResult = new List<Dictionary<string, string>>();
                _domainController.Departments.ForEach((department) =>
                {
                    department.Accounts.ForEach((account) =>
                    {
                        if (account.Authority == 3)
                        {
                            var student = (Student)account;
                            var data = new Dictionary<string, string>();
                            if (student.CourseGrades.TryGetValue(courseId, out int value))
                            {
                                data.Add("id", student.Id);
                                data.Add("name", student.UserInformation.Name);
                                data.Add("department_name", department.Name);
                                data.Add("score", value.ToString());
                                dataResult.Add(data);
                            }
                        }
                    });
                });
                return Ok(dataResult);
            }            
            return NotFound();
        }
    }
}