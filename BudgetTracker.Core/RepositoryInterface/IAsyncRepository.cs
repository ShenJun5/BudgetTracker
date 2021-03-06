using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BudgetTracker.Core
{
    public interface IAsyncRepository<T> where T: class
    {
        //add
        Task<T> AddAsync(T entity);

        //update
        Task<T> UpdateAsync(T entity);

        //delete
        Task<T> DeleteAsync(T entity);

        //read(list)
        Task<T> GetByIdAsync(int id);
        Task<IEnumerable<T>> ListAllAsync();
        Task<IEnumerable<T>> ListAsync(Expression<Func<T, bool>> filter);
        Task<int> GetCountAsync(Expression<Func<T, bool>> filter = null);
        Task<bool> GetExistingAsync(Expression<Func<T, bool>> filter = null);

    }
}
