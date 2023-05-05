using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Onboarding.ApplicationCore.Contract.Repository;
using Onboarding.ApplicationCore.Entity;
using OnBoarding.Infrastructure.Data;

namespace OnBoarding.Infrastructure.Repository
{
    public class EmployeeRoleRepositoryAsync
        : BaseRepositoryAsync<EmployeeRole>,
            IEmployeeRoleRepositoryAsync
    {
        public EmployeeRoleRepositoryAsync(OnBoardDbContext context)
            : base(context) { }
    }
}
