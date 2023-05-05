using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Onboarding.ApplicationCore.Entity
{
    public class Employee
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

        [Required]
        public string EmployeeStatusCode { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(MAX)")]
        public string Address { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(MAX)")]
        public string Email { get; set; }

        [Required]
        public int EmployeeRoleId { get; set; }
        public EmployeeRole EmployeeRole { get; set; }
        public EmployeeStatus EmployeeStatus { get; set; }
        public EmployeeCategory EmployeeCategory { get; set; }
    }
}
