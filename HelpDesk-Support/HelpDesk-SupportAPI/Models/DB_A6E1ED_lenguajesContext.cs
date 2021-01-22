using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

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

        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<EmployeeService> EmployeeServices { get; set; }
        public virtual DbSet<Issue> Issues { get; set; }
        public virtual DbSet<Note> Notes { get; set; }
        public virtual DbSet<Service> Services { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=sql5101.site4now.net;Initial Catalog=DB_A6E1ED_lenguajes;;User ID=DB_A6E1ED_lenguajes_admin;Password=lenguajes3");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.ToTable("Employee");

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

                entity.ToTable("EmployeeService");

                entity.Property(e => e.CreateDate).HasColumnType("datetime");

                entity.Property(e => e.ModifyDate).HasColumnType("datetime");

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.EmployeeServices)
                    .HasForeignKey(d => d.EmployeeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Employee_Service_FK1");

                entity.HasOne(d => d.Service)
                    .WithMany(p => p.EmployeeServices)
                    .HasForeignKey(d => d.ServiceId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Employee_Service_FK2");
            });

            modelBuilder.Entity<Issue>(entity =>
            {
                entity.HasKey(e => e.ReportNumber)
                    .HasName("PK__Issue__5A964EF99F589D49");

                entity.ToTable("Issue");

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
                    .WithMany(p => p.IssueEmployees)
                    .HasForeignKey(d => d.EmployeeId)
                    .HasConstraintName("Employee_FK");

                entity.HasOne(d => d.Service)
                    .WithMany(p => p.Issues)
                    .HasForeignKey(d => d.ServiceId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Service_FK");

                entity.HasOne(d => d.Supervisor)
                    .WithMany(p => p.IssueSupervisors)
                    .HasForeignKey(d => d.SupervisorId)
                    .HasConstraintName("Supervisor_FK2");
            });

            modelBuilder.Entity<Note>(entity =>
            {
                entity.HasKey(e => e.NotesId)
                    .HasName("PK__Notes__35AB5BAA76F55E1F");

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
                entity.ToTable("Service");

                entity.HasIndex(e => e.Name, "UQ__Service__737584F6B9950E96")
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
