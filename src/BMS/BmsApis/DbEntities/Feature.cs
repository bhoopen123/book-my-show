namespace BmsApis.DbEntities
{
    public record Feature
    {
        public int Id { get; set; }
        public required string Name { get; set; }
    }
}
