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
        public string Barcode { get; set; }
        public string Description { get; set; }
        public string MaterialImageUrl { get; set; }
        [Display(Name = "UOM")]
        public int UnitOfMeasureId { get; set; }
        public double DefaultBuyingPrice { get; set; } = 0.0;
        public double DefaultSellingPrice { get; set; } = 0.0;
        [Display(Name = "Branch")]
        public int BranchId { get; set; }
        [Display(Name = "Currency")]
        public int CurrencyId { get; set; }
    }
}
