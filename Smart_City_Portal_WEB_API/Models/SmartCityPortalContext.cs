using Smart_City_Portal_WEB_API.Models;
using Smart_City_Portal_WEB_API.Models.DTOs;  // Ensure this line matches your DTO namespace
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

public partial class SmartCityPortalContext : DbContext
{
    public SmartCityPortalContext()
    {
    }

    public SmartCityPortalContext(DbContextOptions<SmartCityPortalContext> options)
        : base(options)
    {
    }

    public virtual DbSet<EmergencyService> EmergencyServices { get; set; } = null!;
    public virtual DbSet<LocalNews> LocalNews { get; set; } = null!;
    public virtual DbSet<MetroSchedule> MetroSchedules { get; set; } = null!;
    public virtual DbSet<PublicTransportSchedule> PublicTransportSchedules { get; set; } = null!;
    public virtual DbSet<User> Users { get; set; } = null!;
    public virtual DbSet<WeatherUpdate> WeatherUpdates { get; set; } = null!;

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {

        }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<EmergencyService>(entity =>
        {
            entity.Property(e => e.ContactNumber).HasMaxLength(15);

            entity.Property(e => e.ServiceName).HasMaxLength(100);
        });

        modelBuilder.Entity<LocalNews>(entity =>
        {
            entity.Property(e => e.Content).HasColumnType("text");

            entity.Property(e => e.PublishedAt)
                .HasColumnType("datetime")
                .HasDefaultValueSql("(getdate())");

            entity.Property(e => e.Title).HasMaxLength(255);

            entity.Property(e => e.Image).HasMaxLength(200);

            entity.HasOne(d => d.Author)
                .WithMany(p => p.LocalNews)
                .HasForeignKey(d => d.AuthorId)
                .HasConstraintName("FK__LocalNews__Autho__45F365D3");
        });

        modelBuilder.Entity<MetroSchedule>(entity =>
        {
            entity.Property(e => e.EndTime).HasColumnType("datetime");

            entity.Property(e => e.StartTime).HasColumnType("datetime");

            entity.Property(e => e.Pickup).HasMaxLength(255);

            entity.Property(e => e.Destination).HasMaxLength(255);

        });

        modelBuilder.Entity<PublicTransportSchedule>(entity =>
        {
            entity.Property(e => e.EndTime).HasColumnType("datetime");

            entity.Property(e => e.StartTime).HasColumnType("datetime");

            entity.Property(e => e.Pickup).HasMaxLength(255);

            entity.Property(e => e.Destination).HasMaxLength(255);

        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasIndex(e => e.Username, "UQ__Users__536C85E429214913")
                .IsUnique();

            entity.HasIndex(e => e.Email, "UQ__Users__A9D105348249E8FA")
                .IsUnique();

            entity.Property(e => e.CreatedAt)
                .HasColumnType("datetime")
                .HasDefaultValueSql("(getdate())");

            entity.Property(e => e.Email).HasMaxLength(100);

            entity.Property(e => e.LastLoginTime).HasColumnType("datetime");

            entity.Property(e => e.PasswordHash).HasMaxLength(255);

            entity.Property(e => e.UpdatedAt)
                .HasColumnType("datetime")
                .HasDefaultValueSql("(getdate())");

            entity.Property(e => e.Username).HasMaxLength(50);
        });

        modelBuilder.Entity<WeatherUpdate>(entity =>
        {
            entity.Property(e => e.Timestamp).HasColumnType("datetime");

            entity.Property(e => e.WeatherDescription).HasMaxLength(255);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
