using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Interview.ApplicationCore.Contract.Repository;
using Interview.ApplicationCore.Contract.Service;
using Interview.ApplicationCore.Entity;
using Interview.ApplicationCore.Model;

namespace Interview.Infrastructure.Service
{
    public class InterviewFeedbackServiceAsync :  IInterviewFeedbackServiceAsync
    {
         private readonly  IInterviwerFeedbackRepositoryAsync  _repository;

    public InterviewFeedbackServiceAsync( IInterviwerFeedbackRepositoryAsync repository)
    {
        _repository = repository;
    }

    public async Task<int> AddInterviewFeedbackAsync(InterviewFeedbackRequestModel model)
    {
        var entity = new InterviewFeedback
        {
           
            Rating = model.Rating,
            Comment = model.Comment
        };

        return await _repository.InsertAsync(entity);
    }

    public async Task<int> DeleteInterviewFeedbackAsync(int id)
    {
        return await _repository.DeleteAsync(id);
    }

    public async Task<IEnumerable<InterviewFeedbackResponseModel>> GetAllInterviewFeedbackAsync()
    {
        var entities = await _repository.GetAllAsync();
        return entities.Select(e => new InterviewFeedbackResponseModel
        {
            Id = e.Id,
            Rating = e.Rating,
            Comment = e.Comment
        });
    }

        public async Task<IEnumerable<InterviewFeedbackResponseModel>> GetAllInterviewFeedbacksAsync()
        {
            var result = await _repository.GetAllAsync();
            
              if(result != null){
                return result.ToList().Select( feedback => new InterviewFeedbackResponseModel(){
                  
                     Id = feedback.Id,
                     Comment = feedback.Comment,
                    Rating = feedback.Rating
                });
           }
           return null;
              
        }

        

        public async Task<InterviewFeedbackResponseModel> GetInterviewFeedbackByIdAsync(int id)
    {
        var entity = await _repository.GetByIdAsync(id);
        if (entity == null)
        {
            return null;
        }

        return new InterviewFeedbackResponseModel
        {
            Id = entity.Id,
            Rating = entity.Rating,
            Comment = entity.Comment
        };
    }

    public async Task<int> UpdateInterviewFeedbackAsync(InterviewFeedbackRequestModel model)
    {
        var entity = await _repository.GetByIdAsync(model.Id);
        if (entity == null)
        {
            return 0;
        }
        entity.Rating = model.Rating;
        entity.Comment = model.Comment;

        return await _repository.UpdateAsync(entity);
    }
    }
}