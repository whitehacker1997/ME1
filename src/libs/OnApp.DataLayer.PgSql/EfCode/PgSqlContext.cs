using OnApp.DataLayer.Repository;
using Microsoft.EntityFrameworkCore;

namespace OnApp.DataLayer.PgSql.EfCode
{
    public class PgSqlContext : EfCoreContext
    {
        public PgSqlContext(DbContextOptions<PgSqlContext> options)
            :base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder) => 
            base.OnModelCreating(modelBuilder);
    }
}
