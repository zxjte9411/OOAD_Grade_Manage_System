using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using GradeManageSystem.Models;
using Microsoft.AspNetCore.JsonPatch;

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
                foreach (var department in _domainController.Departments)
                {
                    if (int.Parse(department.Id) == departmentId)
                        return Ok(department.Accounts);
                }
            }
            return NotFound();
        }

        [HttpGet("{departmentId}/{id}")]
        public IActionResult GetAccount(int? departmentId, int? id)
        {
            if (departmentId != null)
            {
                foreach (var department in _domainController.Departments)
                {
                    IAccount account = null;
                    if (int.Parse(department.Id) == departmentId)
                    {
                        account = department.FindAccountById(id.ToString());
                        if (account != null)
                            return Ok(account);
                    }
                }
            }

            return NotFound();
        }

        [HttpPost("{departmentId}")]
        public IActionResult CreateAccount(int? departmentId, AccountModel newAccount)
        {
            if (departmentId != null)
            {
                IAccount account = null;
                _domainController.Departments.ForEach((department) =>
                {
                    if(department.Id == departmentId.ToString())
                    {
                        account = _domainController.CreateAccount(department, newAccount);
                    }
                });
                return Ok(account);
            }
            return BadRequest();
        }

        [HttpPost("{departmentId}/{id}")]
        public IActionResult UpdateAccountOfDepartment(string departmentId, string id, UserInformation userInformation)
        {
            if (departmentId != null && id != null)
            {
                foreach (var department in _domainController.Departments)
                {
                    if (department.Id == departmentId)
                    {
                        var account = department.FindAccountById(id);
                        account.UserInformation = userInformation;
                        return Ok(account);
                    }
                }
            }

            return BadRequest();
        }

        [HttpPatch("{departmentId}/{id}")]
        public IActionResult UpdateAccountPasswordOfDepartment(string departmentId, string id, [FromBody]JsonPatchDocument<IAccount> jsonPatchDocument)
        {
            if (departmentId != null && id != null)
            {
                if (jsonPatchDocument != null)
                {
                    foreach (var department in _domainController.Departments)
                    {
                        if (department.Id == departmentId)
                        {
                            var account =  department.FindAccountById(id);
                            jsonPatchDocument.ApplyTo(account);
                            return Ok(account);
                        }
                    }
                }
            }
            return BadRequest();
        }
    }
}