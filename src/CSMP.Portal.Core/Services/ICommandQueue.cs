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
        Task<IList<CommandDefinition>> DequeueAsync(string identifier);

        /// <summary>
        ///  放入命令
        /// </summary>
        /// <param name="identifier">标识</param>
        /// <param name="command">命令</param> 
        Task EnqueueAsync(string identifier, string command);
    }
}
