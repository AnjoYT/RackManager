using Microsoft.EntityFrameworkCore;
using RackManager.Entities;
using System.Configuration;

namespace RackManager.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<ImageEntity> Images { get; set; }
        public DbSet<AnimalBaseEntity> Animals { get; set; }
        public DbSet<SnakeEntity> Snakes { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(ConfigurationManager.ConnectionStrings["DatabaseConnection"].ConnectionString);
            base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ImageEntity>()
                .ToTable("Animal")
                .HasDiscriminator<string>("Animals_type")
                .HasValue<ImageEntity>("Image")
                .HasValue<AnimalBaseEntity>("Animal_base")
                .HasValue<SnakeEntity>("Snake");
            modelBuilder.Entity<HumidityEntity>();
            modelBuilder.Entity<TempEntity>();
            base.OnModelCreating(modelBuilder);
        }
    }
}
