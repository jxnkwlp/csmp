using System.Linq;
using System.Threading.Tasks;

namespace CSMP.Portal.Services
{
    public interface IService<T> where T : class
    {
        Task CreateAsync(T entity, bool save = true);

        Task UpdateAsync(T entity, bool save = true);

        Task DeleteAsync(T entity, bool save = true);

        Task DeleteAsync(int id, bool save = true);

        Task<T> GetByIdAsync(int id);

        IQueryable<T> GetAll();

    }
}
