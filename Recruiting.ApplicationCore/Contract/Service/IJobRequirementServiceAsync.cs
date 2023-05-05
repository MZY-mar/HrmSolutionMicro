using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Recruiting.ApplicationCore.Model;

namespace Recruiting.ApplicationCore.Contract.Service
{
    public interface IJobRequirementServiceAsync
    {
        Task<int> AddJobRequirementAsync( JobRequirementModel model);
        Task<int> UpdateJobRequirementAsync(JobRequirementModel model);
        Task<int> DeleteJobRequirementAsync(int id);
        Task<JobRequirementModel> GetJobRequirementByIdAsync(int id);
        Task<IEnumerable<JobRequirementModel>> GetAllJobRequirementsAsync();
    }
}