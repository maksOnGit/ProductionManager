using ProductionLibrary;
using ProductionManager_EndProject.Data;
using System.Threading.Tasks;

namespace ProductionManager_EndProject.Repositories
{
    public class ClientRepository : BaseRepository<Client>
    {
        public ClientRepository(ApplicationDbContext context) : base(context)
        {
        }

        public override Task<Client> GetById<X>(X id)
        {
            throw new System.NotImplementedException();
        }
    }
}
