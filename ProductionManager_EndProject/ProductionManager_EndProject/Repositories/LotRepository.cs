using Microsoft.EntityFrameworkCore;
using ProductionLibrary;
using ProductionManager_EndProject.Data;
using System.Linq;
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
            return _dbContext.Lots.Where(l => l.Id.Equals(id)).FirstOrDefaultAsync();
        }
    }
}
