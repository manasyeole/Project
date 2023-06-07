using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Project.Models;

public partial class DemoDbContext : DbContext
{
    public DemoDbContext()
    {
    }

    public DemoDbContext(DbContextOptions<DemoDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<CityMaster> CityMasters { get; set; }

    public virtual DbSet<StateMaster> StateMasters { get; set; }

    public virtual DbSet<StudentMaster> StudentMasters { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=MANAS-PC\\SQLEXPRESS;Database=DemoDB;Trusted_Connection=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<CityMaster>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__city_mas__3213E83F2A1EB419");

            entity.ToTable("city_master");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.City)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("city");
            entity.Property(e => e.StateId).HasColumnName("state_id");

            entity.HasOne(d => d.State).WithMany(p => p.CityMasters)
                .HasForeignKey(d => d.StateId)
                .HasConstraintName("FK__city_mast__state__5165187F");
        });

        modelBuilder.Entity<StateMaster>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__state_ma__3213E83F152F6007");

            entity.ToTable("state_master");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.State)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("state");
        });

        modelBuilder.Entity<StudentMaster>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__student___3213E83F81ED939D");

            entity.ToTable("student_master");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Gender)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("gender");
            entity.Property(e => e.StudentCity).HasColumnName("student_city");
            entity.Property(e => e.StudentFName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("student_f_name");
            entity.Property(e => e.StudentLName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("student_l_name");
            entity.Property(e => e.StudentMName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("student_m_name");
            entity.Property(e => e.StudentState).HasColumnName("student_state");

            entity.HasOne(d => d.StudentCityNavigation).WithMany(p => p.StudentMasters)
                .HasForeignKey(d => d.StudentCity)
                .HasConstraintName("FK__student_m__stude__5535A963");

            entity.HasOne(d => d.StudentStateNavigation).WithMany(p => p.StudentMasters)
                .HasForeignKey(d => d.StudentState)
                .HasConstraintName("FK__student_m__stude__5441852A");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
