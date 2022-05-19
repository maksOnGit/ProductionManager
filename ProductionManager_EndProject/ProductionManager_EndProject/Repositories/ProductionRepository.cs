using Microsoft.EntityFrameworkCore;
using ProductionLibrary;
using ProductionManager_EndProject.Data;
using System.Linq;
using System.Threading.Tasks;

namespace ProductionManager_EndProject.Repositories
{
    public class ProductionRepository : BaseRepository<Production>
    {
        public ProductionRepository(ApplicationDbContext context) : base(context)
        {
        }

        public override async Task<Production> GetById<X>(X id)
        {
            return await _dbContext.Productions.Where(c => c.Id.Equals(id)).FirstOrDefaultAsync();
        }
    }
}
