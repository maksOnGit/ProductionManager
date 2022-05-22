using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductionLibrary
{
    public class Product
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public int Price { get; set; }
        public string PriceFor { get; set; }
        public string ImageUrl { get; set; }
        public int ProductionId { get; set; }
        public int RealStock { get; set; }
        public int OrderedStock { get; set; }
        public int NotOrderedStock { get; set; }

        //Navigation Property

        public Production Production { get; set; }
        public IEnumerable<ProductOrder> ProductOrders { get; set; }
        public IEnumerable<Lot> Lots { get; set; }
    }
}
