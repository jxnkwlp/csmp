using CSMP.Portal.Data;
using CSMP.Portal.Domains;
using Passingwind.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Text;

namespace CSMP.Portal.Services
{
    public class ServerService : BaseService<Server>, IServerService
    {
        public ServerService(IUnitOfWork<AppDbContext> unitOfWork, ICacheService cacheService) : base(unitOfWork, cacheService)
        {
        }
    }
}
