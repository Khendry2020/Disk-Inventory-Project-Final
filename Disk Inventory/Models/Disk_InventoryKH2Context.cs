using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Disk_Inventory.Models
{
    public partial class Disk_InventoryKH2Context : DbContext
    {
        public Disk_InventoryKH2Context()
        {
        }

        public Disk_InventoryKH2Context(DbContextOptions<Disk_InventoryKH2Context> options)
            : base(options)
        {
        }

        public virtual DbSet<Borrower> Borrower { get; set; }
        public virtual DbSet<Disk> Disk { get; set; }
        public virtual DbSet<DiskBorrower> DiskBorrower { get; set; }
        public virtual DbSet<DiskType> DiskType { get; set; }
        public virtual DbSet<Genre> Genre { get; set; }
        public virtual DbSet<Status> Status { get; set; }

        /*protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=serverb08;Database=Disk_InventoryKH2;Trusted_Connection=True;");
            }
        }*/

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Borrower>(entity =>
            {
                entity.Property(e => e.BorrowerId).HasColumnName("BorrowerID");

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.PhoneNumber)
                    .IsRequired()
                    .HasMaxLength(11)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Disk>(entity =>
            {
                entity.Property(e => e.DiskId).HasColumnName("DiskID");

                entity.Property(e => e.Artist)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.DiskName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.DiskTypeId).HasColumnName("DiskTypeID");

                entity.Property(e => e.GenreId).HasColumnName("GenreID");

                entity.Property(e => e.ReleaseDate).HasColumnType("date");

                entity.Property(e => e.StatusId).HasColumnName("StatusID");

                entity.HasOne(d => d.DiskType)
                    .WithMany(p => p.Disk)
                    .HasForeignKey(d => d.DiskTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Disk__DiskTypeID__2C3393D0");

                entity.HasOne(d => d.Genre)
                    .WithMany(p => p.Disk)
                    .HasForeignKey(d => d.GenreId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Disk__GenreID__2E1BDC42");

                entity.HasOne(d => d.Status)
                    .WithMany(p => p.Disk)
                    .HasForeignKey(d => d.StatusId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Disk__StatusID__2D27B809");
            });

            modelBuilder.Entity<DiskBorrower>(entity =>
            {
                entity.Property(e => e.DiskBorrowerId).HasColumnName("DiskBorrowerID");

                entity.Property(e => e.BorrowedDate).HasColumnType("date");

                entity.Property(e => e.BorrowerId).HasColumnName("BorrowerID");

                entity.Property(e => e.DiskId).HasColumnName("DiskID");

                entity.Property(e => e.ReturnedDate).HasColumnType("date");

                entity.HasOne(d => d.Borrower)
                    .WithMany(p => p.DiskBorrower)
                    .HasForeignKey(d => d.BorrowerId)
                    .HasConstraintName("FK__DiskBorro__Borro__30F848ED");

                entity.HasOne(d => d.Disk)
                    .WithMany(p => p.DiskBorrower)
                    .HasForeignKey(d => d.DiskId)
                    .HasConstraintName("FK__DiskBorro__DiskI__31EC6D26");
            });

            modelBuilder.Entity<DiskType>(entity =>
            {
                entity.Property(e => e.DiskTypeId).HasColumnName("DiskTypeID");

                entity.Property(e => e.Type)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Genre>(entity =>
            {
                entity.Property(e => e.GenreId).HasColumnName("GenreID");

                entity.Property(e => e.Genre1)
                    .IsRequired()
                    .HasColumnName("Genre")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Status>(entity =>
            {
                entity.Property(e => e.StatusId).HasColumnName("StatusID");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
