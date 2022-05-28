using ProductionLibrary;
using System.ComponentModel.DataAnnotations;

namespace ProductionManager_EndProject.Models
{
    public class LotCollectOverviewModel
    {
        public int LotId { get; set; }
        public int ProductionId { get; set; }
        [Required(ErrorMessage = "Add a positive or negative number")]
        public double? Collected { get; set; }
    }
}
