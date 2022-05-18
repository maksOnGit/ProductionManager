using ProductionLibrary;
using ProductionManager_EndProject.Data;
using System.Threading.Tasks;

namespace ProductionManager_EndProject.Repositories
{
    public class RoomRepository : BaseRepository<Room>
    {
        public RoomRepository(ApplicationDbContext context) : base(context)
        {
        }

        public override Task<Room> GetById<X>(X id)
        {
            throw new System.NotImplementedException();
        }
    }
}
