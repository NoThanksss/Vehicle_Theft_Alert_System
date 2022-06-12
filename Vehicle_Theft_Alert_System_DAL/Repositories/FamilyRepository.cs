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
    public class FamilyRepository : IFamilyRepository
    {
        private PostgresContext _context;
        private DbSet<FamilyDB> _dbSet;

        public FamilyRepository(PostgresContext context)
        {
            _context = context;
            _dbSet = _context.Set<FamilyDB>();
        }

        public IEnumerable<FamilyDB> GetAll()
        {
            return _dbSet;
        }

        public FamilyDB UpdateEntity(FamilyDB entity)
        {
            _dbSet.Update(entity);
            _context.SaveChanges();

            return entity;
        }

        public FamilyDB AddEntity(FamilyDB entity)
        {
            _dbSet.Add(entity);
            _context.SaveChanges();

            return entity;
        }

        public FamilyDB GetById(Guid id)
        {
            return _dbSet.Find(id);
        }

        public Task DeleteEntity(Guid id)
        {
            var entityToRemove = _dbSet.Find(id);
            _dbSet.Remove(entityToRemove);
            var connections = _context.ConnectionDBs.Where(x => x.FamilyDBId == entityToRemove.Id);
            foreach (var connection in connections)
            {
                _context.Entry(connection).State = EntityState.Deleted;
            }
            var _accounts = _context.Set<AccountDB>();
            var accounts = _accounts.Where(x => x.FamilyDBId == entityToRemove.Id);
            foreach (var account in accounts)
            {
                account.FamilyDBId = null;
                _context.Entry(account).State = EntityState.Modified;
            }

            return Task.FromResult(_context.SaveChanges());
        }
    }
}
