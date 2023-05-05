using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Recruiting.ApplicationCore.Contract.Repository;
using Recruiting.ApplicationCore.Contract.Service;
using Recruiting.ApplicationCore.Entity;
using Recruiting.ApplicationCore.Model;

namespace Recruiting.Infrastructure.Service
{
    public class SubmissionStatusServiceAsync : ISubmissionStatusServiceAsync
    {
        private readonly ISubmissionStatusRepository _repository;

        public SubmissionStatusServiceAsync(ISubmissionStatusRepository repository)
        {
            _repository = repository;
        }

        public Task<int> AddSubmissionStatusAsync(SubmissionStatusModel model)
        {
            SubmissionStatus status = new SubmissionStatus();
            status.SubmissionStatusCode = model.SubmissionStatusCode;
            status.Description = model.Description;
            return _repository.InsertAsync(status);
        }

        public Task<int> DeleteSubmissionStatusAsync(int id)
        {
            return _repository.DeleteAsync(id);
        }

        public async Task<IEnumerable<SubmissionStatusModel>> GetAllSubmissionStatusesAsync()
        {
            var result = await _repository.GetAllAsync();
            if (result != null)
            {
                return result
                    .ToList()
                    .Select(
                        s =>
                            new SubmissionStatusModel()
                            {
                                Id = s.Id,
                                SubmissionStatusCode = s.SubmissionStatusCode,
                                Description = s.Description
                            }
                    );
            }
            return null;
        }

        public async Task<SubmissionStatusModel> GetSubmissionStatusByIdAsync(int id)
        {
            var entity = await _repository.GetByIdAsync(id);
            if (entity == null)
                return null;
            SubmissionStatusModel model = new SubmissionStatusModel()
            {
                Id = entity.Id,
                SubmissionStatusCode = entity.SubmissionStatusCode,
                Description = entity.Description
            };
            return model;
        }

        public Task<int> UpdateSubmissionStatusAsync(SubmissionStatusModel model)
        {
            SubmissionStatus status = new SubmissionStatus();
            status.Id = model.Id;
            status.Description = model.Description;
            status.SubmissionStatusCode = model.SubmissionStatusCode;
            return _repository.UpdateAsync(status);
        }
    }
}
