using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bugatti
{
    public class BugattiContext : DbContext
    {
        public BugattiContext(DbContextOptions<BugattiContext> options) : base(options)
        {
        
        }
        public DbSet<Creator> Creators { get; set; }

        public DbSet<Car> Cars { get; set; }

        public DbSet<Country> Countries { get; set; }

        public DbSet<Car_Country_JoinTable> CarCountries { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Car_Country_JoinTable>()
                .HasKey(lrtt => new { lrtt.CarId, lrtt.CountryId });
        }
    }
}
