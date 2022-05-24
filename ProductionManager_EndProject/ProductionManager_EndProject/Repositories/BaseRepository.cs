using Microsoft.EntityFrameworkCore;
using ProductionLibrary.Interfaces;
using ProductionManager_EndProject.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductionManager_EndProject.Repositories
{
    public abstract class BaseRepository<T> : IRepository<T> where T : class
    {
        protected readonly ApplicationDbContext _dbContext;

        public BaseRepository(ApplicationDbContext context)
        {
            _dbContext = context;
        }

        public virtual async Task<T> Create(T entity)
        {
            _dbContext.Set<T>().Add(entity);
            try
            {
                await _dbContext.SaveChangesAsync();
            }
            catch 
            {
                return null;
            }
            
            return entity;
        }

        public virtual async Task<T> Delete(T entity)
        {
            _dbContext.Set<T>().Remove(entity);
            try
            {
                await _dbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                return null;
            }

            return entity;
        }

        public virtual async Task<T> DeleteById(int id)
        {
            var entity = await GetById(id);
            if (entity != null)
            {
                return await Delete(entity);
            }
            return null;
        }

        public virtual async Task<T> DeleteById(string id)
        {
            var entity = await GetById(id);
            if (entity != null)
            {
                return await Delete(entity);
            }
            return null;
        }

        public virtual IQueryable<T> GetAll()
        {
            //AsNoTracking will give readonly resultats.
            //IQueryable assure that a query is executed on the database side. (IEnnumerable load all from DB and execute
            //the query on the client side.)
            return _dbContext.Set<T>().AsNoTracking();
        }


        public abstract Task<T> GetById<X>(X id);
  
        

        public virtual async Task<IEnumerable<T>> ListAll()
        {
            return await GetAll().ToListAsync();
        }

        public virtual async Task<T> Update(T entity)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;

            try
            {
                await _dbContext.SaveChangesAsync();
            }
            catch
            {
                return null;
            }

            return entity;
        }
    }
}
