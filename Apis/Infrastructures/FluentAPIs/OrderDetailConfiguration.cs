using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructures.FluentAPIs
{
    public class LaundryOrderConfiguration : IEntityTypeConfiguration<LaundryOrder>
    {
        public void Configure(EntityTypeBuilder<LaundryOrder> builder)
        {
            builder.HasKey(e => e.Id);
            builder.Property(x => x.Id).HasDefaultValueSql("NEWID()");


            builder.HasOne(d => d.Building).WithMany(p => p.Orders)
                .HasForeignKey(d => d.BuildingId)
                .OnDelete(DeleteBehavior.ClientSetNull);
            builder.HasOne(d => d.Customer).WithMany(p => p.Orders)
                .HasForeignKey(d => d.CustomerId)
                .OnDelete(DeleteBehavior.ClientSetNull);
            builder.HasOne(d => d.Store).WithMany(p => p.Orders)
                .HasForeignKey(d => d.BuildingId)
                .OnDelete(DeleteBehavior.ClientSetNull);
            builder.HasMany(d => d.OrderInBatches).WithOne(o => o.Order).HasForeignKey(x => x.OrderId);
            builder.HasMany(d => d.OrderDetails).WithOne(o => o.Order).HasForeignKey(x => x.OrderId);
            builder.HasMany(d => d.Payments).WithOne(o => o.Order).HasForeignKey(x => x.OrderId);
        }
    }
}
