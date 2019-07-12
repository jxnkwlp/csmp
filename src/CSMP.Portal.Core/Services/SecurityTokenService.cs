using CSMP.Portal.Data;
using CSMP.Portal.Domains;
using Microsoft.EntityFrameworkCore;
using Passingwind.UnitOfWork;
using System;
using System.Threading.Tasks;

namespace CSMP.Portal.Services
{
    public class SecurityTokenService : BaseService<SecurityToken>, ISecurityTokenService
    {
        const string CacheKeyGroup = "securitytoken";

        public SecurityTokenService(IUnitOfWork<AppDbContext> unitOfWork, ICacheService cacheService) : base(unitOfWork, cacheService)
        {
        }

        public async Task<bool> ValidTokenAsync(string token)
        {
            var entity = await CacheService.GetOrAddAsync<SecurityToken>($"token:{token}", CacheKeyGroup, async () =>
            {
                return await this.GetAll().FirstOrDefaultAsync(t => t.Token == token);
            });

            if (entity == null)
                return false;
            else
                return entity.Expired.HasValue ? entity.Expired > DateTime.Now : true;
        }

        public override async Task DeleteAsync(int id, bool save = true)
        {
            await base.DeleteAsync(id, save);

            await CacheService.RemoveGroupAsync(CacheKeyGroup);
        }

        public override async Task DeleteAsync(SecurityToken entity, bool save = true)
        {
            await base.DeleteAsync(entity, save);

            await CacheService.RemoveGroupAsync(CacheKeyGroup);
        }
    }
}
