using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Interview.ApplicationCore.Contract.Repository;
using Interview.ApplicationCore.Entity;
using Interview.Infrastructure.Data;

namespace Interview.Infrastructure.Repository
{
    public class RecruiterRepository : BaseRepositoryAsync<Recruiter>, IRecruiterRepositoryAsync
    {
        public RecruiterRepository(InterviewManagementDbContext context) : base(context)
        {
        }
    }
}