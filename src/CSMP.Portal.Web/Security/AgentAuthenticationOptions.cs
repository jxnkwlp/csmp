using Microsoft.AspNetCore.Authentication;

namespace CSMP.Portal.Web.Security
{
	public class AgentAuthenticationOptions : AuthenticationSchemeOptions
	{
		public const string AuthenticationScheme = "Agent";
	}
}
