using Hostel.Domain.Models;
using Microsoft.EntityFrameworkCore;
using HostelModel = Hostel.Domain.Models.Hostel;

namespace Hostel.Domain.Context;

public class HostelDbContext : DbContext
{
    public HostelDbContext()
    {
    }

    public HostelDbContext(DbContextOptions<HostelDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Document> Documents { get; set; }

    public virtual DbSet<HostelModel> Hostels { get; set; }

    public virtual DbSet<Personal> Personals { get; set; }

    public virtual DbSet<Room> Rooms { get; set; }

    public virtual DbSet<Tenant> Tenants { get; set; }

    public virtual DbSet<Visit> Visits { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Document>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("Documents_pkey");

            entity.HasOne(d => d.Tenant).WithMany(p => p.Documents).HasConstraintName("Documents_TenantId_fkey");
        });

        modelBuilder.Entity<Models.Hostel>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("Hostels_pkey");

            entity.Property(e => e.Description).HasDefaultValueSql("''::character varying");
        });

        modelBuilder.Entity<Personal>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("Personal_pkey");

            entity.Property(e => e.Password).HasDefaultValueSql("''::character varying");

            entity.HasOne(d => d.Hostel).WithMany(p => p.Personals)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Personal_HostelId_fkey");
        });

        modelBuilder.Entity<Room>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("Rooms_pkey");

            entity.Property(e => e.ForSex).HasDefaultValueSql("'None'::character varying");

            entity.HasOne(d => d.Hostel).WithMany(p => p.Rooms)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Rooms_HostelId_fkey");
        });

        modelBuilder.Entity<Tenant>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("Tenants_pkey");

            entity.HasOne(d => d.Hostel).WithMany(p => p.Tenants)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Tenants_HostelId_fkey");

            entity.HasOne(d => d.Room).WithMany(p => p.Tenants)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Tenants_RoomId_fkey");
        });

        modelBuilder.Entity<Visit>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("Visits_pkey");

            entity.Property(e => e.Date).HasDefaultValueSql("now()");
            entity.Property(e => e.Description).HasDefaultValueSql("''::character varying");

            entity.HasOne(d => d.Hostel).WithMany(p => p.Visits).HasConstraintName("Visits_HostelId_fkey");

            entity.HasOne(d => d.Personal).WithMany(p => p.Visits)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Visits_PersonalId_fkey");

            entity.HasOne(d => d.Tenant).WithMany(p => p.Visits).HasConstraintName("Visits_TenantId_fkey");
        });
    }
}
