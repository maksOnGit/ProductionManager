using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductionLibrary
{
    public class User : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public int ZIP { get; set; }
        public string Street { get; set; }
        public int Number { get; set; }
        public string ImageUrl { get; set; }
        public DateTime BirthDay { get; set; }

        //Navigation Properties
        public IEnumerable<ProdTaskUser> ProdTaskUsers { get; set; }
        public IEnumerable<Order> Orders { get; set; }
        public Production Production { get; set; }


    }
}
