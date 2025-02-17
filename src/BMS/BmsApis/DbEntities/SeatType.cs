namespace BmsApis.DbEntities
{
    public record SeatType
    {
        public int Id { get; set; }
        public required string Name { get; set; }
    }
}
