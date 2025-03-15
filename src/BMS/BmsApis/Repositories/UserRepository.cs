using BmsApis.DbEntities;

namespace BmsApis.Repositories
{
    public class UserRepository : IUserRepository
    {
        private BmsDbContext bmsDbContext;

        public UserRepository(BmsDbContext bmsDbContext)
        {
            this.bmsDbContext = bmsDbContext;
        }

        private bool disposed = false;
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    bmsDbContext.Dispose();
                }
            }
            this.disposed = true;
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public User? GetUser(int id)
        {
            return bmsDbContext.Users.Find(id);
        }
    }
}
