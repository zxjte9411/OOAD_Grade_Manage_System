using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Security.AccessControl;
using System.Threading.Tasks;
using GradeManageSystem.Models;
using Microsoft.AspNetCore.Http;
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
            return Ok(_domainController.GetAllDepartmentsIdName());
        }
    }
}