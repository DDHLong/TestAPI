using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TestAPI.Models
{
    public class Applicant
    {
        public int Id { get; set; }

        public Candidate CandidateId { get; set; }

        public Job JobId { get; set; }
    }
}
