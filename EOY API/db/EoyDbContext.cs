using EOY_API.Tables;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace EOY_API.db
{
    public class EoyDbContext:DbContext
    {
       
        public EoyDbContext(DbContextOptions<EoyDbContext> options) 
            : base(options) 
        { 

        }

       
        public DbSet<Login> Logins { get; set; }
        public DbSet<Workplace> Workplaces { get; set; }
        public DbSet<HistoryError> HistoryErrors { get; set; }
        public DbSet<Worker> Workers { get; set; }

    }
}
