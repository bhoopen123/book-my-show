namespace BmsApis.DbEntities
{
    public class Ticket : BaseEntity
    {
        public DateTime BookingAtUtc { get; set; }

        public virtual ICollection<Payment>? Payments { get; set; }

        public virtual required ICollection<SeatInShow> BookedSeats { get; set; }

        public virtual required User BookedBy { get; set; }
    }
}
