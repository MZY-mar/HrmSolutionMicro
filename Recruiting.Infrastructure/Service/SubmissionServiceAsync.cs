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
    public class SubmissionServiceAsync : ISubmissionServiceAsync
    {
        private readonly ISubmissionRepository _repository;

        public SubmissionServiceAsync(ISubmissionRepository repository)
        {
            _repository = repository;
        }

        public async Task<int> AddSubmissionAsync(SubmissionModel submission)
        {
            Submission entity = new Submission()
            {
                CandidateId = submission.CandidateId,
                JobRequirementId = submission.JobRequirementId,
                CurrentStatus = submission.CurrentStatus,
                SubmissionStatusCode = submission.SubmissionStatusCode,
                SubmittedOn = submission.SubmittedOn,
                ConfirmedOn = submission.ConfirmedOn,
                RejectedOn = submission.RejectedOn
            };
            return await _repository.InsertAsync(entity);
        }

        public async Task<int> DeleteSubmissionAsync(int id)
        {
            return await _repository.DeleteAsync(id);
        }

        public async Task<IEnumerable<SubmissionModel>> GetAllSubmissionsAsync()
        {
            var result = await _repository.GetAllAsync();
            if (result != null)
            {
                return result.Select(
                    submission =>
                        new SubmissionModel()
                        {
                            Id = submission.Id,
                            CandidateId = submission.CandidateId,
                            JobRequirementId = submission.JobRequirementId,
                            CurrentStatus = submission.CurrentStatus,
                            SubmissionStatusCode = submission.SubmissionStatusCode,
                            SubmittedOn = submission.SubmittedOn,
                            ConfirmedOn = submission.ConfirmedOn,
                            RejectedOn = submission.RejectedOn
                        }
                );
            }
            return null;
        }

        public async Task<SubmissionModel> GetSubmissionByIdAsync(int id)
        {
            var result = await _repository.GetByIdAsync(id);
            if (result != null)
            {
                return new SubmissionModel()
                {
                    Id = result.Id,
                    CandidateId = result.CandidateId,
                    JobRequirementId = result.JobRequirementId,
                    CurrentStatus = result.CurrentStatus,
                    SubmissionStatusCode = result.SubmissionStatusCode,
                    SubmittedOn = result.SubmittedOn,
                    ConfirmedOn = result.ConfirmedOn,
                    RejectedOn = result.RejectedOn
                };
            }
            return null;
        }

        public async Task<int> UpdateSubmissionAsync(SubmissionModel submission)
        {
            Submission entity = new Submission()
            {
                CandidateId = submission.CandidateId,
                JobRequirementId = submission.JobRequirementId,
                CurrentStatus = submission.CurrentStatus,
                SubmissionStatusCode = submission.SubmissionStatusCode,
                SubmittedOn = submission.SubmittedOn,
                ConfirmedOn = submission.ConfirmedOn,
                RejectedOn = submission.RejectedOn
            };
            return await _repository.UpdateAsync(entity);
        }
    }
}
