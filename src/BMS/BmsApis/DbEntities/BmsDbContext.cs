using Microsoft.EntityFrameworkCore;

namespace BmsApis.DbEntities
{
    public class BmsDbContext : DbContext
    {
        private readonly string connectionString;

        public BmsDbContext(DbContextOptions<BmsDbContext> options, IConfiguration configuration) : base(options)
        {
            connectionString = configuration.GetSection("ConnectionStrings:BmsConnectionString").Value;
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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<SeatType>().HasKey(x => x.Id);
            modelBuilder.Entity<UserRole>().HasKey(x => x.Id);
            modelBuilder.Entity<Feature>().HasKey(x => x.Id);
            modelBuilder.Entity<SeatStatus>().HasKey(x => x.Id);
            modelBuilder.Entity<TheatreStatus>().HasKey(x => x.Id);
            modelBuilder.Entity<PaymentMode>().HasKey(x => x.Id);
            modelBuilder.Entity<PaymentStatus>().HasKey(x => x.Id);
            modelBuilder.Entity<PaymentProvider>().HasKey(x => x.Id);

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

        }
    }

    public record SeatType
    {
        public int Id { get; set; }
        public required string Name { get; set; }
    }

    public record UserRole
    {
        public int Id { get; set; }
        public required string Name { get; set; }
    }

    public record Feature
    {
        public int Id { get; set; }
        public required string Name { get; set; }
    }

    public record SeatStatus
    {
        public int Id { get; set; }
        public required string Name { get; set; }
    }

    public record TheatreStatus
    {
        public int Id { get; set; }
        public required string Name { get; set; }
    }
    public record PaymentMode
    {
        public int Id { get; set; }
        public required string Name { get; set; }
    }

    public record PaymentStatus
    {
        public int Id { get; set; }
        public required string Name { get; set; }
    }

    public record PaymentProvider
    {
        public int Id { get; set; }
        public required string Name { get; set; }
    }
}
