using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace OnBoarding.Infrastructure.Data
{
    public class DbContextDesignTimeFactory : IDesignTimeDbContextFactory<OnBoardDbContext>
    {
        public OnBoardDbContext CreateDbContext(string[] args)
        {
            DbContextOptionsBuilder<OnBoardDbContext> builder =
                new DbContextOptionsBuilder<OnBoardDbContext>();
            builder.UseSqlServer(
                "Server=localhost;Database=Onboarding;User Id=sa;Password=root1234%;Integrated Security=False;TrustServerCertificate=True"
            );
            return new OnBoardDbContext(builder.Options);
        }
    }
}
