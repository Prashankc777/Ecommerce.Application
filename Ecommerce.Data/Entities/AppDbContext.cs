using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Ecommerce.Data.Entities
{
    public partial class AppDbContext : DbContext
    {
        public AppDbContext()
        {
        }

        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AspNetRole> AspNetRoles { get; set; } = null!;
        public virtual DbSet<AspNetRoleClaim> AspNetRoleClaims { get; set; } = null!;
        public virtual DbSet<AspNetUser> AspNetUsers { get; set; } = null!;
        public virtual DbSet<AspNetUserClaim> AspNetUserClaims { get; set; } = null!;
        public virtual DbSet<AspNetUserLogin> AspNetUserLogins { get; set; } = null!;
        public virtual DbSet<AspNetUserRole> AspNetUserRoles { get; set; } = null!;
        public virtual DbSet<AspNetUserToken> AspNetUserTokens { get; set; } = null!;
        public virtual DbSet<Block> Blocks { get; set; } = null!;
        public virtual DbSet<Booking> Bookings { get; set; } = null!;
        public virtual DbSet<Parking> Parkings { get; set; } = null!;
        public virtual DbSet<ParkingRule> ParkingRules { get; set; } = null!;
        public virtual DbSet<ParkingType> ParkingTypes { get; set; } = null!;
        public virtual DbSet<Slot> Slots { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;
        public virtual DbSet<Vehicle> Vehicles { get; set; } = null!;
        public virtual DbSet<VehicleType> VehicleTypes { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("name=DefaultConnection");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AspNetRole>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.DisplayName).HasMaxLength(256);

                entity.Property(e => e.Id).HasMaxLength(450);

                entity.Property(e => e.Name).HasMaxLength(256);

                entity.Property(e => e.NormalizedName).HasMaxLength(256);
            });

            modelBuilder.Entity<AspNetRoleClaim>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.RoleId).HasMaxLength(450);
            });

            modelBuilder.Entity<AspNetUser>(entity =>
            {
                entity.HasIndex(e => e.UserName, "ANU_UserName")
                    .IsUnique();

                entity.Property(e => e.Email).HasMaxLength(256);

                entity.Property(e => e.NormalizedEmail).HasMaxLength(256);

                entity.Property(e => e.NormalizedUserName).HasMaxLength(256);

                entity.Property(e => e.UserName).HasMaxLength(256);
            });

            modelBuilder.Entity<AspNetUserClaim>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.UserId).HasMaxLength(450);
            });

            modelBuilder.Entity<AspNetUserLogin>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.LoginProvider).HasMaxLength(450);

                entity.Property(e => e.ProviderKey).HasMaxLength(450);

                entity.Property(e => e.UserId).HasMaxLength(450);
            });

            modelBuilder.Entity<AspNetUserRole>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.RoleId).HasMaxLength(450);

                entity.Property(e => e.UserId).HasMaxLength(450);
            });

            modelBuilder.Entity<AspNetUserToken>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.LoginProvider).HasMaxLength(450);

                entity.Property(e => e.Name).HasMaxLength(450);

                entity.Property(e => e.UserId).HasMaxLength(450);
            });

            modelBuilder.Entity<Block>(entity =>
            {
                entity.ToTable("Block");

                entity.Property(e => e.Alias).HasMaxLength(256);

                entity.Property(e => e.CreatedBy).HasMaxLength(256);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.ModifiedBy).HasMaxLength(256);

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

                entity.Property(e => e.Name).HasMaxLength(256);
            });

            modelBuilder.Entity<Booking>(entity =>
            {
                entity.ToTable("Booking");

                entity.HasIndex(e => e.SlotId, "IX_Booking_SlotId");

                entity.Property(e => e.CheckInDateTime).HasColumnType("datetime");

                entity.Property(e => e.CheckOutDateTime).HasColumnType("datetime");

                entity.Property(e => e.CreatedBy).HasMaxLength(250);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.ModifiedBy).HasMaxLength(250);

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

                entity.Property(e => e.OwnerName).HasMaxLength(250);

                entity.Property(e => e.PhoneNumber).HasMaxLength(250);

                entity.Property(e => e.VehicleNumber).HasMaxLength(250);

                entity.Property(e => e.VehiclePreNumber).HasMaxLength(50);

                entity.HasOne(d => d.Slot)
                    .WithMany(p => p.Bookings)
                    .HasForeignKey(d => d.SlotId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Booking_Slot");
            });

            modelBuilder.Entity<Parking>(entity =>
            {
                entity.ToTable("Parking");

                entity.HasIndex(e => e.ParkingTypeId, "IX_Parking_ParkingTypeId");

                entity.HasIndex(e => e.SlotId, "IX_Parking_SlotId");

                entity.HasIndex(e => e.VehicleTypeId, "IX_Parking_VehicleTypeId");

                entity.Property(e => e.Id).HasDefaultValueSql("(NEXT VALUE FOR [seq_parking])");

                entity.Property(e => e.CheckIn).HasColumnType("datetime");

                entity.Property(e => e.CheckInAdmin).HasMaxLength(250);

                entity.Property(e => e.CheckOut).HasColumnType("datetime");

                entity.Property(e => e.CheckOutAdmin).HasMaxLength(250);

                entity.Property(e => e.CreatedBy).HasMaxLength(250);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.MinimumPulseInMinutes).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.MobileNumber).HasMaxLength(10);

                entity.Property(e => e.ModifiedBy).HasMaxLength(250);

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

                entity.Property(e => e.OwnerName).HasMaxLength(250);

                entity.Property(e => e.PulseInMinutes).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.PulseRate).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.QrCode).HasMaxLength(50);

                entity.Property(e => e.VehicleNumber).HasMaxLength(250);

                entity.Property(e => e.VehiclePreNumber).HasMaxLength(50);

                entity.HasOne(d => d.ParkingType)
                    .WithMany(p => p.Parkings)
                    .HasForeignKey(d => d.ParkingTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Parking\\_ParkingType");

                entity.HasOne(d => d.Slot)
                    .WithMany(p => p.Parkings)
                    .HasForeignKey(d => d.SlotId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Parking\\_Slot");

                entity.HasOne(d => d.VehicleType)
                    .WithMany(p => p.Parkings)
                    .HasForeignKey(d => d.VehicleTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Parking_VehicleType");
            });

            modelBuilder.Entity<ParkingRule>(entity =>
            {
                entity.ToTable("ParkingRule");

                entity.HasIndex(e => e.ParkingTypeId, "IX_ParkingRule_ParkingTypeId");

                entity.HasIndex(e => e.VehicleTypeId, "IX_ParkingRule_VehicleTypeId");

                entity.Property(e => e.CreatedBy).HasMaxLength(512);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.MinimumPulseInMinute).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.ModifiedBy).HasMaxLength(512);

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

                entity.Property(e => e.Name).HasMaxLength(512);

                entity.Property(e => e.PulseInMinutes).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.PulseRate).HasColumnType("decimal(18, 2)");

                entity.HasOne(d => d.ParkingType)
                    .WithMany(p => p.ParkingRules)
                    .HasForeignKey(d => d.ParkingTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ParkingRule_ParkingType");

                entity.HasOne(d => d.VehicleType)
                    .WithMany(p => p.ParkingRules)
                    .HasForeignKey(d => d.VehicleTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ParkingRule_VehicleType");
            });

            modelBuilder.Entity<ParkingType>(entity =>
            {
                entity.ToTable("ParkingType");

                entity.Property(e => e.CreatedBy).HasMaxLength(512);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.ModifiedBy).HasMaxLength(512);

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

                entity.Property(e => e.Name).HasMaxLength(512);
            });

            modelBuilder.Entity<Slot>(entity =>
            {
                entity.ToTable("Slot");

                entity.HasIndex(e => e.BlockId, "IX_Slot_BlockId");

                entity.HasIndex(e => e.VehicleTypeId, "IX_Slot_VehicleTypeId");

                entity.Property(e => e.Alias).HasMaxLength(256);

                entity.Property(e => e.CreatedBy).HasMaxLength(512);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.ModifiedBy).HasMaxLength(250);

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

                entity.Property(e => e.Name).HasMaxLength(256);

                entity.HasOne(d => d.Block)
                    .WithMany(p => p.Slots)
                    .HasForeignKey(d => d.BlockId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Slot_Block");

                entity.HasOne(d => d.VehicleType)
                    .WithMany(p => p.Slots)
                    .HasForeignKey(d => d.VehicleTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Slot_VehicleType");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("User");

                entity.HasIndex(e => e.AspNetUserId, "IX_User_AspNetUserId");

                entity.Property(e => e.Address).HasMaxLength(50);

                entity.Property(e => e.Contact).HasMaxLength(50);

                entity.Property(e => e.CreatedBy)
                    .HasMaxLength(256)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.ModifiedBy)
                    .HasMaxLength(256)
                    .IsUnicode(false);

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

                entity.Property(e => e.Name).HasMaxLength(512);

                entity.HasOne(d => d.AspNetUser)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.AspNetUserId)
                    .HasConstraintName("FK_User_AspNetUsers");
            });

            modelBuilder.Entity<Vehicle>(entity =>
            {
                entity.ToTable("Vehicle");

                entity.HasIndex(e => e.VehicleTypeId, "IX_Vehicle_VehicleTypeId");

                entity.Property(e => e.CreatedBy).HasMaxLength(250);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.ModifiedBy).HasMaxLength(250);

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

                entity.Property(e => e.VehicleNumber).HasMaxLength(50);

                entity.Property(e => e.VehiclePreNumber).HasMaxLength(50);

                entity.HasOne(d => d.VehicleType)
                    .WithMany(p => p.Vehicles)
                    .HasForeignKey(d => d.VehicleTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Vehicle_VehicleType");
            });

            modelBuilder.Entity<VehicleType>(entity =>
            {
                entity.ToTable("VehicleType");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Name).HasMaxLength(50);
            });

            modelBuilder.HasSequence("seq_parking")
                .StartsAt(2888888888)
                .HasMin(2888888888)
                .HasMax(4294967295);

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
