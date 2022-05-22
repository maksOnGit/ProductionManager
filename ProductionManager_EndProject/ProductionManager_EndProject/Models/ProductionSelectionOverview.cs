using ProductionLibrary;
using System.Collections.Generic;

namespace ProductionManager_EndProject.Models
{
    public class ProductionSelectionOverview
    {
        public IEnumerable<Production> AvaiableProductions { get; set; }
        public Production SelectedProduction { get; set; }
    }
}
