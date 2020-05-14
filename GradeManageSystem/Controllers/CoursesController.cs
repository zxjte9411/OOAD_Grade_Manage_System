using GradeManageSystem.Models;
using Microsoft.AspNetCore.Mvc;

namespace GradeManageSystem.Controllers
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
        public IActionResult GetTeacherLastSemesterCourses(string teacherId)
        {
            if (teacherId != null)
            {
                return Ok(_domainController.GetTeacherLastSemesterCourses(teacherId));
            }

            return NotFound();
        }
    }
}