using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Onboarding.ApplicationCore.Entity;

namespace OnBoarding.Infrastructure.Data
{
    public class OnBoardDbContext : DbContext
    {
        public OnBoardDbContext(DbContextOptions<OnBoardDbContext> options)
            : base(options) { }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<EmployeeRole> EmployeeRoles { get; set; }
        public DbSet<EmployeeStatus> EmployeeStatuses { get; set; }
        private DbSet<EmployeeCategory> employeeCategories { get; set; }
    }
}
