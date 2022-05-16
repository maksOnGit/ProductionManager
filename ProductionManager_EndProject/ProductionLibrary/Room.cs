using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductionLibrary
{
    public class Room
    {
        public int Id { get; set; }
        public string RoomName { get; set; }
        public int ProductionId { get; set; }

        //Navigation Properties
        public IEnumerable<Lot> Lots { get; set; }
        public Production Production { get; set; }

    }
}
