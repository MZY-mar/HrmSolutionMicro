using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Interview.ApplicationCore.Entity
{
  public class Interviews
{
    public int Id { get; set; } // PK
    public int RecruiterId { get; set; } // FK
    public int SubmissionId { get; set; } // FK
    public string? InterviewTypeCode { get; set; } // FK
    public int InterviewRound { get; set; }
    public DateTime ScheduledOn { get; set; }
    public int InterviewerId { get; set; } // FK
    public int FeedbackId { get; set; } // FK
    public InterviewFeedback? Feedback { get; set; }
    public Interviewer? interviewer { get; set; }
    public InterviewType? interviewType{ get; set;}
    public Recruiter? recruiter { get; set; }
 }
}