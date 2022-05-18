using ProductionLibrary;
using ProductionManager_EndProject.Data;
using System.Threading.Tasks;

namespace ProductionManager_EndProject.Repositories
{
    public class ProductionRepository : BaseRepository<Production>
    {
        public ProductionRepository(ApplicationDbContext context) : base(context)
        {
        }

        public override Task<Production> GetById<X>(X id)
        {
            throw new System.NotImplementedException();
        }
    }
}
