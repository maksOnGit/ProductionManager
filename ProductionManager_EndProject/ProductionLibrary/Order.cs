using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductionLibrary
{
    public class Order
    {
        public int Id { get; set; }
        public string Reference { get; set; }
        public double Price { get; set; }
        public string ClientId { get; set; }
        public string UserId { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime DeliveryDate { get; set; }

        //Navigation Properties
        public User User { get; set; }
        public Client Client { get; set; }
        public IEnumerable<ProductOrder> ProductOrders { get; set; }
    }
}
