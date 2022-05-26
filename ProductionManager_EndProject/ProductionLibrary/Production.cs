using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductionLibrary
{
    public class Production
    {
        [Required]
        public int Id { get; set; }
        [Required]
        [DataType(DataType.EmailAddress)]
        [StringLength(50)]
        public string Email { get; set; }
        [Required]
        [StringLength(50)]
        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; }
        [Required]
        [StringLength(50)]
        [Display(Name = "Production Name")]
        public string ProductionName { get; set; }
        [Required]
        [StringLength(50)]
        public string Country { get; set; }
        [Required]
        [StringLength(50)]
        public string City { get; set; }
        [Required]
        public int ZIP { get; set; }
        [Required]
        [StringLength(100)]
        public string Street { get; set; }
        [Required]
        [Display(Name = "House Number")]
        public int Number { get; set; }

        //Navigation Properties
        public IEnumerable<ProdTask> ProdTasks { get; set; }
        public IEnumerable<Room> Rooms { get; set; }




    }
}
