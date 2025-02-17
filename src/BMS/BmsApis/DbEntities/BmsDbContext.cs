using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BmsApis.DbEntities
{
    public class BmsDbContext : DbContext
    {
        private readonly string connectionString;

        public BmsDbContext(DbContextOptions<BmsDbContext> options, IConfiguration configuration) : base(options)
        {
            connectionString = configuration.GetSection("ConnectionStrings:BmsConnectionString")!.Value;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(connectionString);
        }

        public DbSet<SeatType> SeatTypes { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
        public DbSet<Feature> Features { get; set; }
        public DbSet<SeatStatus> SeatStatus { get; set; }
        public DbSet<TheatreStatus> TheatreStatus { get; set; }
        public DbSet<PaymentMode> PaymentModes { get; set; }
        public DbSet<PaymentStatus> PaymentStatus { get; set; }
        public DbSet<PaymentProvider> PaymentProviders { get; set; }
        public DbSet<City> Cities { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            var currentDateTime = DateTime.UtcNow;

            modelBuilder.Entity<SeatType>().HasKey(x => x.Id);
            modelBuilder.Entity<UserRole>().HasKey(x => x.Id);
            modelBuilder.Entity<Feature>().HasKey(x => x.Id);
            modelBuilder.Entity<SeatStatus>().HasKey(x => x.Id);
            modelBuilder.Entity<TheatreStatus>().HasKey(x => x.Id);
            modelBuilder.Entity<PaymentMode>().HasKey(x => x.Id);
            modelBuilder.Entity<PaymentStatus>().HasKey(x => x.Id);
            modelBuilder.Entity<PaymentProvider>().HasKey(x => x.Id);

            modelBuilder.Entity<City>().HasIndex(x => x.Name).IsUnique();
            modelBuilder.Entity<City>().HasMany(x => x.Theatres)
                                        .WithOne(x => x.City)
                                        .HasForeignKey(x => x.CityId)
                                        .HasPrincipalKey(x => x.Id);
            
            modelBuilder.Entity<Theatre>().HasIndex(x => x.Name).IsUnique();

            modelBuilder.Entity<SeatType>()
                        .HasData(
                            new SeatType { Id = 1, Name = "Silver" },
                            new SeatType { Id = 2, Name = "Gold" },
                            new SeatType { Id = 3, Name = "Platinum" }
                            );

            modelBuilder.Entity<UserRole>()
                        .HasData(
                            new UserRole { Id = 1, Name = "Admin" },
                            new UserRole { Id = 2, Name = "Owner" },
                            new UserRole { Id = 3, Name = "User" }
                            );

            modelBuilder.Entity<Feature>()
                        .HasData(
                            new Feature { Id = 1, Name = "2D" },
                            new Feature { Id = 2, Name = "3D" },
                            new Feature { Id = 3, Name = "4Dx" }
                            );

            modelBuilder.Entity<City>()
                        .HasData(
                            new City { Id = 1, Name = "Pune", IsActive = true, CreatedAtUtc = currentDateTime },
                            new City { Id = 2, Name = "Mumbai", IsActive = true, CreatedAtUtc = currentDateTime },
                            new City { Id = 3, Name = "Hyderabad", IsActive = true, CreatedAtUtc = currentDateTime }
                            );

        }
    }

    public abstract class BaseEntity
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedAtUtc { get; set; }
        public DateTime? ModifiedAtUtc { get; set; }
    }

    public class City : BaseEntity
    {
        public required string Name { get; set; }
        public virtual ICollection<Theatre>? Theatres { get; }
    }

    public class Theatre : BaseEntity
    {
        public required string Name { get; set; }
        public required string Address { get; set; }
        public int MaxSeatsBookingAllowed { get; set; }

        public int CityId { get; set; }
        public virtual required City City { get; set; }
    }

    public class Auditorium : BaseEntity
    {
        public required string Name { get; set; }
        public int Rows { get; set; }
        public int Columns { get; set; }
    }

    public class Seat : BaseEntity
    {
        public required string Number { get; set; }
        public int Row { get; set; }
        public int Column { get; set; }
    }

    public class User : BaseEntity
    {
        public required string UserName { get; set; }
        public required string Name { get; set; }
        public string? Password { get; set; }
    }

    public class Show : BaseEntity
    {
        public required string Name { get; set; }
        public TimeOnly StartTime { get; set; }
        public TimeOnly EndTime { get; set; }
    }

    public class SeatInShow : BaseEntity
    {

    }

    public class SeatTypeInShow : BaseEntity
    {
        public float Price { get; set; }
    }

    public class Ticket : BaseEntity
    {
        public DateTime BookingAtUtc { get; set; }
    }

    public class Payment : BaseEntity
    {
        public int Amount { get; set; }
        public required string TransactionId { get; set; }
    }
}
