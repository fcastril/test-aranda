using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace test_arana.wpf.Models
{
    public class MyDbContext : DbContext
    {
        public DbSet<ResourceModel> ResourcesDT { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Filename=arana.db", options =>
            {
                options.MigrationsAssembly(Assembly.GetExecutingAssembly().FullName);
            });
            base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Map table names
            modelBuilder.Entity<ResourceModel>().ToTable("Resources", "aranaDB");
            modelBuilder.Entity<ResourceModel>(entity =>
            {
                entity.HasKey(e => e.id);
            });
            base.OnModelCreating(modelBuilder);
        }

    }
}
