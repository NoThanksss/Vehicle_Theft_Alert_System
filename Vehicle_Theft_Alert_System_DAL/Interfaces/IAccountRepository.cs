using System;
using System.Threading.Tasks;
using Vehicle_Theft_Alert_System_DAL.Models;

namespace Vehicle_Theft_Alert_System_DAL.Interfaces
{
    public interface IAccountRepository : IBaseRepository<AccountDB>
    {
         Task<AccountDB> GetByIdAsync(Guid id);
    }
}
