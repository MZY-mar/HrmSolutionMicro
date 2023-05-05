using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Recruiting.ApplicationCore.Entity;

namespace Recruiting.ApplicationCore.Model
{
    public class JobCategoryModel
    {
        public int Id { get; set; }

        [Required]
        [Column(TypeName = "varchar(10)")]
        public string Name { get; set; }
        //public List<JobRequirement> JobRequirements { get; set; }
    }
}
