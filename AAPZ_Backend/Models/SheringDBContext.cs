using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using AAPZ_Backend.Models; 

namespace AAPZ_Backend
{
    public partial class SheringDBContext : IdentityDbContext<User>
    {
        public SheringDBContext()
        {
        }

        public SheringDBContext(DbContextOptions<SheringDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Building> Building { get; set; }
        public virtual DbSet<Client> Client { get; set; }
        public virtual DbSet<Landlord> Landlord { get; set; }
        public virtual DbSet<Workplace> Workplace { get; set; }
        public virtual DbSet<WorkplaceOrder> WorkplaceOrder { get; set; }
        public virtual DbSet<User> User { get; set; }
        public virtual DbSet<Equipment> Equipment { get; set; }
        public virtual DbSet<WorkplaceEquipment> WorkplaceEquipment { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=DESKTOP-LLK7E72\\DEVELOPERSQL;Database=SheringDB;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.HasAnnotation("ProductVersion", "2.2.0-preview3-35497");

            modelBuilder.Entity<Building>(entity =>
            {
                entity.Property(e => e.City)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Country)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.House)
                    .IsRequired()
                    .HasMaxLength(10);

                entity.Property(e => e.Street)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.Landlord)
                    .WithMany(p => p.Building)
                    .HasForeignKey(d => d.LandlordId)
                    .HasConstraintName("FK_LandlordId");
            });

            modelBuilder.Entity<Client>(entity =>
            {
                entity.Property(e => e.Birthday).HasColumnType("date");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.FirstName).IsRequired();

                entity.Property(e => e.LastName).IsRequired();
            });

            modelBuilder.Entity<Landlord>(entity =>
            {
                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.FirstName).IsRequired();

                entity.Property(e => e.LastName).IsRequired();
            });

            modelBuilder.Entity<Workplace>(entity =>
            {
                entity.HasOne(d => d.Building)
                    .WithMany(p => p.Workplace)
                    .HasForeignKey(d => d.BuildingId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_BuildingId");
            });

            modelBuilder.Entity<WorkplaceOrder>(entity =>
            {
                entity.Property(e => e.FinishTime).HasColumnType("datetime");

                entity.Property(e => e.StartTime).HasColumnType("datetime");

                entity.HasOne(d => d.Client)
                    .WithMany(p => p.WorkplaceOrder)
                    .HasForeignKey(d => d.ClientId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ClientId");

                entity.HasOne(d => d.Workplace)
                    .WithMany(p => p.WorkplaceOrder)
                    .HasForeignKey(d => d.WorkplaceId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_WorkplaceId");
            });
        }
    }
}
