using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Recruiting.ApplicationCore.Model;

namespace  Recruiting.ApplicationCore.Contract.Service
{
    public interface ICandidateServiceAsync
    {
        Task<int> AddCandidateAsync(CandidateModel model);
        Task<int> UpdateCandidateAsync(CandidateModel model);
        Task<int> DeleteCandidateAsync(int id);
        Task<CandidateModel> GetCandidateByIdAsync(int id);
        Task<IEnumerable<CandidateModel>> GetAllCandidatesAsync();
    }
}