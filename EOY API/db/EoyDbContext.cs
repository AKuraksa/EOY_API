using EOY_API.Tables;
using Microsoft.EntityFrameworkCore;

namespace EOY_API.db
{
    public class EoyDbContext:DbContext
    {
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Login>().HasNoKey();
            modelBuilder.Entity<Workplace>().HasNoKey();
           
        }
        public EoyDbContext(DbContextOptions<EoyDbContext> options) 
            : base(options) 
        { 

        }
        public DbSet<Login> Logins { get; set; }
        public DbSet<Workplace> Workplaces { get; set; }

    }
}
