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
        public double Price { get; set; }
        public string PriceFor { get; set; }
        public string ImageUrl { get; set; }
        public double RealStock { get; set; }
        public double? OrderedStock { get; set; }
        public double? NotOrderedStock { get; set; }

        //Navigation Property

        public IEnumerable<ProductOrder> ProductOrders { get; set; }
        public IEnumerable<Lot> Lots { get; set; }
    }
}
