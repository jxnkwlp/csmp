﻿using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Encodings.Web;
using System.Threading.Tasks;

namespace CSMP.Portal.Web.Security
{
	public class AgentAuthenticationHandler : AuthenticationHandler<AgentAuthenticationOptions>
	{
		public AgentAuthenticationHandler(IOptionsMonitor<AgentAuthenticationOptions> options, ILoggerFactory logger, UrlEncoder encoder, ISystemClock clock) : base(options, logger, encoder, clock)
		{
		}

		protected override Task<AuthenticateResult> HandleAuthenticateAsync()
		{
			throw new NotImplementedException();
		}
	}
}
