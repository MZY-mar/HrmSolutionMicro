using System.ComponentModel.DataAnnotations.Schema;

namespace Onboarding.ApplicationCore.Entity
{
    public class EmployeeRole
    {
        public int Id { get; set; }

        [Column(TypeName = "nvarchar(512)")]
        public string Name { get; set; }

        [Column(TypeName = "nvarchar(9)")]
        public string ABBR { get; set; }
    }
}
