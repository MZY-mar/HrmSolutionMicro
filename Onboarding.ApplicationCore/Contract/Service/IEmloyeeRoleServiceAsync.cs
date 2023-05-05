using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Onboarding.ApplicationCore.Contract.Model;

namespace Onboarding.ApplicationCore.Contract.Service
{
    public interface IEmloyeeRoleServiceAsync
    {
        Task<int> AddEmployeeRoleAsync(EmployeeRoleModel model);
        Task<int> UpdateEmployeeRoleAsync(EmployeeRoleModel model);
        Task<int> DeleteEmployeeRoleAsync(int id);
        Task<EmployeeRoleModel> GetEmployeeRoleByIdAsync(int id);
        Task<IEnumerable<EmployeeRoleModel>> GetAllEmployeeRolesAsync();
    }
}
