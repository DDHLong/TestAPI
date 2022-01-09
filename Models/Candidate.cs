using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TestAPI.Models
{
    public class Candidate
    {
        public int Id { get; set; }

        public Discpline Discpline { get; set; }

        public Speciality Speciality { get; set; }

        public JobType JobType { get; set; }

        [Range(1000,10000)]
        public long Salary { get; set; }
    }
}
