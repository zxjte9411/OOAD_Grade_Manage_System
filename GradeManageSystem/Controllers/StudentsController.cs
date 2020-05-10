using GradeManageSystem.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

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

        // GET: api/students/course/{courseId}
        [HttpGet("course/{courseId}")]
        public IActionResult GetCourseAllGradeList(string courseId)
        {
            if (courseId != null)
            {
                return Ok(_domainController.GetCourseGradeList(courseId, null, null));
            }

            return NotFound();
        }

        // GET: api/students/course/{courseId}/{year}/{semester}
        [HttpGet("course/{courseId}/{year}/{semester}")]
        public IActionResult GetCourseGradeListSemester(string courseId, int? year, int? semester)
        {
            if (courseId != null && year != null && semester != null)
            {
                return Ok(_domainController.GetCourseGradeList(courseId, year, semester));
            }

            return NotFound();
        }

        // GET: api/students/history/{id}
        [HttpGet("history/{id}")]
        public IActionResult GetStudentAllGradeList(string id)
        {
            if (id != null)
            {
                return Ok(_domainController.GetStudentAllGradeList(id));
            }

            return NotFound();
        }

        // POST: api/students/grade/{courseId}/{year}/{semester}
        [HttpPost("grade/{courseId}/{year}/{semester}")]
        public IActionResult UpdateStudentsGrade(string courseId, int? year, int? semester, Dictionary<string, string> gradeList)
        {
            if (gradeList != null && courseId != null)
            {
                _domainController.UpdateStudentsGrade(courseId, gradeList);
                return Ok(_domainController.GetCourseGradeList(courseId, year, semester));
            }

            return NotFound();
        }
    }
}