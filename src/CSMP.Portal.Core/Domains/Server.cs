using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CSMP.Portal.Domains
{
	/// <summary>
	///  Server 
	/// </summary>
	public class Server : BaseCreationEntity
	{
		/// <summary>
		///  名称
		/// </summary>
		[MaxLength(32)]
		public string Name { get; set; }

		/// <summary>
		///  标签
		/// </summary>
		public string Tags { get; set; }

		/// <summary>
		///  IP地址
		/// </summary>
		/// <remarks>
		/// TODO 是否单独保存
		/// </remarks>
		[MaxLength(32)]
		public string IpAddress { get; set; }

		/// <summary>
		///  状态
		/// </summary>
		public ServerStatus Status { get; set; }

		/// <summary>
		///  最后心跳时间
		/// </summary>
		public DateTime? LastHeartbeatTime { get; set; }

	}

	/// <summary>
	///  状态
	/// </summary>
	public enum ServerStatus
	{
		Offline = 0,
		Online = 1,
	}
}
