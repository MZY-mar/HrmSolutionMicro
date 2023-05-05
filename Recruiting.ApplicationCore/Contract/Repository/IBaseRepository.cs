using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Recruiting.ApplicationCore.Contract.Repository{
    public interface IBaseRepository<T> where T : class
    {
        Task<int> InsertAsync(T entity);
        Task<int> UpdateAsync(T entity);
        Task<int> DeleteAsync(int id);
        Task<T> GetByIdAsync(int id);
        Task<IEnumerable<T>> GetAllAsync();
    }
}