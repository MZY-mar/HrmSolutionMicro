using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Recruiting.ApplicationCore.Entity;

namespace Recruiting.ApplicationCore.Model
{
    public class SubmissionModel
    {
                public int Id { get; set; }
        [Required]
        public int JobRequirementId { get; set; }

        [Required]
        public int CandidateId { get; set; }
        public DateTime SubmittedOn { get; set; }
        public string SubmissionStatusCode { get; set; }
        public DateTime ConfirmedOn { get; set; }
        public DateTime RejectedOn { get; set; }

        [Required]
        [Column(TypeName = "varchar(50)")]
        public string CurrentStatus { get; set; }
        public List<SubmissionStatus> Status { get; set; }
        public JobRequirement JobRequirement { get; set; }
        public Candidate Candidate { get; set; }
    }
}