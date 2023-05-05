using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Interview.ApplicationCore.Model
{
    public class RecruiterResponseModel
    {
        
        [Column(TypeName = "NVARCHAR")]
        [MaxLength(128)]
        public string? FristName { get; set; }

        [Column(TypeName = "NVARCHAR")]
        [MaxLength(128)]
        public string? LastName { get; set; }
    }
}