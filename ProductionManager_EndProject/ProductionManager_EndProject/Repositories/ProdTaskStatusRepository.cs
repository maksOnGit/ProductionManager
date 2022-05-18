using ProductionLibrary;
using ProductionManager_EndProject.Data;
using System.Threading.Tasks;

namespace ProductionManager_EndProject.Repositories
{
    public class ProdTaskStatusRepository : BaseRepository<ProdTaskStatus>
    {
        public ProdTaskStatusRepository(ApplicationDbContext context) : base(context)
        {
        }

        public override Task<ProdTaskStatus> GetById<X>(X id)
        {
            throw new System.NotImplementedException();
        }
    }
}
