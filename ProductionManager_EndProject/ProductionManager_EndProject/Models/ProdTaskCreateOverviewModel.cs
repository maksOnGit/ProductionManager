using ProductionLibrary;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ProductionManager_EndProject.Models
{
    public class ProdTaskCreateOverviewModel
    {
        public int Id { get; set; }
        [Required]
        [Display(Name = "Task Name")]
        [MaxLength(50, ErrorMessage = "Maximum 50 characters autorhized")]
        public string TaskName { get; set; }
        [Required]
        [Display(Name = "Task Description")]
        [MaxLength(500, ErrorMessage = "Maximum 500 characters autorhized")]
        public string TaskDescription { get; set; }
        public int ProdTaskStatusId { get; set; }
        [Required]
        public int? ProductionId { get; set; }

        //Navigation Properties
        public IEnumerable<ProdTaskUser> ProdTaskUsers { get; set; }
        public Production Production { get; set; }
        public ProdTaskStatus ProdTaskStatus { get; set; }
    }
}
