using System.ComponentModel.DataAnnotations;

namespace BmsApis.DbEntities
{
    public class User : BaseEntity
    {
        [StringLength(100)]
        public required string UserName { get; set; }
        
        [StringLength(100)]
        public required string Name { get; set; }
        
        [StringLength(50)]
        public string? Password { get; set; }

        public required ICollection<UserRole> UserRoles { get; set; }
    }
}
