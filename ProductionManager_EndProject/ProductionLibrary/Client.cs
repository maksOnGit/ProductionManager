using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductionLibrary
{
    public class Client
    {
        //public int Id { get; set; }
        [Required]
        [StringLength(50)]
        [Display(Name = "Client Name")]
        public string ClientId { get; set; }
        [Required]
        [StringLength(50)]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required]
        [StringLength(50)]
        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; }
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
        public string ImageUrl { get; set; }

        //Navigation Properties
        public IEnumerable<Order> Orders { get; set; }

    }
}
