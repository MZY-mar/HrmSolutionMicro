using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Onboarding.ApplicationCore.Contract.Model
{
    public class EmployeeModel
    {
        public int Id { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(128)")]
        public string FirstName { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(128)")]
        public string LastName { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(128)")]
        public string MiddleName { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(9)")]
        public string SSN { get; set; }

        [Column(TypeName = "date")]
        public DateTime? HireDate { get; set; }

        [Column(TypeName = "date")]
        public DateTime? EndDate { get; set; }

        [Required]
        public string EmployeeCategoryCode { get; set; }
        public EmployeeCategoryModel EmployeeCategory { get; set; }

        [Required]
        public string EmployeeStatusCode { get; set; }

        [Required]
        public EmployeeStatusModel EmployeeStatus { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(MAX)")]
        public string Address { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(MAX)")]
        public string Email { get; set; }

        [Required]
        public int EmployeeRoleId { get; set; }
    }
}
