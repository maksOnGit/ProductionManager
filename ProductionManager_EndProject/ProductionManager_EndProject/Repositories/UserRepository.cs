using ProductionLibrary;
using ProductionManager_EndProject.Data;
using System.Threading.Tasks;

namespace ProductionManager_EndProject.Repositories
{
    public class UserRepository : BaseRepository<User>
    {
        public UserRepository(ApplicationDbContext context) : base(context)
        {
        }

        public override Task<User> GetById<X>(X id)
        {
            throw new System.NotImplementedException();
        }
    }
}
