namespace BmsApis.DbEntities
{
    public record UserRole
    {
        public int Id { get; set; }
        public required string Name { get; set; }
    }
}
