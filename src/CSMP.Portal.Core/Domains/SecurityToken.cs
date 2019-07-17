using System;
using System.ComponentModel.DataAnnotations;

namespace CSMP.Portal.Domains
{
	/// <summary>
	///  token 
	/// </summary>
	public class SecurityToken : BaseCreationEntity
	{
		[MaxLength(128)]
		public string Token { get; set; }

		public DateTime? Expired { get; set; }
	}
}
