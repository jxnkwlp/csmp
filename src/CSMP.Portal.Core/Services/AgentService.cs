using CSMP.Portal.Data;
using CSMP.Portal.Domains;
using Microsoft.EntityFrameworkCore;
using Passingwind.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSMP.Portal.Services
{
    public class AgentService : BaseService<Agent>, IAgentService
    {
        public AgentService(IUnitOfWork<AppDbContext> unitOfWork, ICacheService cacheService) : base(unitOfWork, cacheService)
        {
        }

        public async Task<Agent> GetOrCreateAsync(string identifier)
        {
            var entity = await this.GetAll().FirstOrDefaultAsync(t => t.Identifier == identifier);

            if (entity != null)
                return entity;
            else
            {
                entity = new Agent() { Identifier = identifier };

                await this.CreateAsync(entity);

                return entity;
            }
        }
    }
}
