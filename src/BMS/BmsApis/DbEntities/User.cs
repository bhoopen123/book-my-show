namespace BmsApis.DbEntities
{
    public class User : BaseEntity
    {
        public required string UserName { get; set; }
        public required string Name { get; set; }
        public string? Password { get; set; }

        public required ICollection<UserRole> UserRoles { get; set; }
    }
}
