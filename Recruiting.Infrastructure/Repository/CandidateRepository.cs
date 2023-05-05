
using Recruiting.ApplicationCore.Contract.Repository;
using Recruiting.ApplicationCore.Entity;
using Recruiting.Infrastructure.Data;

namespace  Recruiting.Infrastructure.Repository
{
    public class CandidateRepository : BaseRepository<Candidate>, ICandidateRepository
    {
        public CandidateRepository(RecruitingDbContext context) : base(context)
        {
        }
    }
}