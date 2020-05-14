using GradeManageSystem.Models;
using Microsoft.AspNetCore.Mvc;

namespace GradeManageSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private DomainController _domainController;

        public DepartmentController(DomainController domainController)
        {
            _domainController = domainController;
        }

        // GET: api/departments
        [HttpGet]
        public IActionResult GetAllDepartments()
        {
            return Ok(_domainController.GetDepartmentsIdName());
        }
    }
}