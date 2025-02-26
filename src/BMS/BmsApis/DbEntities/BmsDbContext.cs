using Microsoft.EntityFrameworkCore;

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
        public DbSet<Auditorium> Auditoria { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<Seat> Seats { get; set; }
        public DbSet<Show> Shows { get; set; }
        public DbSet<SeatInShow> SeatInShowMapping { get; set; }
        public DbSet<SeatTypeInShow> SeatTypeInShowMapping { get; set; }
        public DbSet<Theatre> Theatres { get; set; }
        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<User> Users { get; set; }

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



            modelBuilder.Entity<City>().HasKey(x => x.Id);
            modelBuilder.Entity<City>().HasIndex(x => x.Name).IsUnique();
            modelBuilder.Entity<City>().HasMany(x => x.Theatres)
                                        .WithOne(x => x.City)
                                        .HasForeignKey(x => x.CityId)
                                        .HasPrincipalKey(x => x.Id);

            modelBuilder.Entity<Theatre>().HasKey(x => x.Id);
            modelBuilder.Entity<Theatre>().HasIndex(x => x.Name).IsUnique();
            modelBuilder.Entity<Theatre>().HasMany(x => x.Auditoria)
                                            .WithOne(x => x.Theatre)
                                            .HasForeignKey(x => x.TheatreId)
                                            .HasPrincipalKey(x => x.Id);

            modelBuilder.Entity<Auditorium>().HasKey(x => x.Id);
            modelBuilder.Entity<Auditorium>().HasIndex(x => x.Name).IsUnique();
            modelBuilder.Entity<Auditorium>().HasMany(x => x.Seats)
                                                .WithOne(x => x.Auditorium)
                                                .HasForeignKey(x => x.AuditoriumId)
                                                .HasPrincipalKey(x => x.Id);
            modelBuilder.Entity<Auditorium>().HasMany(x => x.SupportedFeatures);
            modelBuilder.Entity<Auditorium>().HasMany(x => x.Shows);

            modelBuilder.Entity<Payment>().HasKey(x => x.Id);
            modelBuilder.Entity<Payment>().HasOne(x => x.PaymentProvider);
            modelBuilder.Entity<Payment>().HasOne(x => x.PaymentStatus);
            modelBuilder.Entity<Payment>().HasOne(x => x.Ticket);

            modelBuilder.Entity<Seat>().HasKey(x => x.Id);
            modelBuilder.Entity<Seat>().HasIndex(x => x.Number).IsUnique();
            modelBuilder.Entity<Seat>().HasOne(x => x.Auditorium);
            modelBuilder.Entity<Seat>().HasOne(x => x.SeatType);

            modelBuilder.Entity<SeatInShow>().HasKey(x => x.Id);
            modelBuilder.Entity<SeatInShow>().HasOne(x => x.SeatStatus);
            modelBuilder.Entity<SeatInShow>().HasOne(x => x.Show).WithMany().HasForeignKey(x => x.ShowId).OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<SeatInShow>().HasOne(x => x.Seat).WithMany().HasForeignKey(x => x.SeatId).OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<SeatInShow>().HasOne(x => x.Ticket).WithMany().HasForeignKey(x => x.TicketId).OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<SeatTypeInShow>().HasKey(x => x.Id);
            modelBuilder.Entity<SeatTypeInShow>().HasOne(x => x.SeatType);
            modelBuilder.Entity<SeatTypeInShow>().HasOne(x => x.Show);

            modelBuilder.Entity<Show>().HasKey(x => x.Id);
            modelBuilder.Entity<Show>().HasIndex(x => x.Name).IsUnique();
            modelBuilder.Entity<Show>().HasMany(x => x.RequiredFeatures);
            modelBuilder.Entity<Show>().HasMany(x => x.SeatTypes)
                                        .WithOne(x => x.Show)
                                        .HasForeignKey(x => x.ShowId);

            modelBuilder.Entity<Ticket>().HasKey(x => x.Id);
            modelBuilder.Entity<Ticket>().HasMany(x => x.Payments);
            modelBuilder.Entity<Ticket>().HasMany(x => x.BookedSeats)
                                           .WithOne(x => x.Ticket)
                                           .HasForeignKey(x => x.TicketId);

            modelBuilder.Entity<User>().HasKey(x => x.Id);
            modelBuilder.Entity<User>().HasIndex(x => x.UserName).IsUnique();
            modelBuilder.Entity<User>().HasMany(x => x.UserRoles);


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
}
