using CSMP.Portal.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Security.Claims;
using System.Text.Encodings.Web;
using System.Threading.Tasks;

namespace CSMP.Portal.Web.Security
{
    public class AgentAuthenticationHandler : AuthenticationHandler<AgentAuthenticationOptions>
    {
        private readonly ISecurityTokenService _securityTokenService;

        public AgentAuthenticationHandler(IOptionsMonitor<AgentAuthenticationOptions> options, ILoggerFactory logger, UrlEncoder encoder, ISystemClock clock, ISecurityTokenService securityTokenService) : base(options, logger, encoder, clock)
        {
            _securityTokenService = securityTokenService;
        }

        protected override async Task<AuthenticateResult> HandleAuthenticateAsync()
        {
            string token = Request.Query["apitoken"];

            if (string.IsNullOrEmpty(token))
            {
                var bearerToken = Request.Headers["Authorization"];

                if (bearerToken.ToString().StartsWith("bearer ", StringComparison.InvariantCultureIgnoreCase))
                {
                    token = bearerToken.ToString().Substring(7);
                }
            }

            if (string.IsNullOrEmpty(token))
                return AuthenticateResult.NoResult();

            var validResult = await _securityTokenService.ValidTokenAsync(token);

            if (validResult)
            {
                Request.HttpContext.Items["ApiToken"] = token;

                return AuthenticateResult.Success(CreateTokenAuthenticationTicket(token));
            }
            else
            {
                return AuthenticateResult.NoResult();
            }
        }

        private AuthenticationTicket CreateTokenAuthenticationTicket(string token)
        {
            var ci = new ClaimsIdentity(AgentAuthenticationOptions.AuthenticationScheme);
            ci.AddClaim(new Claim(ClaimTypes.Role, "Client"));
            ci.AddClaim(new Claim(ClaimTypes.Name, "Agent"));

            var principal = new ClaimsPrincipal(ci);
            return new AuthenticationTicket(principal, new AuthenticationProperties()
            {
                IssuedUtc = DateTimeOffset.Now,
                ExpiresUtc = DateTimeOffset.Now.AddDays(30),
            }, AgentAuthenticationOptions.AuthenticationScheme);
        }
    }
}
