using ProductionLibrary;
using ProductionManager_EndProject.Data;
using System.Threading.Tasks;

namespace ProductionManager_EndProject.Repositories
{
    public class ProdTaskUserRepository : BaseRepository<ProdTaskUser>
    {
        public ProdTaskUserRepository(ApplicationDbContext context) : base(context)
        {
        }

        public override Task<ProdTaskUser> GetById<X>(X id)
        {
            throw new System.NotImplementedException();
        }
    }
}
