using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TestAPI.Models
{
    public class JobJobType
    {
        public int Id { get; set; }

        public int JobId { get; set; }

        public int JobTypeId { get; set; }
    }
}
