using System.ComponentModel.DataAnnotations;

namespace BmsApis.DbEntities
{
    public class City : BaseEntity
    {
        [StringLength(100)]
        public required string Name { get; set; }
        public virtual ICollection<Theatre>? Theatres { get; }
    }
}
