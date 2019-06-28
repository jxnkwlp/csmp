using System;
using System.ComponentModel.DataAnnotations;

namespace CSMP.Portal.Domains
{
	public class Account : BaseCreationEntity
	{
		[Required]
		[MaxLength(32)]
		public string UserName { get; set; }

		public string DisplayName { get; set; }

		[MaxLength(128)]
		public string PasswordHash { get; set; }

		[MaxLength(128)]
		public string SecurityStamp { get; set; } = Guid.NewGuid().ToString();
	}
}
