using GradeManageSystem.Helpers;
using GradeManageSystem.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace GradeManageSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly DomainController _domainController;

        public AuthController(IConfiguration configuration, DomainController domainController)
        {
            _configuration = configuration;
            _domainController = domainController;
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("/token")]
        public ActionResult SignIn(AccountModel account)
        {
            if (account != null && ValidateUser(account))
            {
                var issuer = _configuration["Payload:Claims:Issuer"];
                var signKey = _configuration["Payload:Claims:SignKey"];
                var expires = _configuration.GetValue<int>("Payload:Claims:Expires"); // min
                var token = JwtHelpers.GenerateToken(issuer, signKey, account.Id, expires);
                var result = _domainController.SignIn(account, token);
                if (result != null)
                {
                    return Ok(result);
                }
            }
            return NotFound("User not Exist or Pssword Error");   
        }

        private bool ValidateUser(Account account)
        {
            var login = _domainController.GetAccount(account.Id);
            if (login != null)
                return login.Password == account.Password;

            return false;
        }
    }
}