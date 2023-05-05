using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Onboarding.ApplicationCore.Contract.Repository;
using Onboarding.ApplicationCore.Entity;
using OnBoarding.Infrastructure.Data;

namespace OnBoarding.Infrastructure.Repository
{
    public class EmployeeCategoryRepositoryAsync
        : BaseRepositoryAsync<EmployeeCategory>,
            IEmployeeCategoryRepositoryAsync
    {
        public EmployeeCategoryRepositoryAsync(OnBoardDbContext context)
            : base(context) { }
    }
}
