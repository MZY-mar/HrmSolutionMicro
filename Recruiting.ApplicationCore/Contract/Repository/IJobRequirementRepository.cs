using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Recruiting.ApplicationCore.Entity;

namespace Recruiting.ApplicationCore.Contract.Repository
{
    public interface IJobRequirementRepository : IBaseRepository<JobRequirement>
    {
        public Task<JobRequirement> GetJobRequirementByIdAsync(int id);
    }
}
