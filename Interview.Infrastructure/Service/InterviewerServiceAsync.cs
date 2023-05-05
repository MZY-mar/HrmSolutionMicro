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
    public class InterviewerServiceAsync : IInterviewerServiceAsync
{
    private readonly IInterviewerRepositoryAsync _repository;

    public InterviewerServiceAsync(IInterviewerRepositoryAsync repository)
    {
        _repository = repository;
    }

    public async Task<int> AddInterviewerAsync(InterviewerRequestModel model)
    {
        var entity = new Interviewer
        {
            FristName = model.FristName,
            LastName = model.LastName,
            EmployeeId = model.EmployeeId
        };

        return await _repository.InsertAsync(entity);
    }

        public async Task<int> DeleteInterviewerAsync(int id)
    {
        return await _repository.DeleteAsync(id);
    }

    public async Task<IEnumerable<InterviewerResponseModel>> GetAllInterviewersAsync()
    {
        var entities = await _repository.GetAllAsync();
        return entities.Select(e => new InterviewerResponseModel
        {
            Id = e.Id,
            FristName = e.FristName,
            LastName = e.LastName,
            EmployeeId = e.EmployeeId
        });
    }

    public async Task<InterviewerResponseModel> GetInterviewerByIdAsync(int id)
    {
        var entity = await _repository.GetByIdAsync(id);
        if (entity == null)
        {
            return null;
        }

        return new InterviewerResponseModel
        {
            Id = entity.Id,
            FristName = entity.FristName,
            LastName = entity.LastName,
            EmployeeId = entity.EmployeeId
        };
    }

    public async Task<int> UpdateInterviewerAsync(InterviewerRequestModel model)
    {
        var entity = await _repository.GetByIdAsync(model.Id);
        if (entity == null)
        {
            return 0;
        }

        entity.FristName = model.FristName;
        entity.LastName = model.LastName;
        entity.EmployeeId = model.EmployeeId;

        return await _repository.UpdateAsync(entity);
    }



    
    }

}