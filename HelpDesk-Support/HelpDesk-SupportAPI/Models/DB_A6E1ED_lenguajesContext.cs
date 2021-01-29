using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace HelpDesk_SupportAPI.Models
{
    public partial class DB_A6E1ED_lenguajesContext : DbContext
    {
        public DB_A6E1ED_lenguajesContext()
        {
        }

        public DB_A6E1ED_lenguajesContext(DbContextOptions<DB_A6E1ED_lenguajesContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Employee> Employee { get; set; }
        public virtual DbSet<EmployeeService> EmployeeService { get; set; }
        public virtual DbSet<Issue> Issue { get; set; }
        public virtual DbSet<Notes> Notes { get; set; }
        public virtual DbSet<Service> Service { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=sql5101.site4now.net;Initial Catalog=DB_A6E1ED_lenguajes;;User ID=DB_A6E1ED_lenguajes_admin;Password=lenguajes3");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>(entity =>
            {
                entity.Property(e => e.CreateDate).HasColumnType("datetime");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.FirstSurname)
                    .IsRequired()
                    .HasMaxLength(30);

                entity.Property(e => e.ModifyDate).HasColumnType("datetime");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(25);

                entity.Property(e => e.Password).HasMaxLength(25);

                entity.Property(e => e.SecondSurname)
                    .IsRequired()
                    .HasMaxLength(30);

                entity.HasOne(d => d.Supervisor)
                    .WithMany(p => p.InverseSupervisor)
                    .HasForeignKey(d => d.SupervisorId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Supervisor_FK");
            });

            modelBuilder.Entity<EmployeeService>(entity =>
            {
                entity.HasKey(e => new { e.EmployeeId, e.ServiceId })
                    .HasName("Employee_Service_PK");

                entity.Property(e => e.CreateDate).HasColumnType("datetime");

                entity.Property(e => e.ModifyDate).HasColumnType("datetime");

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.EmployeeService)
                    .HasForeignKey(d => d.EmployeeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Employee_Service_FK1");

                entity.HasOne(d => d.Service)
                    .WithMany(p => p.EmployeeService)
                    .HasForeignKey(d => d.ServiceId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Employee_Service_FK2");
            });

            modelBuilder.Entity<Issue>(entity =>
            {
                entity.HasKey(e => e.ReportNumber)
                    .HasName("PK__Issue__5A964EF99F589D49");

                entity.Property(e => e.Classification)
                    .IsRequired()
                    .HasMaxLength(5);

                entity.Property(e => e.CreateDate).HasColumnType("datetime");

                entity.Property(e => e.ModifyDate).HasColumnType("datetime");

                entity.Property(e => e.ReportDate).HasColumnType("datetime");

                entity.Property(e => e.ResolutionComment)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.Status)
                    .IsRequired()
                    .HasMaxLength(12);

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.IssueEmployee)
                    .HasForeignKey(d => d.EmployeeId)
                    .HasConstraintName("Employee_FK");

                entity.HasOne(d => d.Service)
                    .WithMany(p => p.Issue)
                    .HasForeignKey(d => d.ServiceId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Service_FK");

                entity.HasOne(d => d.Supervisor)
                    .WithMany(p => p.IssueSupervisor)
                    .HasForeignKey(d => d.SupervisorId)
                    .HasConstraintName("Supervisor_FK2");
            });

            modelBuilder.Entity<Notes>(entity =>
            {
                entity.Property(e => e.CreateDate).HasColumnType("datetime");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.ModifyDate).HasColumnType("datetime");

                entity.Property(e => e.NoteDate).HasColumnType("datetime");

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.Notes)
                    .HasForeignKey(d => d.EmployeeId)
                    .HasConstraintName("Employee_FK2");

                entity.HasOne(d => d.ReportNumberNavigation)
                    .WithMany(p => p.Notes)
                    .HasForeignKey(d => d.ReportNumber)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Report_FK");
            });

            modelBuilder.Entity<Service>(entity =>
            {
                entity.HasIndex(e => e.Name)
                    .HasName("UQ__Service__737584F6B9950E96")
                    .IsUnique();

                entity.Property(e => e.CreateDate).HasColumnType("datetime");

                entity.Property(e => e.ModifyDate).HasColumnType("datetime");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(20);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
