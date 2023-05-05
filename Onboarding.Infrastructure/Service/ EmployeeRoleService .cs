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
    public class EmployeeRoleService : IEmloyeeRoleServiceAsync
    {
        private readonly IEmployeeRoleRepositoryAsync _employeeRoleRepository;

        public EmployeeRoleService(IEmployeeRoleRepositoryAsync employeeRoleRepository)
        {
            _employeeRoleRepository = employeeRoleRepository;
        }

        public async Task<int> AddEmployeeRoleAsync(EmployeeRoleModel model)
        {
            var entity = new EmployeeRole { Name = model.Name, ABBR = model.ABBR };
            await _employeeRoleRepository.InsertAsync(entity);
            return entity.Id;
        }

        public async Task<int> UpdateEmployeeRoleAsync(EmployeeRoleModel model)
        {
            var entity = await _employeeRoleRepository.GetByIdAsync(model.Id);
            if (entity == null)
            {
                return 0;
            }
            entity.Name = model.Name;
            entity.ABBR = model.ABBR;
            await _employeeRoleRepository.UpdateAsync(entity);
            return entity.Id;
        }

        public async Task<int> DeleteEmployeeRoleAsync(int id)
        {
            return await _employeeRoleRepository.DeleteAsync(id);
        }

        public async Task<EmployeeRoleModel> GetEmployeeRoleByIdAsync(int id)
        {
            var entity = await _employeeRoleRepository.GetByIdAsync(id);
            if (entity == null)
            {
                return null;
            }
            return new EmployeeRoleModel
            {
                Id = entity.Id,
                Name = entity.Name,
                ABBR = entity.ABBR
            };
        }

        public async Task<IEnumerable<EmployeeRoleModel>> GetAllEmployeeRolesAsync()
        {
            var entities = await _employeeRoleRepository.GetAllAsync();
            return entities.Select(
                entity =>
                    new EmployeeRoleModel
                    {
                        Id = entity.Id,
                        Name = entity.Name,
                        ABBR = entity.ABBR
                    }
            );
        }
    }
}
