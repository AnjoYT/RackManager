namespace RackManager.Data
{
    public interface IDbContextFactory
    {
        public ApplicationDbContext CreateDbContext();
    }
}
