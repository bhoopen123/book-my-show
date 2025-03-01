using System.ComponentModel.DataAnnotations;

namespace BmsApis.DbEntities
{
    public class Seat : BaseEntity
    {
        [StringLength(100)]
        public required string Number { get; set; }
        public int Row { get; set; }
        public int Column { get; set; }

        public int AuditoriumId { get; set; }
        public virtual required Auditorium Auditorium { get; set; }

        public int SeatTypeId { get; set; }
        public virtual required SeatType SeatType { get; set; }
    }
}
