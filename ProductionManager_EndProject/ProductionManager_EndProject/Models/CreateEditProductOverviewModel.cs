using ProductionLibrary;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ProductionManager_EndProject.Models
{
    public class CreateEditProductOverviewModel
    {
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        [Display(Name = "Product Name")]
        public string ProductName { get; set; }
        [Required]
        public double? Price { get; set; }
        [Required]
        [StringLength(50)]
        [Display(Name = "Measurement unit (Kilogram, gram, meter, unit, ...")]
        public string PriceFor { get; set; }
        [Required]
        public double RealStock { get; set; }

        public string ImageUrl { get; set; }

        //Navigation Property

        public IEnumerable<ProductOrder> ProductOrders { get; set; }
        public IEnumerable<Lot> Lots { get; set; }
    }
}
