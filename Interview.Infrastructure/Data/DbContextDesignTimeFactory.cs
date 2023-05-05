using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Interview.Infrastructure.Data
{
    public class DbContextDesignTimeFactory
        : IDesignTimeDbContextFactory<InterviewManagementDbContext>
    {
        public InterviewManagementDbContext CreateDbContext(string[] args)
        {
            DbContextOptionsBuilder<InterviewManagementDbContext> builder =
                new DbContextOptionsBuilder<InterviewManagementDbContext>();
            builder.UseSqlServer(
                "Server=localhost;Database=interviewApi;User Id=sa;Password=root1234%;Integrated Security=False;TrustServerCertificate=True"
            );
            return new InterviewManagementDbContext(builder.Options);
        }
    }
}
