using ProductionLibrary;
using ProductionManager_EndProject.Data;
using System.Threading.Tasks;

namespace ProductionManager_EndProject.Repositories
{
    public class ProdTaskRepository : BaseRepository<ProdTask>
    {
        public ProdTaskRepository(ApplicationDbContext context) : base(context)
        {
        }

        public override Task<ProdTask> GetById<X>(X id)
        {
            throw new System.NotImplementedException();
        }
    }
}
