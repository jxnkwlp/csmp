using CSMP.Model;
using CSMP.Portal.Domains;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CSMP.Portal.Services
{
    /// <summary>
    ///  命令服务
    /// </summary>
    public interface ICommandService
    {
        Task<IList<CommandDefinition>> PullAsync(string identifier);

        Task PushAsync(string identifier, string command);

        Task UpdateStatusAsync(string identifier, string commandId, CommandStatus status);
    }
}
