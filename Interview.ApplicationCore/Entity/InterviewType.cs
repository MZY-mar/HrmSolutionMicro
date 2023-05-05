using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Interview.ApplicationCore.Entity
{
    public class InterviewType
    {
        public int Id { get; set; }
        public string? InterviewTypeCode {get; set;}
        public string? Description { get; set; }
    }
}