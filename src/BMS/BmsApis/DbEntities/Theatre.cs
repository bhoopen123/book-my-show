using Azure.Identity;

namespace BmsApis.DbEntities
{
    public class Theatre : BaseEntity
    {
        public required string Name { get; set; }
        public required string Address { get; set; }
        public int MaxSeatsBookingAllowed { get; set; }

        public int CityId { get; set; }
        public virtual required City City { get; set; }

        public virtual ICollection<Auditorium>? Auditoria { get; set; }
    }
}
