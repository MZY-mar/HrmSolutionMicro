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
    public class RecruiterServiceAsync : IRecruiterServiceAsync
    {
        public readonly IRecruiterRepositoryAsync _repository;
        public RecruiterServiceAsync( IRecruiterRepositoryAsync recruiterRepository){
            _repository = recruiterRepository;
        }
        public Task<int> AddRecruiterAsync(RecruiterRequestModel model)
        {       Recruiter recruiter = new Recruiter();
                if(model != null){
                    recruiter.EmployeeId = model.EmployeeId;
                    recruiter.FristName = model.FristName;
                    recruiter.LastName = model.LastName;
                }
                return _repository.InsertAsync(recruiter);
        }

        public Task<int> DeleteRecruiterAsync(int id)
        {
            return _repository.DeleteAsync(id);
        }

        public async Task<IEnumerable<RecruiterResponseModel>> GetAllRecruitersAsync()
        {
            var list = await  _repository.GetAllAsync();
            if(list != null){
                return list.ToList().Select( r => new RecruiterResponseModel(){
                    FristName = r.FristName, LastName = r.LastName
                });
            }
            return null;
        }

        public async Task<RecruiterResponseModel> GetRecruiterByIdAsync(int id)
        {
            var result = await _repository.GetByIdAsync(id);

            if(result != null){
                RecruiterResponseModel recruiter = new RecruiterResponseModel();
                recruiter.FristName = result.FristName;
                recruiter.LastName = result.LastName;
                return recruiter;
            }
            return null;
            
        }

        public Task<int> UpdateRecruiterAsync(RecruiterRequestModel model)
        {
            Recruiter recruiter = new Recruiter();
            recruiter.EmployeeId = model.EmployeeId;
            recruiter.FristName = model.FristName;
            recruiter.LastName = model.LastName;
            recruiter.Id = model.Id;
            return _repository.UpdateAsync(recruiter);
    }
    }
}