using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;
using Onboarding.ApplicationCore.Contract.Repository;
using OnBoarding.Infrastructure.Data;

namespace OnBoarding.Infrastructure.Repository
{
    public class BaseRepositoryAsync<T> : IBaseRepositoryAsync<T>
        where T : class
    {
        protected readonly OnBoardDbContext _context;

        public BaseRepositoryAsync(OnBoardDbContext context)
        {
            _context = context;
        }

        public async Task<int> DeleteAsync(int id)
        {
            var entity = await _context.Set<T>().FindAsync(id);
            if (entity != null)
            {
                _context.Set<T>().Remove(entity);
                return await _context.SaveChangesAsync();
            }
            return 0;
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _context.Set<T>().FindAsync(id);
        }

        public async Task<int> InsertAsync(T entity)
        {
            if (entity != null)
            {
                await _context.AddAsync(entity);
            }
            return await _context.SaveChangesAsync();
        }

        public async Task<int> UpdateAsync(T entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            return await _context.SaveChangesAsync();
        }
    }
}
