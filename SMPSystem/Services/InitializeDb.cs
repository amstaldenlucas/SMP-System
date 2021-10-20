using SMPSystem.Data;

namespace SMPSystem.Services
{
    public static class InitializeDb
    {
        public static void Initialize(AppDbContext dbContext)
        {
            dbContext.Database.EnsureCreated();
        }
    }
}
