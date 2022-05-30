using Microsoft.EntityFrameworkCore;
using ProductionLibrary;
using ProductionManager_EndProject.Data;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductionManager_EndProject.Repositories
{
    public class ProductionRepository : BaseRepository<Production>
    {
        public ProductionRepository(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<Production> GetByIdInclusive<T>(T id)
        {
            return await _dbContext.Productions.Include(x => x.ProdTasks)
                                                .ThenInclude(p => p.ProdTaskUsers)
                                                .Include(x => x.Rooms)
                                                .ThenInclude(x => x.Lots)
                                                .Where(x => x.Id.Equals(id)).FirstOrDefaultAsync();
        }

        public override async Task<Production> GetById<T>(T id)
        {
            return await _dbContext.Productions.Where(c => c.Id.Equals(id)).FirstOrDefaultAsync();
        }

        public override async Task<Production> DeleteById(int id)
        {
            var entity = await GetByIdInclusive(id);
            if (entity != null)
            {
                return await Delete(entity);
            }
            return null;
        }
    }
}
