using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;

namespace CSMP.Portal.Services
{
	public interface IService<T> where T : class
	{
		Task CreateAsync(T entity);

		Task UpdateAsync(T entity);

		Task DeleteAsync(T entity);

		Task DeleteAsync(int id);

		Task<T> GetByIdAsync(int id);

		IQueryable<T> GetAll();

	}
}
