using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Interview.ApplicationCore.Contract.Repository
{
    public interface IBaseRepositoryAsync<T>
        where T : class
    {
        Task<int> InsertAsync(T entity);
        Task<int> UpdateAsync(T entity);
        Task<int> DeleteAsync(int id);
        Task<T> GetByIdAsync(int id);
        Task<IEnumerable<T>> GetAllAsync();
    }
}
