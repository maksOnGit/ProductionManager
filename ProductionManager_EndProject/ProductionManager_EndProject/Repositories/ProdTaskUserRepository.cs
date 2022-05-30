using Microsoft.EntityFrameworkCore;
using ProductionLibrary;
using ProductionManager_EndProject.Data;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductionManager_EndProject.Repositories
{
    public class ProdTaskUserRepository : BaseRepository<ProdTaskUser>
    {
        public ProdTaskUserRepository(ApplicationDbContext context) : base(context)
        {
        }

        public override Task<ProdTaskUser> GetById<X>(X id)
        {
            return _dbContext.ProdTasksUsers.Where(p => p.Id.Equals(id)).FirstOrDefaultAsync();
        }

        public async Task<ProdTaskUser> Exist(ProdTaskUser prodTaskUser)
        {
            ProdTaskUser entity = await _dbContext.ProdTasksUsers.Where(p => p.ProdTaskId == prodTaskUser.ProdTaskId && p.UserId == prodTaskUser.UserId).FirstOrDefaultAsync();
            if (entity != null)
            {
                return entity;
            }
            return null;
        }

        public async Task<bool> ExistByTaskId(int taskId)
        {
            ProdTaskUser entity = await _dbContext.ProdTasksUsers.Where(p => p.ProdTaskId.Equals(taskId)).FirstOrDefaultAsync();
            if (entity != null)
            {
                return true;
            }
            return false;
        }
    }
}
