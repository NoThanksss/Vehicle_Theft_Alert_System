using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Vehicle_Theft_Alert_System_DAL.Interfaces;
using Vehicle_Theft_Alert_System_DAL.Models;

namespace Vehicle_Theft_Alert_System_DAL.Repositories
{
    public class CountryRepository : ICountryRepository
    {
        private PostgresContext _context;
        private DbSet<CountryDB> _dbSet;

        public CountryRepository(PostgresContext context)
        {
            _context = context;
            _dbSet = _context.Set<CountryDB>();
        }

        public IEnumerable<CountryDB> GetAll()
        {
            return _dbSet;
        }

        public CountryDB UpdateEntity(CountryDB entity)
        {
            _dbSet.Update(entity);
            _context.SaveChanges();

            return entity;
        }

        public CountryDB AddEntity(CountryDB entity)
        {
            _dbSet.Add(entity);
            _context.SaveChanges();

            return entity;
        }

        public CountryDB GetById(Guid id)
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
