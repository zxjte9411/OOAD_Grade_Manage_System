using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using GradeManageSystem.Models;

namespace GradeManageSystem.Controllers
{
    [Route("api/admin/[controller]")]
    [ApiController]
    public class AccountsController : ControllerBase
    {
        private DomainController _domainController;

        public AccountsController(DomainController domainController)
        {
            _domainController = domainController;
        }

        [HttpGet("{departmentId}")]
        public IActionResult GetAccountsByDepartmentId(int? departmentId)
        {
            if (departmentId != null)
            {
                return Ok(_domainController.GetDepartment(departmentId.ToString()).Accounts);
            }
            return NotFound();
        }

        [HttpGet("{departmentId}/{id}")]
        public IActionResult GetAccount(int? departmentId, int? id)
        {
            try
            {
                return Ok(_domainController.GetDepartment(departmentId.ToString()).GetAccountById(id.ToString()));
            }
            catch (Exception e)
            {
                return NotFound(e);
            }
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