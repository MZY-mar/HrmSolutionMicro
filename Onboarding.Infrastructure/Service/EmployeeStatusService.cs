using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Onboarding.ApplicationCore.Contract.Model;
using Onboarding.ApplicationCore.Contract.Repository;
using Onboarding.ApplicationCore.Contract.Service;
using Onboarding.ApplicationCore.Entity;

namespace OnBoarding.Infrastructure.Service
{
    public class EmployeeStatusService : IEmloyeeStatusServiceAsync
    {
        private readonly IEmployeeStatusRepositoryAsync _employeeStatusRepository;

        public EmployeeStatusService(IEmployeeStatusRepositoryAsync employeeStatusRepository)
        {
            _employeeStatusRepository = employeeStatusRepository;
        }

        public async Task<int> AddEmployeeStatusAsync(EmployeeStatusModel model)
        {
            var entity = new EmployeeStatus { Description = model.Description, ABBR = model.ABBR };
            await _employeeStatusRepository.InsertAsync(entity);
            return entity.Id;
        }

        public async Task<int> UpdateEmployeeStatusAsync(EmployeeStatusModel model)
        {
            var entity = await _employeeStatusRepository.GetByIdAsync(model.Id);
            if (entity == null)
            {
                return 0;
            }
            entity.Description = model.Description;
            entity.ABBR = model.ABBR;
            await _employeeStatusRepository.UpdateAsync(entity);
            return entity.Id;
        }

        public async Task<int> DeleteEmployeeStatusAsync(int id)
        {
            return await _employeeStatusRepository.DeleteAsync(id);
        }

        public async Task<EmployeeStatusModel> GetEmployeeStatusByIdAsync(int id)
        {
            var entity = await _employeeStatusRepository.GetByIdAsync(id);
            if (entity == null)
            {
                return null;
            }
            return new EmployeeStatusModel
            {
                Id = entity.Id,
                Description = entity.Description,
                ABBR = entity.ABBR
            };
        }

        public async Task<IEnumerable<EmployeeStatusModel>> GetAllEmployeeStatusesAsync()
        {
            var entities = await _employeeStatusRepository.GetAllAsync();
            return entities.Select(
                entity =>
                    new EmployeeStatusModel
                    {
                        Id = entity.Id,
                        Description = entity.Description,
                        ABBR = entity.ABBR
                    }
            );
        }
    }
}
