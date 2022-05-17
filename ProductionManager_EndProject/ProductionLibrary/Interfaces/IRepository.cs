using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductionLibrary.Interfaces
{
    interface IRepository<T>
    { 
        Task<IEnumerable<T>> ListAll();
        IQueryable<T> GetAll();
        Task<T> GetById<X>(X id);

        //Create
        Task<T> Create(T entity);

        //Delete
        Task<T> Delete(T entity);
        Task<T> DeleteById(int id);

        //Update
        Task<T> Update(T entity);


    }
}
