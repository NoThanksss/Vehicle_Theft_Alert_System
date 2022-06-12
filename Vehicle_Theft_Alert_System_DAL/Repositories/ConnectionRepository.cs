using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Vehicle_Theft_Alert_System_DAL.Interfaces;
using Vehicle_Theft_Alert_System_DAL.Models;

namespace Vehicle_Theft_Alert_System_DAL.Repositories
{
    public class ConnectionRepository : IConnectionRepository
    {
        private PostgresContext _context;
        private DbSet<ConnectionDB> _dbSet;

        public ConnectionRepository(PostgresContext context)
        {
            _context = context;
            _dbSet = _context.Set<ConnectionDB>();
        }

        public IEnumerable<ConnectionDB> GetAll()
        {
            return _dbSet;
        }

        public ConnectionDB UpdateEntity(ConnectionDB entity)
        {
            _dbSet.Update(entity);
            _context.SaveChanges();

            return entity;
        }

        public ConnectionDB AddEntity(ConnectionDB entity)
        {
            _dbSet.Add(entity);
            _context.SaveChanges();

            return entity;
        }

        public ConnectionDB GetById(Guid id)
        {
            return _dbSet.Find(id);
        }

        public Task DeleteEntity(Guid id)
        {
            var entityToRemove = _dbSet.Find(id);
            _dbSet.Remove(entityToRemove);

            return Task.FromResult(_context.SaveChanges());
        }
    }
}
