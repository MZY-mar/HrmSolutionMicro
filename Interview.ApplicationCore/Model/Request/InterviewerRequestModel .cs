using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Interview.ApplicationCore.Model
{
    public class InterviewerRequestModel 
    { 
          public int Id { get; set; }

        public string? FristName { get; set; }
        public string? LastName { get; set; }
        public int EmployeeId { get; set; }
     
    }
}