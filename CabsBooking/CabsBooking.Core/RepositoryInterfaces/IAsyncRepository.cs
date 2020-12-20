using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CabsBooking.Core.RepositoryInterfaces
{
    public interface IAsyncRepository<T> where T : class
    {
        //CRUD operations
        Task<T> AddAsync(T entity);
        Task<T> UpdateAsync(T entity);
        Task DeleteAsync(T entity);
        Task<IEnumerable<T>> ListAllAsync();
        Task<T> GetByIdAsync(int? id);
        Task<IEnumerable<T>> ListAsync(Expression<Func<T, bool>> filter);
    }
}
