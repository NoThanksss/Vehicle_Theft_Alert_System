using AutoMapper;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vehicle_Theft_Alert_System_BLL.Exceptions;
using Vehicle_Theft_Alert_System_BLL.Interfaces;
using Vehicle_Theft_Alert_System_BLL.Models;
using Vehicle_Theft_Alert_System_DAL.Interfaces;
using Vehicle_Theft_Alert_System_DAL.Models;

namespace Vehicle_Theft_Alert_System_BLL.Services
{
    public class AccountService : IAccountService
    {
        private readonly IMapper _mapper;
        private readonly IAccountRepository _accountRepository;
        private readonly ILogger<AccountService> _logger;

        public AccountService(IMapper mapper, IAccountRepository accountRepository, ILogger<AccountService> logger)
        {
            _mapper = mapper;
            _accountRepository = accountRepository;
            _logger = logger;
        }

        public IEnumerable<Account> GetAllFamilyAcounts(Guid familyId)
        {
            try
            {
                var accountsDbs = _accountRepository.GetAll().Where(x => x.FamilyDBId == familyId);

                return _mapper.Map<List<Account>>(accountsDbs);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Exception in GetAllFamilyAcounts method");
                throw new AccountServiceException(ex.Message);
            }
        }

        public async Task<bool> UpdateBalance(Guid id, decimal amount)
        {
            try 
            { 
                var account = await GetAccountByIdAsync(id);

                account.BillAmount += amount;

                var result = UpdateAccount(account);

                return result == null ? false: true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Exception in UpdateBalance method");
                throw new AccountServiceException(ex.Message);
            }
}

        public IEnumerable<Account> GetAllAccounts()
        {
            try
            { 
                return _mapper.Map<List<Account>>(_accountRepository.GetAll());
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Exception in GetAllAccounts method");
                throw new AccountServiceException(ex.Message);
            }
        }

        public Account AddNewAccount(Account account)
        {
            try
            { 
                var accountToAdd = _mapper.Map<AccountDB>(account);
                var newAccount = _accountRepository.AddEntity(accountToAdd);

                return _mapper.Map<Account>(newAccount);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Exception in AddNewAccount method");
                throw new AccountServiceException(ex.Message);
            }
        }

        public void DeleteAccount(Guid id)
        {
            try 
            { 
                _accountRepository.DeleteEntity(id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Exception in DeleteAccount method");
                throw new AccountServiceException(ex.Message);
            }
        }

        public Account UpdateAccount(Account updatedAccount)
        {
            try 
            {
                var mappedAccount = _mapper.Map<AccountDB>(updatedAccount);

                return _mapper.Map<Account>(_accountRepository.UpdateEntity(mappedAccount));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Exception in UpdateAccount method");
                throw new AccountServiceException(ex.Message);
            }
        }

        public async Task<Account> GetAccountByIdAsync(Guid id)
        {
            try 
            { 
                var account = await _accountRepository.GetByIdAsync(id);

                return _mapper.Map<Account>(account);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Exception in GetAccountByIdAsync method");
                throw new AccountServiceException(ex.Message);
            }
        }
        public Account GetAccountById(Guid id)
        {
            try
            { 
                var account = _accountRepository.GetById(id);
                if (account == null)
                {
                    _logger.LogError($"Account with id {id} doesn't exist.");
                    throw new AccountServiceException($"Account with id {id} doesn't exist.");
                }

                return _mapper.Map<Account>(account);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Exception in GetAccountById method");
                throw new AccountServiceException(ex.Message);
            }
        }
    }
}
