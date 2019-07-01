using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CSMP.Portal.Services
{
	public interface ICacheService
	{
		Task<T> GetAsync<T>(string key, string group, T defaultValue = default(T));

		Task<T> GetOrAddAsync<T>(string key, string group, Func<Task<T>> func);

		Task SetAsync<T>(string key, string group, T value, TimeSpan? expired = null);

		Task RemoveAsync<T>(string key, string group);
	}
}
