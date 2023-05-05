using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Recruiting.ApplicationCore.Contract.Repository;
using Recruiting.ApplicationCore.Entity;
using Recruiting.ApplicationCore.Model;
using Recruiting.Infrastructure.Data;

namespace Recruiting.Infrastructure.Repository
{
    public class JobRequirementRepository
        : BaseRepository<JobRequirement>,
            IJobRequirementRepository
    {
        public JobRequirementRepository(RecruitingDbContext context)
            : base(context) { }

        public async Task<JobRequirement> GetJobRequirementByIdAsync(int id)
        {
            return await _context.JobRequirements
                .Include(j => j.JobCategory)
                .FirstAsync(j => j.Id == id);
        }
    }
}
