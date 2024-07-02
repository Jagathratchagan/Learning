using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace EmbeddedSQL.Models;

public partial class LocalDbContext : DbContext
{
    public LocalDbContext()
    {
    }

    public LocalDbContext(DbContextOptions<LocalDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Employee> Employees { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)        
        => optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=LocalDB;Trusted_Connection=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Employee>(entity =>
        {
            entity.HasKey(e => e.EmpId).HasName("PK__Employee__AF2DBB99526D676C");

            entity.ToTable("Employee");

            entity.Property(e => e.EmpId).ValueGeneratedNever();
            entity.Property(e => e.Department)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.DOB).HasColumnName("DOB");
            entity.Property(e => e.EmpName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Gender)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.Salary).HasColumnType("decimal(19, 2)");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
