using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Onboarding.ApplicationCore.Contract.Model;
using Onboarding.ApplicationCore.Contract.Repository;
using Onboarding.ApplicationCore.Contract.Service;
using Onboarding.ApplicationCore.Entity;
using Onboarding.ApplicationCore.Model.Post;

namespace OnBoarding.Infrastructure.Service
{
    public class EmployeeCategoryService : IEmloyeeCategoryServiceAsync
    {
        private readonly IEmployeeCategoryRepositoryAsync _employeeCategoryRepository;

        public EmployeeCategoryService(IEmployeeCategoryRepositoryAsync employeeCategoryRepository)
        {
            _employeeCategoryRepository = employeeCategoryRepository;
        }

        public async Task<int> AddEmployeeCategoryAsync(EmployeeCategoryPostModel model)
        {
            var entity = new EmployeeCategory { Description = model.Description };
            await _employeeCategoryRepository.InsertAsync(entity);
            return entity.Id;
        }

        public async Task<int> UpdateEmployeeCategoryAsync(EmployeeCategoryModel model)
        {
            var entity = await _employeeCategoryRepository.GetByIdAsync(model.Id);
            if (entity == null)
            {
                return 0;
            }
            entity.Description = model.Description;
            await _employeeCategoryRepository.UpdateAsync(entity);
            return entity.Id;
        }

        public async Task<int> DeleteEmployeeCategoryAsync(int id)
        {
            return await _employeeCategoryRepository.DeleteAsync(id);
        }

        public async Task<EmployeeCategoryModel> GetEmployeeCategoryByIdAsync(int id)
        {
            var entity = await _employeeCategoryRepository.GetByIdAsync(id);
            if (entity == null)
            {
                return null;
            }
            return new EmployeeCategoryModel { Id = entity.Id, Description = entity.Description };
        }

        public async Task<IEnumerable<EmployeeCategoryModel>> GetAllEmployeeCategorysAsync()
        {
            var entities = await _employeeCategoryRepository.GetAllAsync();
            return entities.Select(
                entity =>
                    new EmployeeCategoryModel { Id = entity.Id, Description = entity.Description }
            );
        }
    }
}
