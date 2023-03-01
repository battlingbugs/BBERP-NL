using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BBERP.Models
{
    public class RawMaterial
    {
        [Key]
        public int MaterialId { get; set; }
        [Required]
        public string MaterialName { get; set; }
        public string MaterialCode { get; set; }
        
        public string Description { get; set; }
       
        
        public decimal GrossWt { get; set; }
        
        [Display(Name = "Branch")]
        public int BranchId { get; set; }
       
    }
}
