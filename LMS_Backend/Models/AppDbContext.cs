using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace LMS_Backend.Models;

public partial class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Role> Roles { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.Roleid).HasName("role_pkey");

            entity.ToTable("role");

            entity.Property(e => e.Roleid)
                .UseIdentityAlwaysColumn()
                .HasColumnName("roleid");
            entity.Property(e => e.Rolename)
                .HasMaxLength(30)
                .HasColumnName("rolename");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
