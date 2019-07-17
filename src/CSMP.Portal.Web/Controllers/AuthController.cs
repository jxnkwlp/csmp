using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using CSMP.Portal.Domains;
using CSMP.Portal.Services;
using CSMP.Portal.Web.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace CSMP.Portal.Web.Controllers
{
    /// <summary>
    ///  登录/授权相关
    /// </summary>
    public class AuthController : AppControllerBase
    {
        private readonly IAgentService _agentService;
        private readonly IAccountService _accountService;
        private readonly ISecurityTokenService _securityTokenService;

        public AuthController(IAgentService agentService, IAccountService accountService, ISecurityTokenService securityTokenService)
        {
            _agentService = agentService;
            _accountService = accountService;
            _securityTokenService = securityTokenService;
        }

        protected string CreateJwtToken(Account account)
        {
            var ci = new ClaimsIdentity();
            ci.AddClaim(new Claim(ClaimTypes.Role, "Server"));
            ci.AddClaim(new Claim(ClaimTypes.NameIdentifier, account.Id.ToString()));
            ci.AddClaim(new Claim(ClaimTypes.Name, account.UserName));

            JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = ci,
                Expires = DateTime.Now.AddDays(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes("eb86d203-62a9-4e32-ad2d-adc93484a2d6")), SecurityAlgorithms.HmacSha256),
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }

        [AllowAnonymous]
        [HttpPost("[action]")]
        public async Task<IActionResult> Token([FromBody] LoginModel model)
        {
            var account = await _accountService.GetByUserNameAsync(model.UserName);

            if (account == null)
                return BadRequest();

            var result = await _accountService.VerifyHashedPasswordAsync(account, model.Password);

            if (!result)
                return BadRequest();

            var token = new
            {
                displayName = account.DisplayName,
                userName = account.UserName,
                token = CreateJwtToken(account)
            };

            return Ok(token);
        }

        [AllowAnonymous]
        [HttpPost("[action]")]
        public async Task<IActionResult> AgentRegister([FromQuery] string token)
        {
            if (string.IsNullOrWhiteSpace(token))
            {
                return Unauthorized();
            }

            var result = await _securityTokenService.ValidTokenAsync(token);

            if (!result)
            {
                return Unauthorized();
            }

            var agent = await _agentService.GetOrCreateAsync(Guid.NewGuid().ToString("N"));

            return Ok(agent);
        }
    }
}
