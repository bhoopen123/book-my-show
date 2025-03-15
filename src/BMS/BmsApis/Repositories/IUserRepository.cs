using BmsApis.DbEntities;

namespace BmsApis.Repositories
{
    public interface IUserRepository : IDisposable
    {
        User? GetUser(int id);
    }
}
