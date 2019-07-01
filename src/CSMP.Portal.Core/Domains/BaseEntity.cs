using System;
using System.ComponentModel.DataAnnotations;

namespace CSMP.Portal.Domains
{
	/// <summary>
	///  basic entity
	/// </summary>
	public abstract class BaseEntity
	{
		public int Id { get; set; }
	}

	/// <summary>
	///  basic entity with create time
	/// </summary>
	public abstract class BaseCreationEntity : BaseEntity
	{
		public DateTime CreationTime { get; set; }
	}


	public interface IAgentIdentifier
	{
		[MaxLength(32)]
		string AgentIdentifier { get; set; }
	}
}
