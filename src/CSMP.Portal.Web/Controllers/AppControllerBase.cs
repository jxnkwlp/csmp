using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CSMP.Portal.Web.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	[Authorize]
	public abstract class AppControllerBase : ControllerBase
	{
	}
}
