namespace BmsApis.DbEntities
{
    public record SeatStatus
    {
        public int Id { get; set; }
        public required string Name { get; set; }
    }
}
