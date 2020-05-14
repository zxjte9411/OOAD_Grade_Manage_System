using GradeManageSystem.Models;
using Microsoft.AspNetCore.Mvc;

namespace GradeManageSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeachersController : ControllerBase
    {
        private DomainController _domainController;

        public TeachersController(DomainController domainController)
        {
            _domainController = domainController;
        }

        // GET: api/teachers/{id}/courses
        [HttpGet("{id}/courses")]
        public IActionResult GetTeacherCourses(string id)
        {
            if (id != null)
            {
                return Ok(_domainController.GetTeacherCourses(id));
            }

            return NotFound();
        }
    }
}