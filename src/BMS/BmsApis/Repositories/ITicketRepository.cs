using BmsApis.DbEntities;

namespace BmsApis.Repositories
{
    public interface ITicketRepository : IDisposable
    {
        Ticket Save(Ticket ticket);
    }
}
