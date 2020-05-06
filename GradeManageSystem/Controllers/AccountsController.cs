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
            Department department = null;
            if (departmentId != null)
            {
                foreach (var d in _domainController.Departments)
                {
                    if (int.Parse(d.Id) == departmentId)
                        department = d;
                }
            }

            if (department != null)
            {
                foreach (var account in department.Accounts)
                {
                    if (int.Parse(account.Id) == id)
                        return Ok(account);
                }
            }
            return NotFound();
        }

        [HttpPost("{departmentId}")]
        public IActionResult CreateAccount(int? departmentId, AccountModel account)
        {
            IAccount newAccount = null;
            if (departmentId != null)
            {
                _domainController.Departments.ForEach((department) =>
                {
                    if(department.Id == departmentId.ToString())
                    {
                        string studentId = _domainController.;
                        if (account.Authority == 3)
                        {
                            newAccount = new Student(account.Id, account.Password, account.Authority, "1", account.UserInformation, null);
                            department.Accounts.Add(newAccount);
                        }
                        if (account.Authority == 2)
                        {
                            newAccount = new Teacher(account.Id, account.Password, account.Authority, account.UserInformation, null);
                            department.Accounts.Add(newAccount);
                        }
                        if (account.Authority == 1)
                        {
                            newAccount = new AcadamicAffairs(account.Id, account.Password, account.Authority, account.UserInformation);
                            department.Accounts.Add(newAccount);
                        }
                        if (account.Authority == 0)
                        {
                            newAccount = new Administrator(account.Id, account.Password, account.Authority, account.UserInformation);
                            department.Accounts.Add(newAccount);
                        }
                    }
                });
                return Ok(newAccount);
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
                        foreach (var account in department.Accounts)
                        {
                            if (account.Id == id)
                            {
                                account.UserInformation = userInformation;
                                return Ok(account);
                            }
                        }
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
                            foreach (var account in department.Accounts)
                            {
                                if (account.Id == id)
                                {
                                    jsonPatchDocument.ApplyTo(account);
                                    return Ok(account);
                                }
                            }
                        }

                    }
                }
            }
            return BadRequest();
        }
    }
}