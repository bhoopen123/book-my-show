namespace BmsApis.DbEntities
{
    public class Payment : BaseEntity
    {
        public int Amount { get; set; }
        public required string TransactionId { get; set; }
        public required PaymentStatus PaymentStatus { get; set; }
        public required PaymentProvider PaymentProvider { get; set; }

        public int TicketId { get; set; }
        public virtual required Ticket Ticket { get; set; }

    }
}
