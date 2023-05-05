
using Microsoft.EntityFrameworkCore;
using Recruiting.ApplicationCore.Contract.Repository;
using Recruiting.Infrastructure.Data;

namespace  Recruiting.Infrastructure.Repository
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        protected readonly RecruitingDbContext _context;

        public BaseRepository(RecruitingDbContext context)
        {
            _context = context;
        }

     public async Task<int> DeleteAsync(int id)
        {

            /*var customer = dbContext.Customers.Find(1);
            var deletedCustomer = dbContext.Customers.Remove(customer);
            dbContext.SaveChanges();*/
           var entity = await _context.Set<T>().FindAsync(id);
           if(entity != null){
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
            _context.Set<T>().Add(entity);
            return await _context.SaveChangesAsync();
        }

        public async Task<int> UpdateAsync(T entity)
        {
          _context.Entry(entity).State = EntityState.Modified;
          return await _context.SaveChangesAsync();
        }
    }
}