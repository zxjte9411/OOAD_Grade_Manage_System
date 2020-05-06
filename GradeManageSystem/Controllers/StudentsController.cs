using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using GradeManageSystem.Models;

namespace GradeManageSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private DomainController _domainController;

        public StudentsController(DomainController domainController)
        {
            _domainController = domainController;
        }

        // GET: api/students/grade/{courseId}
        [HttpGet("grade/{courseId}")]
        public IActionResult GetCourseGradeListLastSemester(string? courseId)
        {
            if (courseId != null)
            {
                return Ok(_domainController.GetCourseGradeList(courseId, null, null));
            }

            return NotFound();
        }

        // POST: api/students/grade/{courseId}
        [HttpPost("{courseId}")]
        public IActionResult UpdateStudentsGrade(string? courseId, Dictionary<string, string> gradeList)
        {
            if (gradeList != null && courseId != null)
            {
                _domainController.UpdateStudentsGrade(courseId, gradeList);
                return Ok(_domainController.GetCourseGradeList(courseId, null, null));
            }

            return NotFound();
        }
    }
}