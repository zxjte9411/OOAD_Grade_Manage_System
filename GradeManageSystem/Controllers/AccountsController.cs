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
            if (departmentId != null)
            {
                _domainController.Departments.ForEach((department) =>
                {
                    if(department.Id == department.Id)
                    {
                        if (account.Authority == 3)
                        {
                            var student = new Student(account.Id, account.Password, account.Authority, "1", account.UserInformation, null);
                            department.Accounts.Add(student);
                        }
                    }
                });
                return StatusCode(200);
            }
            //"id": "103380001",
            //    "password": "test",
            //    "authority": 3,
            //        "userInformation": {
            //    "name": "s1",
            //        "phone": "02-53535153",
            //        "address": "Taiwan (ROC)",
            //        "birthday": "1998-02-05T00:00:00",
            //        "gender": "女"
            //        },
            return BadRequest();
        }
    }
}