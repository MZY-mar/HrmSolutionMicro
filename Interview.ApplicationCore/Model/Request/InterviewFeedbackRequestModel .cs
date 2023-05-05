using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Interview.ApplicationCore.Model
{
    public class InterviewFeedbackRequestModel 
    {
        public int Id { get; set; }
        public int Rating { get; set; }

        [Column(TypeName = "NVARCHAR")]
        [MaxLength(128)]
        public string? Comment { get; set; }
     }
}