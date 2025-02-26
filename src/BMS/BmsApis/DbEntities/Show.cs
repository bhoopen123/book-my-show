namespace BmsApis.DbEntities
{
    public class Show : BaseEntity
    {
        public required string Name { get; set; }
        public TimeOnly StartTime { get; set; }
        public TimeOnly EndTime { get; set; }

        public required virtual ICollection<Feature> RequiredFeatures { get; set; }

        public int AuditoriumId { get; set; }
        public virtual required Auditorium Auditorium { get; set; }

        public virtual required ICollection<SeatTypeInShow> SeatTypes { get; set; }
    }
}
