namespace BmsApis.DbEntities
{
    public class Payment : BaseEntity
    {
        public int Amount { get; set; }
        public required string TransactionId { get; set; }
    }
}
