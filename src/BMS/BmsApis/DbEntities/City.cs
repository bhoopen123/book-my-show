namespace BmsApis.DbEntities
{
    public class City : BaseEntity
    {
        public required string Name { get; set; }
        public virtual ICollection<Theatre>? Theatres { get; }
    }
}
