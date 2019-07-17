using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CSMP.Portal.Services
{
    public class DefaultMemoryCacheService : ICacheService
    {
        private Dictionary<string, IList<string>> _groupKeys = new Dictionary<string, IList<string>>();
        private IMemoryCache _memoryCache;

        public DefaultMemoryCacheService(IMemoryCache memoryCache)
        {
            _memoryCache = memoryCache;
        }

        protected string GetFullKey(string key, string group)
        {
            return $"{group}:{key}";
        }

        protected void AddKeyToGroup(string group, string key)
        {
            if (_groupKeys.ContainsKey(group))
            {
                if (_groupKeys[group] == null)
                    _groupKeys[group] = new List<string>();

                _groupKeys[group].Add(key);
            }
            else
            {
                _groupKeys[group] = new List<string>() { key };
            }
        }

        public Task<T> GetAsync<T>(string key, string group, T defaultValue = default)
        {
            var value = _memoryCache.Get<T>(GetFullKey(key, group));

            if (value == null)
                return Task.FromResult(defaultValue);

            return Task.FromResult(value);
        }

        public async Task<T> GetOrAddAsync<T>(string key, string group, Func<Task<T>> func)
        {
            AddKeyToGroup(group, key);

            return await _memoryCache.GetOrCreateAsync<T>(GetFullKey(key, group), (_) =>
            {
                return func();
            });
        }

        public Task RemoveAsync(string key, string group)
        {
            _memoryCache.Remove(GetFullKey(key, group));

            return Task.CompletedTask;
        }

        public Task RemoveGroupAsync(string group)
        {
            if (_groupKeys.ContainsKey(group) && _groupKeys[group] != null)
            {
                foreach (var key in _groupKeys[group])
                {
                    _memoryCache.Remove(GetFullKey(key, group));
                }

                _groupKeys.Remove(group);
            }

            return Task.CompletedTask;
        }

        public Task SetAsync<T>(string key, string group, T value, TimeSpan? expired = null)
        {
            AddKeyToGroup(group, key);

            if (expired.HasValue)
                _memoryCache.Set(GetFullKey(key, group), value, DateTimeOffset.Now.Add(expired.Value));
            else
                _memoryCache.Set(GetFullKey(key, group), value);

            return Task.CompletedTask;
        }
    }
}
