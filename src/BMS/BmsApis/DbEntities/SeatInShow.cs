namespace BmsApis.DbEntities
{
    public class SeatInShow : BaseEntity
    {
        public virtual required SeatStatus SeatStatus { get; set; }

        public int ShowId { get; set; }
        public virtual required Show Show { get; set; }

        public int SeatId { get; set; }
        public virtual required Seat Seat { get; set; }

        public int TicketId { get; set; }
        public virtual Ticket? Ticket { get; set; }

        public DateTime StatusUpdatedAt { get; set; }
    }
}
