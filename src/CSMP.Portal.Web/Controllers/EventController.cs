using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CSMP.Portal.Web.Controllers
{
	public class EventController : AppControllerBase
	{
		[HttpPost("[action]")]
		public IActionResult Heartbeat()
		{
			return Ok();
		}

		[HttpPost("[action]")]
		public IActionResult Command()
		{
			return Ok();
		}

	}
}
