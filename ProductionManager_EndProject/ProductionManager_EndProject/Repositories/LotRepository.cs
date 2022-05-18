using ProductionLibrary;
using ProductionManager_EndProject.Data;
using System.Threading.Tasks;

namespace ProductionManager_EndProject.Repositories
{
    public class LotRepository : BaseRepository<Lot>
    {
        public LotRepository(ApplicationDbContext context) : base(context)
        {
        }

        public override Task<Lot> GetById<X>(X id)
        {
            throw new System.NotImplementedException();
        }
    }
}
