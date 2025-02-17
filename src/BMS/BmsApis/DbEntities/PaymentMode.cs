namespace BmsApis.DbEntities
{
    public record PaymentMode
    {
        public int Id { get; set; }
        public required string Name { get; set; }
    }
}
