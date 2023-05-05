using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Interview.ApplicationCore.Model
{
    public class InterviewRequestModel
    {
        public int Id { get; set; } // PK
    public int RecruiterId { get; set; } // FK
    public int SubmissionId { get; set; } // FK
    public string? InterviewTypeCode { get; set; } // FK
    public int InterviewRound { get; set; }
    public DateTime ScheduledOn { get; set; }
    public int InterviewerId { get; set; } // FK
    public int FeedbackId { get; set; } // FK
  
    }
}