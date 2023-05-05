using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Interview.ApplicationCore.Entity
{
    public class Interviewer
    {
        public int Id { get; set; }

        [Column(TypeName = "NVARCHAR")]
        [MaxLength(128)]
        public string? FristName { get; set; }

        [Column(TypeName = "NVARCHAR")]
        [MaxLength(128)]
        public string? LastName { get; set; }
        public int EmployeeId { get; set; }

    }
}