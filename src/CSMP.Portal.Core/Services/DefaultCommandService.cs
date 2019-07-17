using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using CSMP.Model;

namespace CSMP.Portal.Services
{
    public class DefaultCommandService : ICommandService
    {
        private readonly ICommandQueue _queue;

        public DefaultCommandService(ICommandQueue queue)
        {
            _queue = queue;
        }

        public async Task<List<CommandDefinition>> PullAsync(string identifier)
        {
            return await _queue.GetListByIdentifiterAsync(identifier);
        }

        public async Task PushAsync(string identifier, CommandDefinition command)
        {
            await _queue.PushAsync(identifier, command);
        }

        public async Task UpdateAsync(string identifier, string commandId, CommandStatus status, string result)
        {
            // TODO

        }
    }
}
