using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Onboarding.ApplicationCore.Contract.Model;

namespace Onboarding.ApplicationCore.Contract.Service
{
    public interface IEmloyeeStatusServiceAsync
    {
        Task<int> AddEmployeeStatusAsync(EmployeeStatusModel model);
        Task<int> UpdateEmployeeStatusAsync(EmployeeStatusModel model);
        Task<int> DeleteEmployeeStatusAsync(int id);
        Task<EmployeeStatusModel> GetEmployeeStatusByIdAsync(int id);
        Task<IEnumerable<EmployeeStatusModel>> GetAllEmployeeStatusesAsync();
    }
}
