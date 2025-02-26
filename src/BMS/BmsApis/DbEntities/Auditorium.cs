namespace BmsApis.DbEntities
{
    public class Auditorium : BaseEntity
    {
        public required string Name { get; set; }
        public int Rows { get; set; }
        public int Columns { get; set; }

        public int TheatreId { get; set; }
        public virtual required Theatre Theatre { get; set; }

        public virtual ICollection<Seat>? Seats { get; set; }
        public virtual ICollection<Feature>? SupportedFeatures { get; set; }
        public virtual ICollection<Show>? Shows { get; set; }
    }
}
