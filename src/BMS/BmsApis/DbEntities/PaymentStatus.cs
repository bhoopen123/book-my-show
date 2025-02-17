namespace BmsApis.DbEntities
{
    public record PaymentStatus
    {
        public int Id { get; set; }
        public required string Name { get; set; }
    }
}
