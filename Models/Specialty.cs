using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TestAPI.Models
{
    public class Specialty
    {
        public int SpecialtyId { get; set; }

        public string SpecialityName { get; set; }
    }
}
