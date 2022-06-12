using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Vehicle_Theft_Alert_System_DAL.Models;

namespace Vehicle_Theft_Alert_System_DAL
{
    public class PostgresContext : IdentityDbContext<AccountDB, AlertSystemRole, Guid>
    {
        public PostgresContext()
        {
            Database.EnsureCreated();
        }

        public PostgresContext(DbContextOptions<PostgresContext> options) : base(options) { }
        public DbSet<ActivityScheduleDB> ActivityScheduleDBs { get; set; }
        public DbSet<ConnectionDB> ConnectionDBs { get; set; }
        public DbSet<CountryDB> CountryDBs { get; set; }
        public DbSet<FamilyDB> FamilyDBs { get; set; }
        public DbSet<FamilyPlanDB> FamilyPlanDBs { get; set; }
        public DbSet<TrackerDB> TrackerDBs { get; set; }
        public DbSet<UserDB> UserDBs { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder) 
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
