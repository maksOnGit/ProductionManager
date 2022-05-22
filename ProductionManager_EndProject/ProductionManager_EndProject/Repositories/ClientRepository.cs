using Microsoft.EntityFrameworkCore;
using ProductionLibrary;
using ProductionManager_EndProject.Data;
using System.Linq;
using System.Threading.Tasks;

namespace ProductionManager_EndProject.Repositories
{
    public class ClientRepository : BaseRepository<Client>
    {
        public ClientRepository(ApplicationDbContext context) : base(context)
        {
        }

        public override async Task<Client> GetById<X>(X id)
        {
            return await _dbContext.Clients.Where(c => c.ClientId.Equals(id)).FirstOrDefaultAsync();
        }
    }
}
