using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Onboarding.ApplicationCore.Contract.Repository;
using Onboarding.ApplicationCore.Entity;
using OnBoarding.Infrastructure.Data;

namespace OnBoarding.Infrastructure.Repository
{
    public class EmployeeStatusRepositoryAsync
        : BaseRepositoryAsync<EmployeeStatus>,
            IEmployeeStatusRepositoryAsync
    {
        public EmployeeStatusRepositoryAsync(OnBoardDbContext context)
            : base(context) { }
    }
}
