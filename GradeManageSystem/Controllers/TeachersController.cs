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
    public class TeachersController : ControllerBase
    {
        private DomainController _domainController;

        public TeachersController(DomainController domainController)
        {
            _domainController = domainController;
        }

        // GET: api/teachers/{id}/courses
        [HttpGet("{id}/courses")]
        public IActionResult GetTeacherAllCourses(string? id)
        {
            if (id != null)
            {
                return Ok(_domainController.GetTeacher(id).Courses);
            }

            return NotFound();
        }
    }
}