using BmsApis.DbEntities;

namespace BmsApis.Repositories
{
    public interface ISeatInShowRepository : IDisposable
    {
        IEnumerable<SeatInShow> GetSeatsInShow(IEnumerable<int> seatInShowIds);
        IEnumerable<SeatInShow> SaveRange(IEnumerable<SeatInShow> seatsInShow);
        SeatInShow Save(SeatInShow seatInShow);
    }
}
