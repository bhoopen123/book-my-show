using Azure.Identity;
using System.ComponentModel.DataAnnotations;

namespace BmsApis.DbEntities
{
    public class Theatre : BaseEntity
    {
        [StringLength(100)]
        public required string Name { get; set; }

        [StringLength(250)]
        public required string Address { get; set; }
        public int MaxSeatsBookingAllowed { get; set; }

        public int CityId { get; set; }
        public virtual required City City { get; set; }

        public virtual ICollection<Auditorium>? Auditoria { get; set; }
    }
}
