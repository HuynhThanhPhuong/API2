using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace API2.Models;

public partial class Api2Context : DbContext
{
    public Api2Context()
    {
    }

    public Api2Context(DbContextOptions<Api2Context> options)
        : base(options)
    {
    }

    public virtual DbSet<Staff> Staff { get; set; }

    public virtual DbSet<StaffInTask> StaffInTasks { get; set; }

    public virtual DbSet<Task> Tasks { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=DESKTOP-8PSQBN9\\ADMIN;Initial Catalog=API2;Integrated Security=True;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Staff>(entity =>
        {
            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.FullName).HasMaxLength(200);
            entity.Property(e => e.ShortName).HasMaxLength(50);
        });

        modelBuilder.Entity<StaffInTask>(entity =>
        {
            entity.ToTable("StaffInTask");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Idstaff).HasColumnName("IDStaff");
            entity.Property(e => e.Idstask).HasColumnName("IDStask");
        });

        modelBuilder.Entity<Task>(entity =>
        {
            entity.ToTable("Task");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.EndDate).HasColumnType("datetime");
            entity.Property(e => e.Idparent).HasColumnName("IDParent");
            entity.Property(e => e.Label)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.Name).HasMaxLength(200);
            entity.Property(e => e.StartDate).HasColumnType("datetime");
            entity.Property(e => e.Type)
                .HasMaxLength(30)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
