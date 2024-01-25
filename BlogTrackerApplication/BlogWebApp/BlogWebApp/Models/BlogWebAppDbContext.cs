using System;
using System.Collections.Generic;
using BlogWebApp.Models;
using System.Reflection.Emit;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Options;

namespace BlogWebApp.Models
{
    public partial class CapstoneProjDb1Context : DbContext
    {
        public CapstoneProjDb1Context()
        {
        }

        public CapstoneProjDb1Context(DbContextOptions<CapstoneProjDb1Context> options)
            : base(options)
        {
        }

        public virtual DbSet<AdminInfo> AdminInfos { get; set; } = null!;
        public virtual DbSet<BlogInfo> BlogInfos { get; set; } = null!;
        public virtual DbSet<EmpInfo> EmpInfos { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("tcp:Server=blog-tracker-server.database.windows.net,1433;Initial Catalog=BlogTrackerDB;Persist Security Info=False;User ID=Blog;Password=Tracker@1234;MultipleActiveResultSets=False;Encrypt=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AdminInfo>(entity =>
            {
                entity.HasKey(e => e.EmailId)
                    .HasName("PK__AdminInf__7ED91ACF4A77FFE4");

                entity.ToTable("AdminInfo");

                entity.Property(e => e.EmailId).HasMaxLength(50);

                entity.Property(e => e.Password).HasMaxLength(50);
            });

            modelBuilder.Entity<BlogInfo>(entity =>
            {
                entity.HasKey(e => e.BlogId)
                    .HasName("PK__BlogInfo__54379E30525266B2");

                entity.ToTable("BlogInfo");

                entity.Property(e => e.BlogId).ValueGeneratedNever();

                entity.Property(e => e.BlogUrl).HasMaxLength(100);

                entity.Property(e => e.DateOfCreation).HasColumnType("datetime");

                entity.Property(e => e.EmpEmailId).HasMaxLength(50);

                entity.Property(e => e.Subject).HasMaxLength(50);

                entity.HasOne(d => d.EmpEmail)
                    .WithMany(p => p.BlogInfos)
                    .HasForeignKey(d => d.EmpEmailId)
                    .HasConstraintName("FK__BlogInfo__EmpEma__3B75D760");
            });

            modelBuilder.Entity<EmpInfo>(entity =>
            {
                entity.HasKey(e => e.EmailId)
                    .HasName("PK__EmpInfo__7ED91ACFA91270AE");

                entity.ToTable("EmpInfo");

                entity.Property(e => e.EmailId).HasMaxLength(50);

                entity.Property(e => e.DateOfJoining).HasColumnType("datetime");

                entity.Property(e => e.Name).HasMaxLength(50);
            });
            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}