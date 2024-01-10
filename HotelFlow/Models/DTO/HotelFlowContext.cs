using Microsoft.EntityFrameworkCore;

namespace HotelFlow.Models.DTO
{
    public partial class HotelFlowContext : DbContext
    {
        public HotelFlowContext()
        {
        }

        public HotelFlowContext(DbContextOptions<HotelFlowContext> options)
            : base(options)
        {
        }

        public virtual DbSet<CleaningHistory> CleaningHistories { get; set; } = null!;
        public virtual DbSet<CleaningSchedule> CleaningSchedules { get; set; } = null!;
        public virtual DbSet<FloorSchema> FloorSchemas { get; set; } = null!;
        public virtual DbSet<Hotel> Hotels { get; set; } = null!;
        public virtual DbSet<ObjectPlacement> ObjectPlacements { get; set; } = null!;
        public virtual DbSet<ObjectType> ObjectTypes { get; set; } = null!;
        public virtual DbSet<Reservation> Reservations { get; set; } = null!;
        public virtual DbSet<ReservationStatus> ReservationStatuses { get; set; } = null!;
        public virtual DbSet<Review> Reviews { get; set; } = null!;
        public virtual DbSet<Role> Roles { get; set; } = null!;
        public virtual DbSet<Room> Rooms { get; set; } = null!;
        public virtual DbSet<RoomStatus> RoomStatuses { get; set; } = null!;
        public virtual DbSet<RoomType> RoomTypes { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=.;Database=HotelFlow;Trusted_connection=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CleaningHistory>(entity =>
            {
                entity.ToTable("CleaningHistory", "Rooms");

                entity.Property(e => e.DateCleaned).HasColumnType("datetime");

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.CleaningHistories)
                    .HasForeignKey(d => d.EmployeeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__CleaningH__Emplo__571DF1D5");

                entity.HasOne(d => d.Room)
                    .WithMany(p => p.CleaningHistories)
                    .HasForeignKey(d => d.RoomId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__CleaningH__RoomI__5629CD9C");
            });

            modelBuilder.Entity<CleaningSchedule>(entity =>
            {
                entity.ToTable("CleaningSchedule", "Rooms");

                entity.Property(e => e.DateToBeCleaned).HasColumnType("datetime");

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.CleaningSchedules)
                    .HasForeignKey(d => d.EmployeeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__CleaningS__Emplo__5535A963");

                entity.HasOne(d => d.Room)
                    .WithMany(p => p.CleaningSchedules)
                    .HasForeignKey(d => d.RoomId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__CleaningS__RoomI__5441852A");
            });

            modelBuilder.Entity<FloorSchema>(entity =>
            {
                entity.ToTable("FloorSchema", "Visuals");

                entity.HasIndex(e => e.FloorNumber, "UQ__FloorSch__632D9B2BEB59EC8A")
                    .IsUnique();

                entity.Property(e => e.DateCreated).HasColumnType("datetime");
            });

            modelBuilder.Entity<Hotel>(entity =>
            {
                entity.ToTable("Hotel", "Base");

                entity.Property(e => e.DateCreated).HasColumnType("datetime");

                entity.Property(e => e.Name).HasMaxLength(255);
            });

            modelBuilder.Entity<ObjectPlacement>(entity =>
            {
                entity.ToTable("ObjectPlacement", "Visuals");

                entity.Property(e => e.DateCreated).HasColumnType("datetime");

                entity.Property(e => e.PositionFrom).HasMaxLength(255);

                entity.Property(e => e.PositionTo).HasMaxLength(255);

                entity.HasOne(d => d.FloorNumber)
                    .WithMany(p => p.ObjectPlacements)
                    .HasForeignKey(d => d.FloorNumberId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__ObjectPla__Floor__5DCAEF64");

                entity.HasOne(d => d.ObjectType)
                    .WithMany(p => p.ObjectPlacements)
                    .HasForeignKey(d => d.ObjectTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__ObjectPla__Objec__5CD6CB2B");

                entity.HasOne(d => d.Room)
                    .WithMany(p => p.ObjectPlacements)
                    .HasForeignKey(d => d.RoomId)
                    .HasConstraintName("FK__ObjectPla__RoomI__5EBF139D");
            });

            modelBuilder.Entity<ObjectType>(entity =>
            {
                entity.ToTable("ObjectType", "Visuals");

                entity.Property(e => e.DateCreated).HasColumnType("datetime");

                entity.Property(e => e.Type).HasMaxLength(255);
            });

            modelBuilder.Entity<Reservation>(entity =>
            {
                entity.ToTable("Reservation", "Business");

                entity.Property(e => e.DateCreated).HasColumnType("datetime");

                entity.Property(e => e.DateFrom).HasColumnType("smalldatetime");

                entity.Property(e => e.DateTo).HasColumnType("smalldatetime");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.ReservationCustomers)
                    .HasForeignKey(d => d.CustomerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Reservati__Custo__5812160E");

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.ReservationEmployees)
                    .HasForeignKey(d => d.EmployeeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Reservati__Emplo__59063A47");

                entity.HasOne(d => d.Room)
                    .WithMany(p => p.Reservations)
                    .HasForeignKey(d => d.RoomId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Reservati__RoomI__59FA5E80");

                entity.HasOne(d => d.Status)
                    .WithMany(p => p.Reservations)
                    .HasForeignKey(d => d.StatusId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Reservati__Statu__5AEE82B9");
            });

            modelBuilder.Entity<ReservationStatus>(entity =>
            {
                entity.ToTable("ReservationStatus", "Business");

                entity.Property(e => e.DateCreated).HasColumnType("datetime");

                entity.Property(e => e.Name).HasMaxLength(255);
            });

            modelBuilder.Entity<Review>(entity =>
            {
                entity.ToTable("Review", "Business");

                entity.Property(e => e.Comment).HasMaxLength(255);

                entity.Property(e => e.DateCreated).HasColumnType("datetime");

                entity.HasOne(d => d.Reservation)
                    .WithMany(p => p.Reviews)
                    .HasForeignKey(d => d.ReservationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Review__Reservat__5BE2A6F2");
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.ToTable("Role", "Users");

                entity.Property(e => e.DateCreated).HasColumnType("datetime");

                entity.Property(e => e.Name).HasMaxLength(255);
            });

            modelBuilder.Entity<Room>(entity =>
            {
                entity.ToTable("Room", "Rooms");

                entity.Property(e => e.DateCreated).HasColumnType("datetime");

                entity.HasOne(d => d.Status)
                    .WithMany(p => p.Rooms)
                    .HasForeignKey(d => d.StatusId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Room__StatusId__534D60F1");

                entity.HasOne(d => d.Type)
                    .WithMany(p => p.Rooms)
                    .HasForeignKey(d => d.TypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Room__TypeId__52593CB8");
            });

            modelBuilder.Entity<RoomStatus>(entity =>
            {
                entity.ToTable("RoomStatus", "Rooms");

                entity.Property(e => e.DateCreated).HasColumnType("datetime");

                entity.Property(e => e.Name).HasMaxLength(255);
            });

            modelBuilder.Entity<RoomType>(entity =>
            {
                entity.ToTable("RoomType", "Rooms");

                entity.Property(e => e.DateCreated).HasColumnType("datetime");

                entity.Property(e => e.Name).HasMaxLength(255);
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("User", "Users");

                entity.Property(e => e.AddressLine1).HasMaxLength(255);

                entity.Property(e => e.AddressLine2).HasMaxLength(255);

                entity.Property(e => e.DateCreated).HasColumnType("datetime");

                entity.Property(e => e.EmailAddress).HasMaxLength(255);

                entity.Property(e => e.Name).HasMaxLength(255);

                entity.Property(e => e.Password).HasMaxLength(255);

                entity.Property(e => e.PhoneNumber).HasMaxLength(255);

                entity.Property(e => e.Surname).HasMaxLength(255);

                entity.Property(e => e.UserName).HasMaxLength(255);

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.RoleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__User__RoleId__5165187F");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
