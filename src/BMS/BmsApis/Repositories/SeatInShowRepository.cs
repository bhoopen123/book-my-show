using BmsApis.DbEntities;
using System.Net.Sockets;

namespace BmsApis.Repositories
{
    public class SeatInShowRepository : ISeatInShowRepository
    {
        private BmsDbContext bmsDbContext;

        public SeatInShowRepository(BmsDbContext bmsDbContext)
        {
            this.bmsDbContext = bmsDbContext;
        }

        public IEnumerable<SeatInShow> GetSeatsInShow(IEnumerable<int> seatInShowIds)
        {
            return bmsDbContext.SeatInShowMapping.Where(s => seatInShowIds.Contains(s.Id));
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

        public IEnumerable<SeatInShow> SaveRange(IEnumerable<SeatInShow> seatsInShow)
        {
            bmsDbContext.SeatInShowMapping.AddRange(seatsInShow);
            bmsDbContext.SaveChanges();
            return seatsInShow;
        }

        public SeatInShow Save(SeatInShow seatInShow)
        {
            bmsDbContext.SeatInShowMapping.Add(seatInShow);
            bmsDbContext.SaveChanges();
            return seatInShow;
        }
    }
}
