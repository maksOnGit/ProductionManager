using ProductionLibrary;
using System.Collections.Generic;

namespace ProductionManager_EndProject.Models
{
    public class ProductionMainPageOverviewModel
    {
        public Production Production { get; set; }
        public IEnumerable<Room> ProductionRooms { get; set; }
        public IEnumerable<Lot> ProductionLots { get; set; }
    }
}
