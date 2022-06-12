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
    public class FamilyPlanRepository : IFamilyPlanRepository
    {
        private PostgresContext _context;
        private DbSet<FamilyPlanDB> _dbSet;

        public FamilyPlanRepository(PostgresContext context)
        {
            _context = context;
            _dbSet = _context.Set<FamilyPlanDB>();
        }

        public IEnumerable<FamilyPlanDB> GetAll()
        {
            return _dbSet;
        }

        public FamilyPlanDB UpdateEntity(FamilyPlanDB entity)
        {
            _dbSet.Update(entity);
            _context.SaveChanges();

            return entity;
        }

        public FamilyPlanDB AddEntity(FamilyPlanDB entity)
        {
            _dbSet.Add(entity);
            _context.SaveChanges();

            return entity;
        }

        public FamilyPlanDB GetById(Guid id)
        {
            return _dbSet.Find(id);
        }

        public Task DeleteEntity(Guid id)
        {
            var entityToRemove = _dbSet.Find(id);
            _dbSet.Remove(entityToRemove);
            var families = _context.FamilyDBs.Where(x => x.FamilyPlanDBId == entityToRemove.Id);
            foreach (var family in families)
            {
                family.FamilyPlanDBId = null;
                _context.Entry(family).State = EntityState.Modified;
            }

            return Task.FromResult(_context.SaveChanges());
        }
    }
}
