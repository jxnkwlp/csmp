using CSMP.Portal.Data;
using CSMP.Portal.Domains;
using Passingwind.UnitOfWork;
using System.Linq;
using System.Threading.Tasks;

namespace CSMP.Portal.Services
{
	public abstract class BaseService<T> : IService<T> where T : BaseEntity
	{
		protected IUnitOfWork<AppDbContext> UnitOfWork { get; }

		protected IRepository<T> Repository { get; }

		protected ICacheService CacheService { get; }

		//protected bool UseCache { get; }

		public BaseService(IUnitOfWork<AppDbContext> unitOfWork, ICacheService cacheService)
		{
			UnitOfWork = unitOfWork;
			Repository = UnitOfWork.GetRepository<T>();
			CacheService = cacheService;
		}

		public virtual async Task CreateAsync(T entity)
		{
			await Repository.InsertAsync(entity);
		}

		public virtual async Task DeleteAsync(T entity)
		{
			await Repository.DeleteAsync(entity);
		}

		public virtual async Task DeleteAsync(int id)
		{
			await Repository.DeleteAsync(t => t.Id == id);
		}

		public virtual async Task<T> GetByIdAsync(int id)
		{
			return await Repository.GetAsync(id);
		}

		public virtual async Task UpdateAsync(T entity)
		{
			await Repository.UpdateAsync(entity);
		}

		public virtual IQueryable<T> GetAll()
		{
			return Repository.GetQueryable();
		}

	}
}
