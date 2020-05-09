using GradeManageSystem.Helpers;
using GradeManageSystem.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;

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
        public ActionResult SigIn(AccountModel account)
        {
            if (account != null && ValidateUser(account))
            {
                var issuer = _configuration["Payload:Claims:Issuer"];
                var signKey = _configuration["Payload:Claims:SignKey"];
                var expires = _configuration.GetValue<int>("Payload:Claims:Expires"); // min
                var token = JwtHelpers.GenerateToken(issuer, signKey, account.Id, expires);
                Dictionary<string, string> result = new Dictionary<string, string>();
                var login = _domainController.GetAccount(account.Id);
                result.Add("authority", login.Authority.ToString());
                result.Add("id", login.Id);
                result.Add("token", token);
                return Ok(result);
            }
            else
            {
                return NotFound("User not Exist or Pssword Error");
            }
        }

        private bool ValidateUser(IAccount account)
        {
            var login = _domainController.GetAccount(account.Id);
            if (login != null)
                return login.Password == account.Password;
            return false;

        }
    }
}