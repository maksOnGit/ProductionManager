using ProductionLibrary;
using ProductionManager_EndProject.Data;
using System.Threading.Tasks;

namespace ProductionManager_EndProject.Repositories
{
    public class ProductOrderRepository : BaseRepository<ProductOrder>
    {
        public ProductOrderRepository(ApplicationDbContext context) : base(context)
        {
        }

        public override Task<ProductOrder> GetById<X>(X id)
        {
            throw new System.NotImplementedException();
        }
    }
}
