using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Recruiting.Infrastructure.Data;

namespace Recruiting.Infrastructure.Data
{
    public class DbContextDesignTimeFactory : IDesignTimeDbContextFactory<RecruitingDbContext>
    {
        public RecruitingDbContext CreateDbContext(string[] args)
        {
            DbContextOptionsBuilder<RecruitingDbContext> builder =
                new DbContextOptionsBuilder<RecruitingDbContext>();
            builder.UseSqlServer(
                "Server=localhost;Database=recruiting;User Id=sa;Password=root1234%;Integrated Security=False;TrustServerCertificate=True"
            );

            return new RecruitingDbContext(builder.Options);
        }
    }
}
