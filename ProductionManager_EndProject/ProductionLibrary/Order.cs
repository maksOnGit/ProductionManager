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
        public int Price { get; set; }
        public int ClientId { get; set; }
        public string UserId { get; set; }
        public int ProductionId { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime DeliveryDate { get; set; }

        //Navigation Properties
        public User User { get; set; }
        public Client Client { get; set; }
        public Production Production { get; set; }
        public IEnumerable<ProductOrder> ProductOrders { get; set; }
    }
}
