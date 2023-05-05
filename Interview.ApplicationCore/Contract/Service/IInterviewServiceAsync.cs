using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Interview.ApplicationCore.Model;

namespace Interview.ApplicationCore.Contract.Service
{
    public interface IInterviewServiceAsync
    {
         Task<int> AddInterviewAsync(InterviewRequestModel model);
    Task<int> UpdateInterviewAsync(InterviewRequestModel model);
    Task<int> DeleteInterviewAsync(int id);
    Task<InterviewResponseModel> GetInterviewByIdAsync(int id);
    Task<IEnumerable<InterviewResponseModel>> GetAllInterviewsAsync();
    }
}