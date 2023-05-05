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
    public class JobRequirementServiceAsync : IJobRequirementServiceAsync
    {
        private IJobRequirementRepository _repository;

        public JobRequirementServiceAsync(IJobRequirementRepository repository)
        {
            _repository = repository;
        }

        public Task<int> AddJobRequirementAsync(JobRequirementModel model)
        {
            JobRequirement jobRequirement = new JobRequirement()
            {
                Id = model.Id,
                Title = model.Title,
                Description = model.Description,
                NumberOfPosition = model.NumberOfPosition,
                HiringManagerId = model.HiringManagerId,
                HiringManagerName = model.HiringManagerName,
                StartDate = model.StartDate,
                IsActive = model.IsActive,
                ClosedOn = model.ClosedOn,
                ClosedReason = model.ClosedReason,
                CreatedOn = model.CreatedOn,
                JobCategoryId = model.JobCategoryId,
            };
            return _repository.InsertAsync(jobRequirement);
        }

        public Task<int> DeleteJobRequirementAsync(int id)
        {
            return _repository.DeleteAsync(id);
        }

        public async Task<IEnumerable<JobRequirementModel>> GetAllJobRequirementsAsync()
        {
            var result = await _repository.GetAllAsync();
            if (result != null)
            {
                return result
                    .ToList()
                    .Select(
                        model =>
                            new JobRequirementModel()
                            {
                                Id = model.Id,
                                Title = model.Title,
                                Description = model.Description,
                                NumberOfPosition = model.NumberOfPosition,
                                HiringManagerId = model.HiringManagerId,
                                HiringManagerName = model.HiringManagerName,
                                StartDate = model.StartDate,
                                IsActive = model.IsActive,
                                ClosedOn = model.ClosedOn,
                                ClosedReason = model.ClosedReason,
                                JobCategoryId = model.JobCategoryId
                            }
                    );
            }
            return null;
        }

        public async Task<JobRequirementModel> GetJobRequirementByIdAsync(int id)
        {
            var entity = await _repository.GetJobRequirementByIdAsync(id);
            if (entity != null)
            {
                return new JobRequirementModel()
                {
                    Id = entity.Id,
                    Title = entity.Title,
                    Description = entity.Description,
                    NumberOfPosition = entity.NumberOfPosition,
                    HiringManagerId = entity.HiringManagerId,
                    HiringManagerName = entity.HiringManagerName,
                    StartDate = entity.StartDate,
                    IsActive = entity.IsActive,
                    ClosedOn = entity.ClosedOn,
                    ClosedReason = entity.ClosedReason,
                    JobCategoryId = entity.JobCategoryId,
                    JobCategoryModel = new JobCategoryModel()
                    {
                        Id = entity.JobCategory.Id,
                        Name = entity.JobCategory.Name
                    }
                };
            }

            return null;
        }

        public Task<int> UpdateJobRequirementAsync(JobRequirementModel model)
        {
            JobRequirement jobRequirement = new JobRequirement()
            {
                Id = model.Id,
                Title = model.Title,
                Description = model.Description,
                NumberOfPosition = model.NumberOfPosition,
                HiringManagerId = model.HiringManagerId,
                HiringManagerName = model.HiringManagerName,
                StartDate = model.StartDate,
                IsActive = model.IsActive,
                ClosedReason = model.ClosedReason,
                JobCategoryId = model.JobCategoryId,
            };
            return _repository.UpdateAsync(jobRequirement);
        }
    }
}
