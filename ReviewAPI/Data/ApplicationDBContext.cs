using Microsoft.EntityFrameworkCore;
using ReviewAPI.Model;

namespace ReviewAPI.Data
{
    public class ApplicationDBContext: DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options)
        {
        }

        public DbSet<Review> Reviews { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        internal async Task<IEnumerable<Review>> ToListAsync()
        {
            throw new NotImplementedException();
        }
    }


}
