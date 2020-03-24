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
    }
}
