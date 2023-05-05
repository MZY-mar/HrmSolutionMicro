
using Recruiting.ApplicationCore.Contract.Service;
using Recruiting.ApplicationCore.Entity;
using Recruiting.ApplicationCore.Model;
using Recruiting.ApplicationCore.Contract.Repository;
namespace  Recruiting.Infrastructure.Service
{
    public class CandidateServiceAsync : ICandidateServiceAsync
    {

       private ICandidateRepository _repository ;

        public CandidateServiceAsync(ICandidateRepository repository)
        {
            _repository = repository;
        }

        public Task<int> AddCandidateAsync(CandidateModel model)
        {
           Candidate candidate = new Candidate(){
                FirstName = model.FirstName,
                LastName = model.LastName,
                Email = model.Email,
                Mobile = model.Mobile,
                ResumeUrl = ""
           };
           return _repository.InsertAsync(candidate);
        }

        public Task<int> DeleteCandidateAsync(int id)
        {
           return _repository.DeleteAsync(id);
        }

        public async Task<IEnumerable<CandidateModel>> GetAllCandidatesAsync()
        {
            var result = await _repository.GetAllAsync();
            if(result != null){
                return result.ToList().Select(
                    x => new CandidateModel(){
                        Id = x.Id, 
                        Email = x.Email, 
                        FirstName = x.FirstName,
                         LastName = x.LastName, 
                         Mobile = x.Mobile
                    }
                );
            }
            return null;
        }

        public async Task<CandidateModel> GetCandidateByIdAsync(int id)
        {
            var result = await _repository.GetByIdAsync(id);
            if(result != null){
                return new CandidateModel()
                {
                    Id = result.Id,
                    FirstName = result.FirstName,
                    LastName = result.LastName,
                    Mobile = result.Mobile,
                    Email= result.Email

                };
            }

            return null;
        }

        public Task<int> UpdateCandidateAsync(CandidateModel model)
        {
            
            Candidate candidate = new Candidate()
            {
                Id = model.Id,
                Email = model.Email,
                FirstName = model.FirstName,
                LastName = model.LastName,
                Mobile = model.Mobile
            };
            return _repository.UpdateAsync(candidate);
        }
    }
}