using System;
using System.Collections.Generic;
using System.Collections.Concurrent;
using System.Text;
using System.Threading.Tasks;
using CSMP.Model;
using System.Linq;

namespace CSMP.Portal.Services
{
    public class DefaultCommandQueue : ICommandQueue
    {
        private static ConcurrentDictionary<string, List<CommandDefinition>> _queue = new ConcurrentDictionary<string, List<CommandDefinition>>();

        public DefaultCommandQueue()
        {
        }

        public Task<CommandDefinition> GetByIdAsync(string commandId)
        {
            throw new NotImplementedException();
        }

        public Task<List<CommandDefinition>> GetListByIdentifiterAsync(string identifier)
        {
            if (_queue.ContainsKey(identifier))
            {
                var result = _queue[identifier].ToList();

                return Task.FromResult(result);
            }

            return Task.FromResult(new List<CommandDefinition>());
        }

        public Task PushAsync(string identifier, CommandDefinition command)
        {
            if (!_queue.ContainsKey(identifier))
            {
                _queue[identifier] = new List<CommandDefinition>();
            }

            _queue[identifier].Add(command);

            return Task.CompletedTask;
        }

        public Task RemoveByIdentifiterAsync(string identifier)
        {
            throw new NotImplementedException();
        }
    }
}
