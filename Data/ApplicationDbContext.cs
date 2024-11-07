using Microsoft.EntityFrameworkCore;
using RackManager.Entities;

namespace RackManager.Data
{
    public class ApplicationDbContext : DbContext
    {
        private readonly string _connectionString;

        public DbSet<BaseCardDTO> Images { get; set; }
        public DbSet<MainAnimalDTO> Animals { get; set; }
        public DbSet<SnakeDTO> Snakes { get; set; }

        public ApplicationDbContext(string connectionString)
        {
            _connectionString = connectionString;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_connectionString);
            base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BaseCardDTO>()
                .ToTable("Animal")
                .HasDiscriminator<string>("Animals_type")
                .HasValue<BaseCardDTO>("Image")
                .HasValue<MainAnimalDTO>("Animal_base")
                .HasValue<SnakeDTO>("Snake");
            modelBuilder.Entity<HumidityDTO>();
            modelBuilder.Entity<TempDTO>();
            base.OnModelCreating(modelBuilder);
        }
    }
}
