using ProductionLibrary;
using ProductionManager_EndProject.Data;
using System.Threading.Tasks;

namespace ProductionManager_EndProject.Repositories
{
    public class OrderRepository : BaseRepository<Order>
    {
        public OrderRepository(ApplicationDbContext context) : base(context)
        {
        }

        public override Task<Order> GetById<X>(X id)
        {
            throw new System.NotImplementedException();
        }
    }
}
