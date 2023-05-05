using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Recruiting.ApplicationCore.Entity;

namespace Recruiting.Infrastructure.Data
{
    public class RecruitingDbContext : DbContext
    {
        public RecruitingDbContext(DbContextOptions<RecruitingDbContext> options)
            : base(options) { }

        public DbSet<JobCategory> jobCategories { get; set; }
        public DbSet<Candidate> Candidates { get; set; }
        public DbSet<JobRequirement> JobRequirements { get; set; }

        public DbSet<Submission> Submissions { get; set; }
        public DbSet<SubmissionStatus> SubmissionStatus { get; set; }
    }
}
