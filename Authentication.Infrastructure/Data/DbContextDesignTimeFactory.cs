using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Authentication.Infrastructure.Data
{
    public class DbContextDesignTimeFactory : IDesignTimeDbContextFactory<AuthenticationDbContext>
    {
        public AuthenticationDbContext CreateDbContext(string[] args)
        {
            DbContextOptionsBuilder<AuthenticationDbContext> builder =
                new DbContextOptionsBuilder<AuthenticationDbContext>();
            builder.UseSqlServer(
                "Server=localhost;Database=Authentication;User Id=sa;Password=root1234%;Integrated Security=False;TrustServerCertificate=True"
            );
            return new AuthenticationDbContext(builder.Options);
        }
    }
}
