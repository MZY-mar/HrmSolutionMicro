using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Onboarding.ApplicationCore.Contract.Model;
using Onboarding.ApplicationCore.Model.Post;

namespace Onboarding.ApplicationCore.Contract.Service
{
    public interface IEmloyeeCategoryServiceAsync
    {
        Task<int> AddEmployeeCategoryAsync(EmployeeCategoryPostModel model);
        Task<int> UpdateEmployeeCategoryAsync(EmployeeCategoryModel model);
        Task<int> DeleteEmployeeCategoryAsync(int id);
        Task<EmployeeCategoryModel> GetEmployeeCategoryByIdAsync(int id);
        Task<IEnumerable<EmployeeCategoryModel>> GetAllEmployeeCategorysAsync();
    }
}
