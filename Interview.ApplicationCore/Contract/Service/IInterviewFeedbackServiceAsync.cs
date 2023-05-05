using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Interview.ApplicationCore.Model;

namespace Interview.ApplicationCore.Contract.Service
{
    public interface IInterviewFeedbackServiceAsync
    {
        Task<int> AddInterviewFeedbackAsync(InterviewFeedbackRequestModel model);
        Task<int> UpdateInterviewFeedbackAsync(InterviewFeedbackRequestModel model);
        Task<int> DeleteInterviewFeedbackAsync(int id);
        Task<InterviewFeedbackResponseModel> GetInterviewFeedbackByIdAsync(int id);
        Task<IEnumerable<InterviewFeedbackResponseModel>> GetAllInterviewFeedbacksAsync();
    }
}
