using AGSR.DataLayer.Entities;
using Microsoft.EntityFrameworkCore;

namespace AGSR.DataLayer
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
            Database.EnsureCreated();
        }

        public virtual DbSet<Patient> Patient { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Patient>(entity =>
            {
                entity.HasKey(e => e.Name.Id).HasName("PK__Patient__70DAFC34E9BADC14");
            });

        }
    }
}