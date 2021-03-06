using CSMP.Portal.Domains;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CSMP.Portal.Services
{
    public interface IAgentService : IService<Agent>
    {
        Task<Agent> GetOrCreateAsync(string identifier);
    }
}
