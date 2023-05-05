using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Recruiting.ApplicationCore.Contract.Repository;
using Recruiting.ApplicationCore.Entity;
using Recruiting.Infrastructure.Data;

namespace Recruiting.Infrastructure.Repository
{
        public class SubmissionRepository : BaseRepository<Submission>, ISubmissionRepository
    {
        public SubmissionRepository(RecruitingDbContext context) : base(context)
        {
        }
    }
}