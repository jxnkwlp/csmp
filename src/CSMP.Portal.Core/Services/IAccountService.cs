using CSMP.Portal.Domains;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CSMP.Portal.Services
{
    public interface IAccountService : IService<Account>
    {
        Task<Account> GetByUserNameAsync(string userName);

        Task<bool> VerifyHashedPasswordAsync(Account account, string password);

        Task HashPasswordAsync(Account account, string password);
    }
}
