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
    public class EmployeeServiceAsync : IEmloyeeServiceAsync
    {
        private readonly IEmployeeRepository _repository;

        public EmployeeServiceAsync(IEmployeeRepository repository)
        {
            _repository = repository;
        }

        public async Task<int> AddEmployeeAsync(EmployeeModel model)
        {
            var employee = new Employee
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                MiddleName = model.MiddleName,
                SSN = model.SSN,
                HireDate = model.HireDate,
                EndDate = model.EndDate,
                EmployeeCategoryCode = model.EmployeeCategoryCode,
                EmployeeStatusCode = model.EmployeeStatusCode,
                Address = model.Address,
                Email = model.Email,
                EmployeeRoleId = model.EmployeeRoleId
            };
            return await _repository.InsertAsync(employee);
        }

        public async Task<int> DeleteEmployeeAsync(int id)
        {
            return await _repository.DeleteAsync(id);
        }

        public async Task<IEnumerable<EmployeeModel>> GetAllEmployeesAsync()
        {
            var employees = await _repository.GetAllAsync();
            return employees.Select(
                x =>
                    new EmployeeModel
                    {
                        Id = x.Id,
                        FirstName = x.FirstName,
                        LastName = x.LastName,
                        MiddleName = x.MiddleName,
                        SSN = x.SSN,
                        HireDate = x.HireDate,
                        EndDate = x.EndDate,
                        EmployeeCategoryCode = x.EmployeeCategoryCode,
                        EmployeeStatusCode = x.EmployeeStatusCode,
                        Address = x.Address,
                        Email = x.Email,
                        EmployeeRoleId = x.EmployeeRoleId
                    }
            );
            return null;
        }

        public async Task<EmployeeModel> GetEmployeeByIdAsync(int id)
        {
            var employee = await _repository.GetByIdAsync(id);
            if (employee == null)
            {
                return null;
            }
            return new EmployeeModel
            {
                Id = employee.Id,
                FirstName = employee.FirstName,
                LastName = employee.LastName,
                MiddleName = employee.MiddleName,
                SSN = employee.SSN,
                HireDate = employee.HireDate,
                EndDate = employee.EndDate,
                EmployeeCategoryCode = employee.EmployeeCategoryCode,
                EmployeeStatusCode = employee.EmployeeStatusCode,
                Address = employee.Address,
                Email = employee.Email,
                EmployeeRoleId = employee.EmployeeRoleId
            };
        }

        public async Task<int> UpdateEmployeeAsync(EmployeeModel model)
        {
            var employee = await _repository.GetByIdAsync(model.Id);
            if (employee == null)
            {
                return 0;
            }
            employee.FirstName = model.FirstName;
            employee.LastName = model.LastName;
            employee.MiddleName = model.MiddleName;
            employee.SSN = model.SSN;
            employee.HireDate = model.HireDate;
            employee.EndDate = model.EndDate;
            employee.EmployeeCategoryCode = model.EmployeeCategoryCode;
            employee.EmployeeStatusCode = model.EmployeeStatusCode;
            employee.Address = model.Address;
            employee.Email = model.Email;
            employee.EmployeeRoleId = model.EmployeeRoleId;
            await _repository.UpdateAsync(employee);
            return 1;
        }
    }
}
