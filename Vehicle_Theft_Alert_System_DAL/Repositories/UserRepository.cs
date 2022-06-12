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
    public class UserRepository : IUserRepository
    {
        private PostgresContext _context;
        private DbSet<UserDB> _dbSet;

        public UserRepository(PostgresContext context)
        {
            _context = context;
            _dbSet = _context.Set<UserDB>();
        }

        public IEnumerable<UserDB> GetAll()
        {
            return _dbSet.ToList();
        }

        public UserDB UpdateEntity(UserDB entity)
        {
            _dbSet.Update(entity);
            _context.SaveChanges();

            return entity;
        }

        public UserDB AddEntity(UserDB entity)
        {
            _dbSet.Add(entity);
            _context.SaveChanges();

            return entity;
        }

        public UserDB GetById(Guid id)
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
