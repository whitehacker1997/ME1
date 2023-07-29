using Global.EF;
using Microsoft.EntityFrameworkCore;

namespace OnApp.DataLayer
{
    public class EfCoreContext : BaseDbContext
    {
        public EfCoreContext(DbContextOptions options)
            : base(options) { }
        public virtual DbSet<Country> Users { get; set; }

        /*[DbFunction("function_name", schema: "public")]
        public IQueryable<Model> FuncName(int languageid,
            DateTime? p_start_date = null,
            DateTime? p_end_date = null) 
            => FromExpression(() => FuncName(
                languageid,
                p_start_date,
                p_end_date
                ));*/
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            /*modelBuilder.HasDbFunction(typeof(EfCoreContext).GetMethod(nameof(FuncName), new[] {
                typeof(int),
                typeof(DateTime?),
                typeof(DateTime?)
            }));*/
        }
    }
}
