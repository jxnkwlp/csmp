using CSMP.Portal.Web.Security;
using Microsoft.AspNetCore.Authentication;

namespace CSMP.Portal.Web
{
	public static class AgentAuthenticationExtensions
	{
		public static AuthenticationBuilder AddAgentAuthentication(this AuthenticationBuilder builder)
		{
			return builder.AddScheme<AgentAuthenticationOptions, AgentAuthenticationHandler>(AgentAuthenticationOptions.AuthenticationScheme, null, options => { });
		}
	}
}
