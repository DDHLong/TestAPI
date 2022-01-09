using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TestAPI.Models
{
    public class JobType
    {
        public int JobTypeId { get; set; }

        public string JobTypeName { get; set; }
    }
}
