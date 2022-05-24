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
        public int Price { get; set; }
        [Required]
        [StringLength(50)]
        [Display(Name = "Measurement unit (Kilogram, gram, meter, unit, ...")]
        public string PriceFor { get; set; }
        [Required]
        public int ProductionId { get; set; }
        [Required]
        public int RealStock { get; set; }
        [Required]
        public int OrderedStock { get; set; }
        [Required]
        public int NotOrderedStock { get; set; }
        public string ImageUrl { get; set; }

        //Navigation Property

        public Production Production { get; set; }
        public IEnumerable<ProductOrder> ProductOrders { get; set; }
        public IEnumerable<Lot> Lots { get; set; }
    }
}
