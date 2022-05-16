using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductionLibrary
{
    public class ProdTask
    {
        public int Id { get; set; }
        public string TaskName { get; set; }
        public string TaskDescription { get; set; }
        public int ProdTaskStatusId { get; set; }
        public int ProductionId { get; set; }

        //Navigation Properties
        public IEnumerable<ProdTaskUser> ProdTaskUsers { get; set; }
        public Production Production { get; set; }
        public ProdTaskStatus ProdTaskStatus { get; set; }
    }
}
