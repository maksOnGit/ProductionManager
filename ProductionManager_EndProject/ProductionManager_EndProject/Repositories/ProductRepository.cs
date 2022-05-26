using Microsoft.EntityFrameworkCore;
using ProductionLibrary;
using ProductionManager_EndProject.Data;
using System.Linq;
using System.Threading.Tasks;

namespace ProductionManager_EndProject.Repositories
{
    public class ProductRepository : BaseRepository<Product>
    {
        public ProductRepository(ApplicationDbContext context) : base(context)
        {
        }

        public override async Task<Product> GetById<X>(X id)
        {
            return await _dbContext.Products.Include(p => p.ProductOrders).Include(p => p.Lots).Where(p => p.Id.Equals(id)).FirstOrDefaultAsync();
        }
    }
}
