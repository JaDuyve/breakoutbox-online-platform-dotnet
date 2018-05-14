namespace breakoutbox.Data
{
    public class BreakoutBoxDataInitializer
    {
        private readonly ApplicationDbContext _dbContext;

        public BreakoutBoxDataInitializer(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void InitializeData()
        {
            _dbContext.Database.EnsureDeleted();
            _dbContext.Database.EnsureCreated();
        }
    }
}