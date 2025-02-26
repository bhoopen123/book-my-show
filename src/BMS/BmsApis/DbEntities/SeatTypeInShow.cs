namespace BmsApis.DbEntities
{
    public class SeatTypeInShow : BaseEntity
    {
        public float Price { get; set; }
        public required SeatType SeatType { get; set; }

        public int ShowId { get; set; }
        public required Show Show { get; set; }
    }
}
