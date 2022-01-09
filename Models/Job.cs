using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TestAPI.Models
{
    public class Job
    {
        public int Id { get; set; }

        public Discpline Discpline { get; set; }

        public Speciality SpecialityRequired { get; set; }

        public JobType JobType { get; set; }

        [Range(1000,10000)]
        public long PayAmount { get; set; }
    }
}
