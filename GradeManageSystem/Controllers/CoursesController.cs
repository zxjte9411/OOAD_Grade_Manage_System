using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GradeManageSystem.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GradeManageSystem.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoursesController : ControllerBase
    {
        private DomainController _domainController;
        public CoursesController(DomainController domainController)
        {
            _domainController = domainController;
        }

        // GET: api/Courses/{teacher_id}
        [HttpGet("{teacherId}")]
        public IActionResult GetTeacherAllCourses(string teacherId)
        {
            var courses = _domainController.GetTeacherCourses(teacherId);
            if (courses != null)
            {
                return Ok(courses);
            }

            return NotFound();
        }
    }
}