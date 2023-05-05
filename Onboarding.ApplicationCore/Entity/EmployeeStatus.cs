using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Onboarding.ApplicationCore.Entity
{
    public class EmployeeStatus
    {
        public int Id { get; set; }

        [Column(TypeName = "nvarchar(512)")]
        public string Description { get; set; }

        [Column(TypeName = "nvarchar(9)")]
        public string ABBR { get; set; }
    }
}
