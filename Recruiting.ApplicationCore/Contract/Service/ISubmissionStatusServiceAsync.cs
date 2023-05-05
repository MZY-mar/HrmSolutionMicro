using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Recruiting.ApplicationCore.Model;

namespace Recruiting.ApplicationCore.Contract.Service
{
    public interface ISubmissionStatusServiceAsync
    {
        Task<int> AddSubmissionStatusAsync(SubmissionStatusModel model);
        Task<int> UpdateSubmissionStatusAsync(SubmissionStatusModel model);
        Task<int> DeleteSubmissionStatusAsync(int id);
        Task<SubmissionStatusModel> GetSubmissionStatusByIdAsync(int id);
        Task<IEnumerable<SubmissionStatusModel>> GetAllSubmissionStatusesAsync();
    }
}