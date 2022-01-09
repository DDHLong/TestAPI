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

        public int DiscplineTd { get; set; }

        public int SpecialityRequiredId { get; set; }

        public int JobTypeId { get; set; }

        [Range(1000,10000)]
        public long PayAmount { get; set; }
    }
}
