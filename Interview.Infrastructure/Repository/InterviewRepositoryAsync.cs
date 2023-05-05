using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Interview.ApplicationCore.Contract.Repository;
using Interview.ApplicationCore.Entity;
using Interview.Infrastructure.Data;

namespace Interview.Infrastructure.Repository
{
    public class InterviewRepositoryAsync : BaseRepositoryAsync<Interviews>, IInterviewRepositoryAsync
    {
        public InterviewRepositoryAsync(InterviewManagementDbContext context) : base(context)
        {
        }
    }
}