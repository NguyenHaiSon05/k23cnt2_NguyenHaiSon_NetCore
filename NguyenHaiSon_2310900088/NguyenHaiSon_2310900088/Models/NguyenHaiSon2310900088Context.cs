using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace NguyenHaiSon_2310900088.Models;

public partial class NguyenHaiSon2310900088Context : DbContext
{
    public NguyenHaiSon2310900088Context()
    {
    }

    public NguyenHaiSon2310900088Context(DbContextOptions<NguyenHaiSon2310900088Context> options)
        : base(options)
    {
    }

    public virtual DbSet<NhsEmployee> NhsEmployees { get; set; }

//    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
//        => optionsBuilder.UseSqlServer("Server=HAISON\\SQL1;Database=NguyenHaiSon_2310900088;uid=sa;pwd=Zuboka@05; MultipleActiveResultSets=True; TrustServerCertificate=True ");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<NhsEmployee>(entity =>
        {
            entity.HasKey(e => e.NhsEmpId).HasName("PK__NhsEmplo__2F899F4E58649D73");

            entity.ToTable("NhsEmployee");

            entity.Property(e => e.NhsEmpId)
                .ValueGeneratedNever()
                .HasColumnName("nhsEmpId");
            entity.Property(e => e.NhsEmpLevel)
                .HasMaxLength(50)
                .HasColumnName("nhsEmpLevel");
            entity.Property(e => e.NhsEmpName)
                .HasMaxLength(100)
                .HasColumnName("nhsEmpName");
            entity.Property(e => e.NhsEmpStartDate).HasColumnName("nhsEmpStartDate");
            entity.Property(e => e.NhsEmpStatus).HasColumnName("nhsEmpStatus");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
