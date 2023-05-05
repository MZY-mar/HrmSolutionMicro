using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Recruiting.ApplicationCore.Entity
{
    public class JobRequirement
    {
        public int Id { get; set; }
        public int NumberOfPosition { get; set; }

        [Required]
        [Column(TypeName = "varchar(70)")]
        public string Title { get; set; }

        [Required]
        [Column(TypeName = "varchar(200)")]
        public string Description { get; set; }

        [Required]
        public int HiringManagerId { get; set; }

        [Required]
        [Column(TypeName = "varchar(20)")]
        public string HiringManagerName { get; set; }

        [Required]
        public DateTime StartDate { get; set; }

        [Required]
        public bool IsActive { get; set; }
        public DateTime? ClosedOn { get; set; }

        [Column(TypeName = "varchar(70)")]
        public string ClosedReason { get; set; }

        [Required]
        public DateTime? CreatedOn { get; set; }

        [Required]
        public int JobCategoryId { get; set; }
        public JobCategory JobCategory { get; set; } //Manager, employee, Lead, Senior,
        // public List<EmployeeRequirementType> EmployeeRequirementType {get; set;} //Parttime, intern, Fulltime
        //   public List<Submission> Submissions { get; set; }
    }
}
