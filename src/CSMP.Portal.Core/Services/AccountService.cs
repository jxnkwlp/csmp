using CSMP.Portal.Data;
using CSMP.Portal.Domains;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Passingwind.UnitOfWork;
using System;
using System.Threading.Tasks;

namespace CSMP.Portal.Services
{
    public class AccountService : BaseService<Account>, IAccountService
    {
        private IPasswordHasher<Account> _passwordHasher;

        public AccountService(IUnitOfWork<AppDbContext> unitOfWork, ICacheService cacheService) : base(unitOfWork, cacheService)
        {
            _passwordHasher = new PasswordHasher<Account>();
        }

        public async Task<Account> GetByUserNameAsync(string userName)
        {
            return await this.GetAll().FirstOrDefaultAsync(t => t.UserName == userName);
        }

        public Task HashPasswordAsync(Account account, string password)
        {
            if (string.IsNullOrWhiteSpace(password))
            {
                throw new ArgumentException("message", nameof(password));
            }

            account.PasswordHash = _passwordHasher.HashPassword(account, password);

            return Task.CompletedTask;
        }

        public Task<bool> VerifyHashedPasswordAsync(Account account, string password)
        {
            if (string.IsNullOrWhiteSpace(password)) return Task.FromResult(false);

            if (string.IsNullOrWhiteSpace(account.PasswordHash))
                return Task.FromResult(false);

            var result = _passwordHasher.VerifyHashedPassword(account, account.PasswordHash, password);

            return Task.FromResult(result == PasswordVerificationResult.Success);
        }
    }
}
