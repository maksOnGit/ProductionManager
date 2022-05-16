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
        public string PositionInRoom { get; set; }
        public bool IsGrowing { get; set; }
        public bool IsLoose { get; set; }
        public int RecoltedQuantitie { get; set; }
        public int Quantitie { get; set; }
        public int EstimatedQuantitie { get; set; }
        public int MinEstimation { get; set; }
        public int MaxEstimation { get; set; }

        //Navigation Properties
        public Product Product { get; set; }
        public Room Room { get; set; }
    }
}
