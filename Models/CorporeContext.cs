using Microsoft.EntityFrameworkCore;

namespace ProjetoPLC.Models
{
    public class CorporeContext : DbContext
    {
        public CorporeContext(DbContextOptions<CorporeContext> options) : base(options)
        {

        }

        public DbSet<Plc> Plcs { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Plc>(entity =>
            {
                entity.ToTable("Plc", "dbo");
                entity.HasKey(e => e.Id);

            });
        }

    }
}
