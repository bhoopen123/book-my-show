namespace BmsApis.DbEntities
{
    public record PaymentProvider
    {
        public int Id { get; set; }
        public required string Name { get; set; }
    }
}
