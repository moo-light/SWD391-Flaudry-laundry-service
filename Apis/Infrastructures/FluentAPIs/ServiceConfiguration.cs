using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructures.FluentAPIs
{
    public class ServiceConfiguration : IEntityTypeConfiguration<Service>
    {
        public void Configure(EntityTypeBuilder<Service> builder)
        {
            builder.HasKey(e => e.Id);
            builder.Property(x => x.Id).HasDefaultValueSql("NEWID()");
            builder.Property(e => e.CreationDate).HasDefaultValueSql("GETUTCDATE()");
            builder.Property(e => e.PricePerKg).HasColumnType("decimal(10, 2)");

            builder.HasOne(d => d.Store).WithMany(p => p.Services)
                .HasForeignKey(d => d.StoreId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            builder.HasMany(d => d.OrderDetails).WithOne(o => o.Service).HasForeignKey(x => x.ServiceId);

        }
    }
}
