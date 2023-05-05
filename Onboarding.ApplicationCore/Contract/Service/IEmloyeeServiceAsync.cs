using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Onboarding.ApplicationCore.Contract.Model;

namespace Onboarding.ApplicationCore.Contract.Service
{
    public interface IEmloyeeServiceAsync
    {
        Task<int> AddEmployeeAsync(EmployeeModel model);
        Task<int> UpdateEmployeeAsync(EmployeeModel model);
        Task<int> DeleteEmployeeAsync(int id);
        Task<EmployeeModel> GetEmployeeByIdAsync(int id);
        Task<IEnumerable<EmployeeModel>> GetAllEmployeesAsync();
    }
}
