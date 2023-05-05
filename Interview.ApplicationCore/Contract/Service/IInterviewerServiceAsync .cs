using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Interview.ApplicationCore.Model;

namespace Interview.ApplicationCore.Contract.Service
{
    public interface IInterviewerServiceAsync 
    {
         Task<int> AddInterviewerAsync(InterviewerRequestModel model);
    Task<int> UpdateInterviewerAsync(InterviewerRequestModel model);
    Task<int> DeleteInterviewerAsync(int id);
    Task<InterviewerResponseModel> GetInterviewerByIdAsync(int id);
    Task<IEnumerable<InterviewerResponseModel>> GetAllInterviewersAsync();
    }
}