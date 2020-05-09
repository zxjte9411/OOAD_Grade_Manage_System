using GradeManageSystem.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;

namespace GradeManageSystem.Controllers
{
    [Authorize]
    [Route("api/admin/[controller]")]
    [ApiController]
    public class AccountsController : ControllerBase
    {
        private DomainController _domainController;

        public AccountsController(DomainController domainController)
        {
            _domainController = domainController;
            
        }

        [HttpGet("{id}")]
        public IActionResult GetAccountsByDepartmentId(string id)
        {
            if (id != null)
            {
                return Ok(_domainController.GetAccount(id));
            }
            return NotFound();
        }

        [HttpGet("department/{department_id}")]
        public IActionResult GetAccounts(string departmentId)
        {
            if (departmentId != null) 
            {
                var depadrment = _domainController.GetDepartment(departmentId);
                if (depadrment != null)
                {
                    return Ok(depadrment.Accounts);
                }
            }
            return BadRequest();
        }

        [HttpPost("{departmentId}")]
        public IActionResult CreateAccount(int? departmentId, AccountModel newAccount)
        {
            if (departmentId != null)
            {
                return Ok(_domainController.CreateAccount(newAccount, departmentId.ToString()));
            }
            return BadRequest();
        }

        [HttpPost("{departmentId}/{id}")]
        public IActionResult UpdateAccountOfDepartment(string departmentId, string id, UserInformation userInformation)
        {
            if (departmentId != null && id != null)
            {
                _domainController.UpdateUserInformationOfDepartment(departmentId, id, userInformation);
                return Ok(_domainController.GetAccount(id));
            }

            return BadRequest();
        }

    }
}