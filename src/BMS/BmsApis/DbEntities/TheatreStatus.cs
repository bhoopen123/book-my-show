using System.ComponentModel.DataAnnotations;

namespace BmsApis.DbEntities
{
    public record TheatreStatus
    {
        public int Id { get; set; }
        
        [StringLength(100)]
        public required string Name { get; set; }
    }
}
