using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Onboarding.ApplicationCore.Model.Post
{
    public class EmployeeCategoryPostModel
    {
        [Column(TypeName = "nvarchar(512)")]
        public string Description { get; set; }
    }
}
