using System;
using System.Collections.Generic;
using App.Domain.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace App.Infra.DB.SqlServer.EF;

public partial class EducationDbContext : DbContext
{
    public EducationDbContext()
    {
    }

    public EducationDbContext(DbContextOptions<EducationDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<City> Cities { get; set; }

    public virtual DbSet<EducationDistrict> EducationDistricts { get; set; }

    public virtual DbSet<Province> Provinces { get; set; }

    //    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    //#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
    //        => optionsBuilder.UseSqlServer("Server=.;Database=EducationDb;Trusted_Connection=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<City>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Cities__3214EC07A05BCD18");

            entity.HasIndex(e => new { e.Name, e.ProvinceId }, "UQ__Cities__5CA5220E3027582D").IsUnique();

            entity.Property(e => e.Name).HasMaxLength(100);

            entity.HasOne(d => d.Province).WithMany(p => p.Cities)
                .HasForeignKey(d => d.ProvinceId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Cities__Province__3B75D760");
        });

        modelBuilder.Entity<EducationDistrict>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Educatio__3214EC07225C2DB6");

            entity.HasIndex(e => new { e.Name, e.CityId }, "UQ__Educatio__0C58A541D9ED207B").IsUnique();

            entity.Property(e => e.Name).HasMaxLength(100);

            entity.HasOne(d => d.City).WithMany(p => p.EducationDistricts)
                .HasForeignKey(d => d.CityId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Education__CityI__3F466844");
        });

        modelBuilder.Entity<Province>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Province__3214EC070F79FA8A");

            entity.HasIndex(e => e.Name, "UQ__Province__737584F6002310BD").IsUnique();

            entity.Property(e => e.Name).HasMaxLength(100);
        });

        OnModelCreatingPartial(modelBuilder);
        modelBuilder.Entity<Province>().HasData(
            new Province { Id = 1, Name = "Tehran" },
            new Province { Id = 2, Name = "Fars" }
        );

        modelBuilder.Entity<City>().HasData(
            new City { Id = 1, Name = "Shiraz", ProvinceId = 2 },
            new City { Id = 2, Name = "Tehran", ProvinceId = 1 }
        );

        modelBuilder.Entity<EducationDistrict>().HasData(
            new EducationDistrict { Id = 1, Name = "District 1", CityId = 1 },
            new EducationDistrict { Id = 2, Name = "District 2", CityId = 2 }
        );
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
