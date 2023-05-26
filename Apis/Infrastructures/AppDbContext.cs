using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Infrastructures
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        protected AppDbContext()
        {
        }

        public DbSet<Batch> Batchs { get; set; }
        public DbSet<Building> Buildings { get; set; }
        public DbSet<DriverReport> DriverReports { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Package> Packages { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<Store> Stores { get; set; }
        public DbSet<StoreReport> StoreReports { get; set; }
        public DbSet<TimeSlot> TimeSlots { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Batch>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(x => x.Id).HasDefaultValueSql("NEWID()");

                entity.Property(e => e.BatchType).HasMaxLength(20);

                entity.HasOne(d => d.Driver).WithMany(p => p.Batches)
                    .HasForeignKey(d => d.DriverId)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.TimeSlot).WithMany(p => p.Batches)
                    .HasForeignKey(d => d.TimeSlotId)
            ;
            });

            modelBuilder.Entity<Building>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(x => x.Id).HasDefaultValueSql("NEWID()");

                entity.Property(e => e.Name).HasMaxLength(100);
            });

            modelBuilder.Entity<DriverReport>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.Property(x => x.Id).HasDefaultValueSql("NEWID()");
                entity.Property(e => e.Status).HasMaxLength(20);

                entity.HasOne(d => d.User).WithMany(p => p.DriverReports)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(x => x.Id).HasDefaultValueSql("NEWID()");

                entity.Property(e => e.DeliveringStatus).HasMaxLength(20);
                entity.Property(e => e.TotalPrice).HasColumnType("decimal(10, 2)");

                entity.HasOne(d => d.Building).WithMany(p => p.Orders)
                    .HasForeignKey(d => d.BuildingId)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.Package).WithMany(p => p.Orders)
                    .HasForeignKey(d => d.PackageId)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.Store).WithMany(p => p.Orders)
                    .HasForeignKey(d => d.StoreId)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.User).WithMany(p => p.Orders)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<Package>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).HasDefaultValueSql("NEWID()");

                entity.Property(e => e.Price).HasColumnType("decimal(10, 2)");
                entity.Property(e => e.WeightKg).HasColumnType("decimal(10, 2)");

                entity.HasOne(d => d.PackageNavigation).WithOne(p => p.PackageNavigation)
                    .HasForeignKey<Package>(d => d.Id)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.Service).WithMany(p => p.Packages)
                    .HasForeignKey(d => d.ServiceId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<Payment>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).HasDefaultValueSql("NEWID()");

                entity.Property(e => e.Status).HasMaxLength(20);

                entity.HasOne(d => d.Package).WithMany(p => p.Payments)
                    .HasForeignKey(d => d.PackageId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.HasKey(e => e.RoleId);
                entity.Property(e => e.RoleId).HasDefaultValueSql("NEWID()");

                entity.Property(e => e.RoleName).HasMaxLength(50);
            });

            modelBuilder.Entity<Service>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).HasDefaultValueSql("NEWID()");

                entity.Property(e => e.PricePerKg).HasColumnType("decimal(10, 2)");

                entity.HasOne(d => d.Store).WithMany(p => p.Services)
                    .HasForeignKey(d => d.StoreId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<Store>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).HasDefaultValueSql("NEWID()");

                entity.Property(e => e.Name).HasMaxLength(100);

                entity.HasOne(d => d.Owner).WithMany(p => p.Stores)
                    .HasForeignKey(d => d.OwnerId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<StoreReport>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).HasDefaultValueSql("NEWID()");

                entity.Property(e => e.Status).HasMaxLength(20);

                entity.HasOne(d => d.Service).WithMany(p => p.StoreReports)
                    .HasForeignKey(d => d.ServiceId)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.Store).WithMany(p => p.StoreReports)
                    .HasForeignKey(d => d.StoreId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<TimeSlot>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).HasDefaultValueSql("NEWID()");

                entity.Property(e => e.Date).HasColumnType("date");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).HasDefaultValueSql("NEWID()");

                entity.HasIndex(e => e.Email).IsUnique();

                entity.Property(e => e.Email).HasMaxLength(100);
                entity.Property(e => e.FullName).HasMaxLength(100);
                entity.Property(e => e.PhoneNumber).HasMaxLength(20);

                entity.HasOne(d => d.Role).WithMany(p => p.Users)
                    .HasForeignKey(d => d.RoleId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });
        }
    }
}
