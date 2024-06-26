using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using BlazorFullStackCrud.Server.Models;

namespace BlazorFullStackCrud.Server.Data
{
    public partial class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext()
        {
        }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Good> Goods { get; set; } = null!;
        public virtual DbSet<IssueNote> IssueNotes { get; set; } = null!;
        public virtual DbSet<IssueNoteDetail> IssueNoteDetails { get; set; } = null!;
        public virtual DbSet<TestTable1> TestTable1s { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=KINGERVINMSI18\\SQLEXPRESS;Initial Catalog=test_database01;Persist Security Info=True;User ID=tester1;Password=Kopi12345678901;Encrypt=True;Trust Server Certificate=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Good>(entity =>
            {
                entity.Property(e => e.GoodId).HasColumnName("GoodID");

                entity.Property(e => e.Description).HasMaxLength(255);

                entity.Property(e => e.Name).HasMaxLength(100);
            });

            modelBuilder.Entity<IssueNote>(entity =>
            {
                entity.Property(e => e.IssueNoteId).HasColumnName("IssueNoteID");

                entity.Property(e => e.IssueDate).HasColumnType("datetime");

                entity.Property(e => e.Remarks).HasMaxLength(255);

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.IssueNotes)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK__IssueNote__UserI__4D94879B");
            });

            modelBuilder.Entity<IssueNoteDetail>(entity =>
            {
                entity.Property(e => e.IssueNoteDetailId).HasColumnName("IssueNoteDetailID");

                entity.Property(e => e.GoodId).HasColumnName("GoodID");

                entity.Property(e => e.IssueNoteId).HasColumnName("IssueNoteID");

                entity.HasOne(d => d.Good)
                    .WithMany(p => p.IssueNoteDetails)
                    .HasForeignKey(d => d.GoodId)
                    .HasConstraintName("FK__IssueNote__GoodI__5165187F");

                entity.HasOne(d => d.IssueNote)
                    .WithMany(p => p.IssueNoteDetails)
                    .HasForeignKey(d => d.IssueNoteId)
                    .HasConstraintName("FK__IssueNote__Issue__5070F446");
            });

            modelBuilder.Entity<TestTable1>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("test_table1");

                entity.Property(e => e.Code)
                    .HasMaxLength(20)
                    .HasColumnName("code");

                entity.Property(e => e.Description)
                    .HasMaxLength(255)
                    .HasColumnName("description");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Usertype)
                    .HasMaxLength(20)
                    .HasColumnName("usertype");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.Property(e => e.PasswordHash).HasMaxLength(255);

                entity.Property(e => e.Role).HasMaxLength(20);

                entity.Property(e => e.Username).HasMaxLength(50);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
