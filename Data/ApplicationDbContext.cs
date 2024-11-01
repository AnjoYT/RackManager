using Microsoft.EntityFrameworkCore;
using RackManager.Entities;
using System.Configuration;

namespace RackManager.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<BaseCardDTO> Images { get; set; }
        public DbSet<MainAnimalDTO> Animals { get; set; }
        public DbSet<SnakeDTO> Snakes { get; set; }

        private readonly static object _lock = new object();
        private static ApplicationDbContext instance;

        public ApplicationDbContext() { }

        public static ApplicationDbContext GetInstance()
        {
            lock (_lock)
            {
                if (instance is null)
                {
                    instance = new ApplicationDbContext();
                }
                return instance;
            }
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(ConfigurationManager.ConnectionStrings["DatabaseConnection"].ConnectionString);
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
