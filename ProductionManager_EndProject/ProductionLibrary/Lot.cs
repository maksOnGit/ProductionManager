using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductionLibrary
{
    public class Lot
    {
        public int Id { get; set; }
        public int RoomId { get; set; }
        public int ProductId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string ProductName { get; set; }
        public string PositionInRoom { get; set; }
        public bool? IsGrowing { get; set; }
        public double? RecoltedQuantitie { get; set; }
        public double? EstimatedQuantitie { get; set; }
        public string QuantitificationUnit { get; set; }
        public double? MinEstimation { get; set; }
        public double? MaxEstimation { get; set; }

        //Navigation Properties
        public Product Product { get; set; }
        public Room Room { get; set; }
    }
}
