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

        public async Task<string> GetNameById(int id)
        {
            Product product = await _dbContext.Products.Where(p => p.Id.Equals(id)).FirstOrDefaultAsync();
            return product.ProductName;
        }
        public async Task<string> GetUnitTypeById(int id)
        {
            Product product = await _dbContext.Products.Where(p => p.Id.Equals(id)).FirstOrDefaultAsync();
            return product.PriceFor;
        }
    }
}
