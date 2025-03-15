using BmsApis.DbEntities;

namespace BmsApis.Repositories
{
    public class TicketRepository : ITicketRepository
    {
        private BmsDbContext bmsDbContext;

        public TicketRepository(BmsDbContext bmsDbContext)
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

        public Ticket Save(Ticket ticket)
        {
            bmsDbContext.Tickets.Add(ticket);
            bmsDbContext.SaveChanges();
            return ticket;
        }
    }
}
