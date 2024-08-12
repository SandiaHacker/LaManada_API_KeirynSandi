using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace LaManada_API_KeirynSandi.Models;

public partial class LaManadaContext : DbContext
{
    public LaManadaContext()
    {
    }

    public LaManadaContext(DbContextOptions<LaManadaContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Pet> Pets { get; set; }

    public virtual DbSet<PetCare> PetCares { get; set; }

    public virtual DbSet<Reservation> Reservations { get; set; }

    public virtual DbSet<Transport> Transports { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<UserRole> UserRoles { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("SERVER=.;DATABASE=LA_MANADA;INTEGRATED SECURITY=FALSE;User Id=P62024;Password=123hola*;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Pet>(entity =>
        {
            entity.HasKey(e => e.PetId).HasName("PK__Pet__48E53802B009A11F");

            entity.ToTable("Pet");

            entity.Property(e => e.PetId).HasColumnName("PetID");
            entity.Property(e => e.Breed)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Gender)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Species)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Weight).HasColumnType("decimal(5, 2)");

            entity.HasOne(d => d.UsersNavigation).WithMany(p => p.Pets)
                .HasForeignKey(d => d.Users)
                .HasConstraintName("FK__Pet__Users__3E52440B");
        });

        modelBuilder.Entity<PetCare>(entity =>
        {
            entity.HasKey(e => e.PetCareId).HasName("PK__PetCare__496FEDC7385D9D5E");

            entity.ToTable("PetCare");

            entity.Property(e => e.PetCareId).HasColumnName("PetCareID");
            entity.Property(e => e.CareType)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Description).HasColumnType("text");
            entity.Property(e => e.Price).HasColumnType("decimal(10, 2)");
        });

        modelBuilder.Entity<Reservation>(entity =>
        {
            entity.HasKey(e => e.ReservationId).HasName("PK__Reservat__B7EE5F0463BBE21A");

            entity.ToTable("Reservation");

            entity.Property(e => e.ReservationId).HasColumnName("ReservationID");

            entity.HasOne(d => d.PetNavigation).WithMany(p => p.Reservations)
                .HasForeignKey(d => d.Pet)
                .HasConstraintName("FK__Reservation__Pet__440B1D61");

            entity.HasOne(d => d.PetCareNavigation).WithMany(p => p.Reservations)
                .HasForeignKey(d => d.PetCare)
                .HasConstraintName("FK__Reservati__PetCa__44FF419A");

            entity.HasOne(d => d.UsersNavigation).WithMany(p => p.Reservations)
                .HasForeignKey(d => d.Users)
                .HasConstraintName("FK__Reservati__Users__4316F928");
        });

        modelBuilder.Entity<Transport>(entity =>
        {
            entity.HasKey(e => e.TransportId).HasName("PK__Transpor__19E9A17D7D497ED7");

            entity.ToTable("Transport");

            entity.Property(e => e.TransportId).HasColumnName("TransportID");
            entity.Property(e => e.DropoffAddress)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.PickupAddress)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.TransportStatus)
                .HasMaxLength(20)
                .IsUnicode(false);

            entity.HasOne(d => d.ReservationNavigation).WithMany(p => p.Transports)
                .HasForeignKey(d => d.Reservation)
                .HasConstraintName("FK__Transport__Reser__47DBAE45");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.UsersId).HasName("PK__Users__A349B04281F91D74");

            entity.HasIndex(e => e.Email, "UQ__Users__A9D105349B66EDCD").IsUnique();

            entity.Property(e => e.UsersId).HasColumnName("UsersID");
            entity.Property(e => e.Address)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Canton)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.District)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.FirstName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.LastName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.PhoneNumber)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.Province)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.UserRoleId).HasColumnName("UserRoleID");

            entity.HasOne(d => d.UserRole).WithMany(p => p.Users)
                .HasForeignKey(d => d.UserRoleId)
                .HasConstraintName("FK__Users__UserRoleI__3B75D760");
        });

        modelBuilder.Entity<UserRole>(entity =>
        {
            entity.HasKey(e => e.UserRoleId).HasName("PK__UserRole__3D978A5548C812D1");

            entity.ToTable("UserRole");

            entity.HasIndex(e => e.RoleName, "UQ__UserRole__8A2B6160FD2F4ACA").IsUnique();

            entity.Property(e => e.UserRoleId).HasColumnName("UserRoleID");
            entity.Property(e => e.RoleName)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
