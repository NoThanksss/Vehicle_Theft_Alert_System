using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Vehicle_Theft_Alert_System_BLL.Models;

namespace Vehicle_Theft_Alert_System_BLL.Interfaces
{
    public interface IAccountService
    {
        IEnumerable<Account> GetAllAccounts();
        Account AddNewAccount(Account account);
        void DeleteAccount(Guid id);
        Account UpdateAccount(Account updatedAccount);
        Task<Account> GetAccountByIdAsync(Guid id);
        IEnumerable<Account> GetAllFamilyAcounts(Guid familyId);
        Task<bool> UpdateBalance(Guid id, decimal amount);
        Account GetAccountById(Guid id);

    }
}
