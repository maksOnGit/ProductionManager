using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductionLibrary
{
    public class Room
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string RoomName { get; set; }
        [Required]
        public int ProductionId { get; set; }

        //Navigation Properties
        public IEnumerable<Lot> Lots { get; set; }
        public Production Production { get; set; }

    }
}
