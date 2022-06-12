using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vehicle_Theft_Alert_System_DAL.Interfaces;
using Vehicle_Theft_Alert_System_DAL.Models;

namespace Vehicle_Theft_Alert_System_DAL.Repositories
{
    public class AccountRepository : IAccountRepository
    {
        private PostgresContext _context;
        private DbSet<AccountDB> _dbSet;

        public AccountRepository(PostgresContext context)
        {
            _context = context;
            _dbSet = _context.Set<AccountDB>();
        }

        public IEnumerable<AccountDB> GetAll()
        {
            return _dbSet;
        }

        public AccountDB UpdateEntity(AccountDB entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            _context.SaveChangesAsync();

            return entity;
        }

        public AccountDB AddEntity(AccountDB entity)
        {
            _dbSet.Add(entity);
            _context.SaveChanges();

            return entity;
        }

        public async Task<AccountDB> GetByIdAsync(Guid id)
        {
            return await _dbSet.AsNoTracking().FirstAsync(x => x.Id == id);
        }

        public Task DeleteEntity(Guid id)
        {
            var entityToRemove = _dbSet.Find(id);
            _context.Entry(entityToRemove).State = EntityState.Deleted;
            var connections = _context.ConnectionDBs.Where(x => x.AccountDBId == entityToRemove.Id);
            foreach (var connection in connections) 
            {
                _context.Entry(connection).State = EntityState.Deleted;
            }
            var user = _context.UserDBs.First(x => x.Id == entityToRemove.UserDBId);
            _context.Entry(user).State = EntityState.Deleted;

            return Task.FromResult(_context.SaveChanges());
        }

        public AccountDB GetById(Guid id)
        {
            return _dbSet.Find(id);
        }
    }
}
