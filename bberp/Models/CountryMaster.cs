using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BBERP.Models
{
    public class CountryMaster
    {
        public int Id { get; set; }
        [Required]
        public string CountryName { get; set; }
        public string CountryCode { get; set; }
    }
}
