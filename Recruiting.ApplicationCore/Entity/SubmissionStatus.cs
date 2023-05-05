using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Recruiting.ApplicationCore.Entity
{
    public class SubmissionStatus
    {
        public int Id { get; set; }

        public string SubmissionStatusCode{ get; set; }


          [Required]
        [Column(TypeName = "nvarchar(512)")]
        public string Description { get; set; }
    }
}