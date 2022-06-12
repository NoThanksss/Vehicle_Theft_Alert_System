using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Vehicle_Theft_Alert_System_DAL.Interfaces
{
    public interface IBaseRepository<TEntity>
    {
        IEnumerable<TEntity> GetAll();

        TEntity UpdateEntity(TEntity entity);

        TEntity AddEntity(TEntity entity);

        TEntity GetById(Guid id);

        Task DeleteEntity(Guid id);
    }
}
