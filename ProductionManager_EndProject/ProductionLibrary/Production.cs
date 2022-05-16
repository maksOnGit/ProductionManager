using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductionLibrary
{
    public class Production
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string ProductionName { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public int ZIP { get; set; }
        public string Street { get; set; }
        public int Number { get; set; }

        //Navigation Properties
        public IEnumerable<User> Users { get; set; }
        public IEnumerable<ProdTask> ProdTasks { get; set; }
        public IEnumerable<Order> Orders { get; set; }
        public IEnumerable<Client> Clients { get; set; }
        public IEnumerable<Product> Products { get; set; }
        public IEnumerable<Lot> Lots { get; set; }




    }
}
