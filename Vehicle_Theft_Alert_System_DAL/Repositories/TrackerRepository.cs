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
    public class TrackerRepository : ITrackerRepository
    {
        private PostgresContext _context;
        private DbSet<TrackerDB> _dbSet;

        public TrackerRepository(PostgresContext context)
        {
            _context = context;
            _dbSet = _context.Set<TrackerDB>();
        }

        public IEnumerable<TrackerDB> GetAll()
        {
            return _dbSet;
        }

        public TrackerDB UpdateEntity(TrackerDB entity)
        {
            _dbSet.Update(entity);
            _context.SaveChanges();

            return entity;
        }

        public TrackerDB AddEntity(TrackerDB entity)
        {
            _dbSet.Add(entity);
            _context.SaveChanges();

            return entity;
        }

        public TrackerDB GetById(Guid id)
        {
            return _dbSet.Find(id);
        }

        public Task DeleteEntity(Guid id)
        {
            var entityToRemove = _dbSet.Find(id);
            _dbSet.Remove(entityToRemove);
            var connections = _context.ConnectionDBs.Where(x => x.TrackerDBId == entityToRemove.Id);
            foreach (var connection in connections)
            {
                _context.Entry(connection).State = EntityState.Deleted;
            }

            return Task.FromResult(_context.SaveChanges());
        }
    }
}
