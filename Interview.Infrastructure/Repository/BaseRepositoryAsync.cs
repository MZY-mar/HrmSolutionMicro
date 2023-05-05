using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Interview.ApplicationCore.Contract.Repository;
using Interview.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Interview.Infrastructure.Repository
{
    public class BaseRepositoryAsync<T> : IBaseRepositoryAsync<T> where T : class
    {

        private readonly InterviewManagementDbContext _dbContext;
        
        public BaseRepositoryAsync(InterviewManagementDbContext context){
            _dbContext = context;
        }
        public async Task<int> DeleteAsync(int id)
        {
            var entity = await _dbContext.Set<T>().FindAsync(id);
            if(entity != null){
                _dbContext.Set<T>().Remove(entity);
                return await _dbContext.SaveChangesAsync();
            }
            return -1;
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _dbContext.Set<T>().ToListAsync();
        }

        public async Task<T> GetByIdAsync(int id)
        {
           return await _dbContext.Set<T>().FindAsync(id);
         
        }

        public async Task<int> InsertAsync(T entity)
        {
          if(entity == null){
            return -1;
          }
          _dbContext.Set<T>().Add(entity);
         return await _dbContext.SaveChangesAsync();

        }

        public async Task<int> UpdateAsync(T entity)
        {
           if(entity == null){
            return -1;
            }
            _dbContext.Entry(entity).State = EntityState.Modified;
            return await _dbContext.SaveChangesAsync();
        }
    }
}