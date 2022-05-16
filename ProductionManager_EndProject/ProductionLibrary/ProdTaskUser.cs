using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductionLibrary
{
    public class ProdTaskUser
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public int ProdTaskId { get; set; }

        //Navigation Properties
        public User User { get; set; }
        public ProdTask ProdTask { get; set; }

    }
}
