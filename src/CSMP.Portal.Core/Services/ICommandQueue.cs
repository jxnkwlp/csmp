using CSMP.Model;
using CSMP.Portal.Domains;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CSMP.Portal.Services
{
    /// <summary>
    ///  命令队列
    /// </summary>
    public interface ICommandQueue
    {
        /// <summary>
        ///  取出相关命令
        /// </summary>
        /// <param name="identifier">标识</param> 
        Task<List<CommandDefinition>> GetListByIdentifiterAsync(string identifier);

        Task<CommandDefinition> GetByIdAsync(string commandId);

        /// <summary>
        ///  放入命令
        /// </summary>
        /// <param name="identifier">标识</param>
        /// <param name="command">命令</param> 
        Task PushAsync(string identifier, CommandDefinition command);

        /// <summary>
        ///  移除相关命令
        /// </summary>
        /// <param name="identifier">标识</param> 
        Task RemoveByIdentifiterAsync(string identifier);
    }
}
