using CSMP.Portal.Domains;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSMP.Portal.Data
{
    public class DataSender
    {
        private readonly AppDbContext _dbContext;
        private IPasswordHasher<Account> _passwordHasher;

        public DataSender(AppDbContext dbContext)
        {
            _dbContext = dbContext;

            _passwordHasher = new PasswordHasher<Account>();
        }

        public void Initialize()
        {
            if (!_dbContext.Accounts.Any())
            {
                var account = new Account()
                {
                    DisplayName = "admin",
                    UserName = "admin",
                    SecurityStamp = Guid.NewGuid().ToString(),
                };

                account.PasswordHash = _passwordHasher.HashPassword(account, "123456");

                _dbContext.Accounts.Add(account);

                _dbContext.SecurityTokens.Add(new SecurityToken() { Token = Guid.NewGuid().ToString("N") });

                _dbContext.SaveChanges();
            }
        }
    }
}
