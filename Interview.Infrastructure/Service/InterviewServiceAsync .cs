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
    public class InterviewServiceAsync : IInterviewServiceAsync
{
    private readonly IInterviewRepositoryAsync _repository;

    public InterviewServiceAsync(IInterviewRepositoryAsync repository)
    {
        _repository = repository;
    }

    public async Task<int> AddInterviewAsync(InterviewRequestModel model)
    {
        var entity = new Interviews
        {
            RecruiterId = model.RecruiterId,
            SubmissionId = model.SubmissionId,
            InterviewTypeCode = model.InterviewTypeCode,
            InterviewRound = model.InterviewRound,
            ScheduledOn = model.ScheduledOn,
            InterviewerId = model.InterviewerId,
            FeedbackId = model.FeedbackId
        };

        return await _repository.InsertAsync(entity);
    }


        public async Task<int> DeleteInterviewAsync(int id)
    {
        return await _repository.DeleteAsync(id);
    }

    public async Task<IEnumerable<InterviewResponseModel>> GetAllInterviewsAsync()
    {
        var entities = await _repository.GetAllAsync();
        return entities.Select(e => new InterviewResponseModel
        {
            Id = e.Id,
            RecruiterId = e.RecruiterId,
            SubmissionId = e.SubmissionId,
            InterviewTypeCode = e.InterviewTypeCode,
            InterviewRound = e.InterviewRound,
            ScheduledOn = e.ScheduledOn,
            InterviewerId = e.InterviewerId,
            FeedbackId = e.FeedbackId
        });
    }

    public async Task<InterviewResponseModel> GetInterviewByIdAsync(int id)
    {
        var entity = await _repository.GetByIdAsync(id);
        if (entity == null)
        {
            return null;
        }

        return new InterviewResponseModel
        {
            Id = entity.Id,
            RecruiterId = entity.RecruiterId,
            SubmissionId = entity.SubmissionId,
            InterviewTypeCode = entity.InterviewTypeCode,
            InterviewRound = entity.InterviewRound,
            ScheduledOn = entity.ScheduledOn,
            InterviewerId = entity.InterviewerId,
            FeedbackId = entity.FeedbackId
        };
    }

    public async Task<int> UpdateInterviewAsync(InterviewRequestModel model)
    {
        var entity = await _repository.GetByIdAsync(model.Id);
        if (entity == null)
        {
            return 0;
        }

        entity.RecruiterId = model.RecruiterId;
        entity.SubmissionId = model.SubmissionId;
        entity.InterviewTypeCode = model.InterviewTypeCode;
        entity.InterviewRound = model.InterviewRound;
        entity.ScheduledOn = model.ScheduledOn;
        entity.InterviewerId = model.InterviewerId;
        entity.FeedbackId = model.FeedbackId;

        return await _repository.UpdateAsync(entity);
    }

       

    }

}