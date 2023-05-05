using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Interview.ApplicationCore.Entity;
using Microsoft.EntityFrameworkCore;

namespace Interview.Infrastructure.Data
{
    public class InterviewManagementDbContext : DbContext
    {
        public InterviewManagementDbContext(DbContextOptions<InterviewManagementDbContext> options)
            : base(options) { }

        public DbSet<Interviewer> Interviewers { get; set; }
        public DbSet<InterviewFeedback> InterviewFeedbacks { get; set; }
        public DbSet<Interviews> Interviews { get; set; }
        public DbSet<InterviewType> InterviewTypes { get; set; }
        public DbSet<Recruiter> Recruiters { get; set; }
    }
}
