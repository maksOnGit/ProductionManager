using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductionLibrary
{
    public class Client
    {
        public int Id { get; set; }
        public string ClientName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public int ZIP { get; set; }
        public string Street { get; set; }
        public int Number { get; set; }
        public string ImageUrl { get; set; }
        public int ProductionId { get; set; }

        //Navigation Properties
        public Production Production { get; set; }
        public IEnumerable<Order> ClientOrders { get; set; }

    }
}
