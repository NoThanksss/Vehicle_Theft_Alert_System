using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Vehicle_Theft_Alert_System_DAL.Interfaces;
using Vehicle_Theft_Alert_System_DAL.Models;

namespace Vehicle_Theft_Alert_System_DAL.Repositories
{
    public class ActivityScheduleRepository : IActivityScheduleRepository
    {
        private PostgresContext _context;
        private DbSet<ActivityScheduleDB> _dbSet;

        public ActivityScheduleRepository(PostgresContext context)
        {
            _context = context;
            _dbSet = _context.Set<ActivityScheduleDB>();
        }

        public IEnumerable<ActivityScheduleDB> GetAll()
        {
            return _dbSet;
        }

        public ActivityScheduleDB UpdateEntity(ActivityScheduleDB entity)
        {
            _dbSet.Update(entity);
            _context.SaveChanges();

            return entity;
        }

        public ActivityScheduleDB AddEntity(ActivityScheduleDB entity)
        {
            _dbSet.Add(entity);
            _context.SaveChanges();

            return entity;
        }

        public ActivityScheduleDB GetById(Guid id)
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
