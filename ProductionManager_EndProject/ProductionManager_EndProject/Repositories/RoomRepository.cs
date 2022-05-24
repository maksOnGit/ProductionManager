using Microsoft.EntityFrameworkCore;
using ProductionLibrary;
using ProductionManager_EndProject.Data;
using System.Linq;
using System.Threading.Tasks;

namespace ProductionManager_EndProject.Repositories
{
    public class RoomRepository : BaseRepository<Room>
    {
        public RoomRepository(ApplicationDbContext context) : base(context)
        {
        }

        public override async Task<Room> GetById<X>(X id)
        {
            return await _dbContext.Rooms.Include(r => r.Lots).Where(r => r.Id.Equals(id)).FirstOrDefaultAsync();
        }

    }
}
