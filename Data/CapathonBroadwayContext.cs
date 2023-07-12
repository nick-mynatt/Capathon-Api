using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Capathon.Data;

public partial class CapathonBroadwayContext : DbContext
{
    public CapathonBroadwayContext(DbContextOptions<CapathonBroadwayContext> options): base(options){
    }

    public virtual DbSet<Appointment> Appointments => Set<Appointment>();

    public virtual DbSet<CareCenter> CareCenters => Set<CareCenter>();

    public virtual DbSet<Dependent> Dependents => Set<Dependent>();

    public virtual DbSet<User> Users => Set<User>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Appointment>(entity =>
        {
            entity.HasNoKey();

            entity.Property(e => e.CId).HasColumnName("c_id");
            entity.Property(e => e.DId).HasColumnName("d_id");
            entity.Property(e => e.DropoffTime)
                .HasColumnType("datetime")
                .HasColumnName("dropoff_time");
            entity.Property(e => e.PickupTime)
                .HasColumnType("datetime")
                .HasColumnName("pickup_time");
            entity.Property(e => e.UId).HasColumnName("u_id");

            entity.HasOne(d => d.CIdNavigation).WithMany()
                .HasForeignKey(d => d.CId)
                .HasConstraintName("FK_Appointments_CareCenters");

            entity.HasOne(d => d.DIdNavigation).WithMany()
                .HasForeignKey(d => d.DId)
                .HasConstraintName("FK_Appointments_Dependents");

            entity.HasOne(d => d.UIdNavigation).WithMany()
                .HasForeignKey(d => d.UId)
                .HasConstraintName("FK_Appointments_Users");
        });

        modelBuilder.Entity<CareCenter>(entity =>
        {
            entity.HasKey(e => e.CId);

            entity.Property(e => e.CId)
                .ValueGeneratedNever()
                .HasColumnName("c_id");
            entity.Property(e => e.Address)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("address");
            entity.Property(e => e.IsCorp).HasColumnName("isCorp");
            entity.Property(e => e.PhoneNumber)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("phoneNumber");
            entity.Property(e => e.Type)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("type");
        });

        modelBuilder.Entity<Dependent>(entity =>
        {
            entity.HasKey(e => e.DId);

            entity.Property(e => e.DId)
                .ValueGeneratedNever()
                .HasColumnName("d_id");
            entity.Property(e => e.Accomodations)
                .IsUnicode(false)
                .HasColumnName("accomodations");
            entity.Property(e => e.Age).HasColumnName("age");
            entity.Property(e => e.FirstName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("firstName");
            entity.Property(e => e.Gender)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("gender");
            entity.Property(e => e.LastName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("lastName");
            entity.Property(e => e.MedicalInfo)
                .IsUnicode(false)
                .HasColumnName("medicalInfo");
            entity.Property(e => e.UId).HasColumnName("u_id");

            entity.HasOne(d => d.UIdNavigation).WithMany(p => p.Dependents)
                .HasForeignKey(d => d.UId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Dependents_Users");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.UId);

            entity.Property(e => e.UId)
                .ValueGeneratedNever()
                .HasColumnName("u_id");
            entity.Property(e => e.CId)
                .HasColumnName("c_id");
            entity.Property(e => e.Address)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("address");
            entity.Property(e => e.DIds)
                .IsUnicode(false)
                .HasColumnName("d_ids");
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("email");
            entity.Property(e => e.FirstName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("firstName");
            entity.Property(e => e.LastName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("lastName");
            entity.Property(e => e.Password)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("password");
            entity.Property(e => e.PhoneNumber)
                .HasMaxLength(25)
                .IsUnicode(false)
                .HasColumnName("phoneNumber");
            entity.Property(e => e.Username)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("username");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
