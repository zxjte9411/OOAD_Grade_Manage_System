using GradeManageSystem.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

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
        public IActionResult GetAccount(string id)
        {
            if (id != null)
            {
                return Ok(_domainController.GetAccount(id));
            }
            return NotFound();
        }

        [HttpGet("department/{departmentId}")]
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

        [HttpPost("department/{departmentId}")]
        public IActionResult CreateAccount(string departmentId, AccountModel newAccount)
        {
            if (departmentId != null)
            {
                return Ok(_domainController.CreateAccount(newAccount, departmentId.ToString()));
            }
            return BadRequest();
        }

        [HttpPost("department/{departmentId}/{id}")]
        public IActionResult UpdateAccountByDepartment(string departmentId, string id, UserInformation userInformation)
        {
            if (departmentId != null && id != null)
            {
                _domainController.UpdateUserInformationByDepartment(departmentId, id, userInformation);
                return Ok(_domainController.GetAccount(id));
            }

            return BadRequest();
        }

    }
}