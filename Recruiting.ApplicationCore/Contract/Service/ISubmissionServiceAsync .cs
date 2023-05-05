using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Recruiting.ApplicationCore.Model;

namespace Recruiting.ApplicationCore.Contract.Service
{
    public interface ISubmissionServiceAsync 
    {
        Task<int> AddSubmissionAsync(SubmissionModel model);
        Task<int> UpdateSubmissionAsync(SubmissionModel model);
        Task<int> DeleteSubmissionAsync(int id);
        Task<SubmissionModel> GetSubmissionByIdAsync(int id);
        Task<IEnumerable<SubmissionModel>> GetAllSubmissionsAsync();
    }
}