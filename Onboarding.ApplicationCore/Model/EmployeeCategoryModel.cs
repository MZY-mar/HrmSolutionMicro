using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Onboarding.ApplicationCore.Contract.Model
{
    public class EmployeeCategoryModel
    {
        public int Id { get; set; }

        [Column(TypeName = "nvarchar(512)")]
        public string Description { get; set; }
    }
}
