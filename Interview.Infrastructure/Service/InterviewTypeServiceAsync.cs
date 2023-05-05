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
    public class InterviewTypeServiceAsync : IInterviewTypeServiceAsync
    {

        private readonly IInterviewTypeRepositoryAsync _repository;

        public InterviewTypeServiceAsync(IInterviewTypeRepositoryAsync repository)
        {
            _repository = repository;
        }

        public Task<int> AddInterviewTypeAsync(InterviewTypeRequestModel model)
        {
            InterviewType interviewType = new InterviewType();
            interviewType.Description = model.Description;
            return _repository.InsertAsync(interviewType);
        }

        public Task<int> DeleteInterviewTypeAsync(int id)
        {
           return _repository.DeleteAsync(id);
        }

        public async Task<IEnumerable<InterviewTypeResponseModel>> GetAllInterviewTypesAsync()
        {
           var list = await _repository.GetAllAsync();
           if(list != null){
                return list.ToList().Select( it => new InterviewTypeResponseModel(){
                  
                    Description = it.Description
                });
           }
           return null;
        }

        public async Task<InterviewTypeResponseModel> GetInterviewTypeByIdAsync(int id)
        {   InterviewType entity = await _repository.GetByIdAsync(id);
            InterviewTypeResponseModel responseModel = new InterviewTypeResponseModel();
             responseModel.Description = entity.Description;
             return responseModel;
        }

        public Task<int> UpdateInterviewTypeAsync(InterviewTypeRequestModel model)
        {
            InterviewType interviewType = new InterviewType();
            
            interviewType.Id = model.Id;
            interviewType.Description = model.Description;
            return _repository.UpdateAsync(interviewType);
        }
    }
}