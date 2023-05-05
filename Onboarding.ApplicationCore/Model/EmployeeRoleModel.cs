using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Onboarding.ApplicationCore.Contract.Model
{
    public class EmployeeRoleModel
    {
        public int Id { get; set; }

        [Column(TypeName = "nvarchar(512)")]
        public string Name { get; set; }

        [Column(TypeName = "nvarchar(9")]
        public string ABBR { get; set; }
    }
}
