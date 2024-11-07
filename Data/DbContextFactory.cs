using Microsoft.EntityFrameworkCore;

namespace RackManager.Data
{
    class DbContextFactory : IDbContextFactory
    {
        private readonly string _connectionString;

        public DbContextFactory(string connectionString)
        {
            _connectionString = connectionString;
        }
        public ApplicationDbContext CreateDbContext()
        {
            DbContextOptions options = new DbContextOptionsBuilder().UseSqlServer(_connectionString).Options;
            return new ApplicationDbContext(_connectionString);
        }
    }
}
