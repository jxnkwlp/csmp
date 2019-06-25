using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CSMP.Portal.Web.Controllers
{
	/// <summary>
	///  登录/授权相关
	/// </summary>
	public class AuthController : AppControllerBase
	{
		[HttpPost("[action]")]
		public IActionResult Token()
		{
			// TODO 
			return Ok();
		}
	}
}
