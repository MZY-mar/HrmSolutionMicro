using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Interview.ApplicationCore.Model;

namespace Interview.ApplicationCore.Contract.Service
{
    public interface IRecruiterServiceAsync
    {
        Task<int> AddRecruiterAsync(RecruiterRequestModel model);
     Task<int> UpdateRecruiterAsync(RecruiterRequestModel model);
    Task<int> DeleteRecruiterAsync(int id);
    Task<RecruiterResponseModel> GetRecruiterByIdAsync(int id);
    Task<IEnumerable<RecruiterResponseModel>> GetAllRecruitersAsync();

    }
}